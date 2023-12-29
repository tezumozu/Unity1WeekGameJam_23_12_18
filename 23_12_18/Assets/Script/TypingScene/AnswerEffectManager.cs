using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class AnswerEffectManager : MonoBehaviour{
    public Subject<Unit> FinishDisplaySubject;

    //仮のディレイ用
    float currentTime;
    float time;

    [SerializeField]
    private List<EvaluationSprite> spriteList;

    [SerializeField] 
    private Text answerText;

    [SerializeField] 
    private Image evaluationImage;

    [SerializeField] 
    private GameObject answerObject;

    AudioSource audioSource;

    Answer answer;

    private void Start(){
        FinishDisplaySubject = new Subject<Unit>();
    }

    public void InitObject (){
        currentTime = 0;
        time = 5.0f;
    }

    private IEnumerator displayEffects(){
    
        answerObject.SetActive(true);

        //演出の終了を確認
        while (time > currentTime){
            yield return null;
            currentTime += Time.deltaTime;
        }
        
        answerObject.SetActive(false);
        FinishDisplaySubject.OnNext(Unit.Default);
    }

    public void displayEvaluation(Answer answer){
        currentTime = 0;
        time = 5.0f;
        this.answer = answer;

        //評価入力
        foreach(var data in spriteList){
            if( data.Evaluation == this.answer.Evaluation ) {
                 evaluationImage.sprite = data.Sprite;
            }
        }

        //テキスト入力
        if(this.answer.IsClear){
            answerText.text = this.answer.Question.QuestionText;
        }else{
            answerText.text = "？？？";
        }

        StartCoroutine(displayEffects()); 
    }

    [System.Serializable]
    private class EvaluationSprite{
        [SerializeField]
        public E_Evaluation Evaluation;
        
        [SerializeField] 
        public Sprite Sprite;
    }

}
