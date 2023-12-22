using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class Questioner : I_SpelCheckable{

     bool isInputActive;

     int questionCount;
     const int maxQuestionCount = 6;
     int spellCount;

     QuestionSet currentQuestionSet;
     E_QuestionState currentQuestionState;

     Timer timer;

     public Subject<Unit> AllFinishQuestionSubject;

     public Question GetQuestion{
          get{
               return currentQuestionSet.Questions[currentQuestionState];
          }
     }

     public Questioner(Timer timer){
          this.timer = timer;
          FinishQuestionSubject = new Subject<Answer>();
          AllFinishQuestionSubject = new Subject<Unit>();
     }

     public void InitObject(){
          questionCount = 0;
          spellCount = 0;
          isInputActive = false;
          
          currentQuestionState = E_QuestionState.FIRST;

          //入力を監視
          //評価演出の終了を監視
     }

     public void StartQuestion(){
          isInputActive = true;
          currentQuestionSet = new StartQuestionSet();
     }


     public void checkSpel(char c){
          //入力を受け付けているか
          if(!isInputActive) return;

          Question currentQuestion = currentQuestionSet.Questions[currentQuestionState];
          int spellLength = currentQuestion.Spell.Length;

          //問題とあっているか確認
          if(c == currentQuestion.Spell[spellCount]){
               spellCount++;
               //UIの更新


               //全文入力されたら
               if (spellCount == spellLength){
                    timer.StopTimer();

                    //次の問題へ
                    Answer answer = getResult();
                    toNextQuestion();

                    //評価を表示する
                    isInputActive = false;
                    
               //時間切れか
               }else if(){
                    timer.StopTimer();

                    //次の問題へ
                    Answer answer = getResult();
                    toNextQuestion();


               }
          }
     }

     private Answer getResult(){
          var evaluation = checkEvaluation(currentQuestion,timer.GetCurrentTime);
          var answer = new Answer(currentQuestion , true , timer.GetCurrentTime , evaluation);

          return answer;
     }

     private Answer toNextQuestion(){
          
          Question currentQuestion = currentQuestionSet.Questions[currentQuestionState];

          spellCount = 0;

          //前半の問題？
          if(currentQuestionState == E_QuestionState.FIRST){
               //後半の問題へ
               currentQuestionState = E_QuestionState.LATTER;
          }else{
               //新しい問題を生成
               questionCount++;
               currentQuestionState = E_QuestionState.FIRST;

               //次が最終問題か？
               if(maxQuestionCount < questionCount){
                    currentQuestionSet = new EndQuestionSet();
               }else{
                    //そうでない
                    currentQuestionSet = new RandQuestionSet();
               }
          }

     }


     private E_Evaluation checkEvaluation(Question question, float clearTime){
          if(clearTime/question.Time < 0.5f){
               return E_Evaluation.GREAT;

          }else if(clearTime/question.Time < 0.7f){
               return E_Evaluation.GOOD;

          }else if(clearTime/question.Time < 1.0f){
               return E_Evaluation.NICE;

          }else{
               return E_Evaluation.BAD;
          }
     }
}
