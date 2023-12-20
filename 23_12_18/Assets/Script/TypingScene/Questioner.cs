using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Questioner : I_SpelCheckable{

     int questionCount;
     const int maxQuestionCount = 5;
     int spellCount;

     QuestionSet currentQuestionSet;
     E_QuestionState currentQuestionState;

     public Questioner(){
          questionCount = 0;
          spellCount = 0;
          currentQuestionSet = new StartQuestionSet();
          currentQuestionState = E_QuestionState.FIRST;

          Debug.Log("Question : " + currentQuestionSet.Questions[currentQuestionState].QuestionText);
     }

     public void checkSpel(char c){
          //問題とあっているか確認
          if(c == currentQuestionSet.Questions[currentQuestionState].Spell[spellCount]){
               spellCount++;
               Debug.Log("Question : " + currentQuestionSet.Questions[currentQuestionState].QuestionText);
               

               //全文字正解したら
               if (spellCount == currentQuestionSet.Questions[currentQuestionState].Spell.Length){
                    spellCount = 0;

                    //次の問題を生成

                    if(currentQuestionState == E_QuestionState.FIRST){
                         currentQuestionState = E_QuestionState.LATTER;
                    }else{
                         questionCount++;

                         //次が最終問題か？
                         if(maxQuestionCount < questionCount){
                              currentQuestionSet = new EndQuestionSet();
                         }else{
                              //そうでない
                              currentQuestionSet = new RandQuestionSet();
                         }

                         currentQuestionState = E_QuestionState.FIRST;
                    }
                    
               }
               
          }
          
     } 
}
