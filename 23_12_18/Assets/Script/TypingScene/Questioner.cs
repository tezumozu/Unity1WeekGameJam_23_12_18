using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class Questioner : I_SpelCheckable{

     private bool isInputActive;

     private int questionCount;
     private const int maxQuestionCount = 8;
     private int spellCount;

     private QuestionSet currentQuestionSet;
     private E_QuestionState currentQuestionState;

     private Timer timer;
     private AnswerEffectManager answerEffectManager;
     private QuestionEffectManager questionEffectManager;
     private ScoerManager scoerManager;

     public Subject<Unit> AllFinishQuestionSubject;

     public Question GetQuestion{
          get{
               return currentQuestionSet.Questions[currentQuestionState];
          }
     }

     public Questioner(){
          AllFinishQuestionSubject = new Subject<Unit>();
     }

     public void InitObject(QuestionEffectManager questionEffectManager,AnswerEffectManager answerEffectManager, KeyTypeGetter keyTypeGetter , ScoerManager scoerManager ,Timer timer){
          questionCount = 0;
          spellCount = 0;
          isInputActive = false;

          this.questionEffectManager = questionEffectManager;
          this.answerEffectManager = answerEffectManager;
          this.scoerManager = scoerManager;
          this.timer = timer;

          //制限時間を監視
          //時間切れ時の処理
          this.timer.TimeLimitSubject.Subscribe(time => {
               isInputActive = false;

               //問題を非表示
               questionEffectManager.NotActiveQuestion();

               //評価を表示する
               Answer answer = getResult( time , false );
               this.scoerManager.UpdateScoer(answer);
               this.answerEffectManager.displayEvaluation( answer );

          });

          //入力を監視
          keyTypeGetter.KeyTypeSubject.Subscribe(c => {
               //入力を受け付けているか
               if(!isInputActive) return;
               checkSpel(c);
          });


          //評価演出の終了を監視
          this.answerEffectManager.FinishDisplaySubject.Subscribe( _ =>{

               //クイズを終了
               if(questionCount == maxQuestionCount && currentQuestionState == E_QuestionState.LATTER){
                    AllFinishQuestionSubject.OnNext(Unit.Default);
                    return;

               }else{
                    toNextQuestion();
               }
          });
     }

     public void StartQuestion(){
          isInputActive = true;
          currentQuestionState = E_QuestionState.FIRST;
          currentQuestionSet = new StartQuestionSet();

          //問題を表示
          questionEffectManager.DisplayQuestion(currentQuestionSet.Questions[currentQuestionState]);
          //タイマー開始
          timer.StartTimer(currentQuestionSet.Questions[currentQuestionState].Time);
     }


     public void checkSpel(char c){
          
          Question currentQuestion = currentQuestionSet.Questions[currentQuestionState];
          int spellLength = currentQuestion.Spell.Length;

          //問題とあっているか確認
          if(c == currentQuestion.Spell[spellCount]){
               spellCount++;
               //UIの更新
               //問題を非表示
               questionEffectManager.UpdateQuestion(spellCount);

               string input = "";
               for(int i =  0; i < spellCount; i++){
                   input += currentQuestion.Spell[i];
               }

               Debug.Log(input);

               //全文入力されたら
               if (spellCount == spellLength){
                    timer.StopTimer();
                    isInputActive = false;

                    //問題を非表示
                    questionEffectManager.NotActiveQuestion();

                    //評価を表示する
                    Answer answer = getResult( timer.GetCurrentTime , true );
                    this.scoerManager.UpdateScoer(answer);
                    this.answerEffectManager.displayEvaluation( answer );
               }
          }
     }

     private Answer getResult(float clearTime,bool isClear){
          Question currentQuestion = currentQuestionSet.Questions[currentQuestionState];

          var evaluation = checkEvaluation(currentQuestion.Time, clearTime);
          var answer = new Answer(currentQuestion , isClear , clearTime , evaluation);

          return answer;
     }

     private void toNextQuestion(){

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
               if(maxQuestionCount == questionCount){
                    currentQuestionSet = new EndQuestionSet();
               }else{
                    //そうでない
                    currentQuestionSet = new RandQuestionSet();
               }
          }

          currentQuestion = currentQuestionSet.Questions[currentQuestionState];

          //次の問題を表示
          questionEffectManager.DisplayQuestion(currentQuestion);

          isInputActive = true;
          timer.StartTimer(currentQuestionSet.Questions[currentQuestionState].Time);
     }


     private E_Evaluation checkEvaluation(float limitTime, float clearTime){
          Debug.Log( clearTime + " : " + (clearTime / limitTime) );
          if(clearTime / limitTime < 0.5f){
               return E_Evaluation.GREAT;

          }else if(clearTime / limitTime < 0.7f){
               return E_Evaluation.GOOD;

          }else if(clearTime / limitTime < 1.0f){
               return E_Evaluation.NICE;

          }else{
               return E_Evaluation.BAD;
          }
     }
}
