using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class AnswerEffectManager : MonoBehaviour{
    public Subject<Unit> FinishDisplaySubject;

    //仮のディレイ用
    float currentTime;
    float time;

    Answer answer;

    private void Start(){
        FinishDisplaySubject = new Subject<Unit>();
    }

    public void InitObject (){
        currentTime = 0;
        time = 5.0f;
    }

    private IEnumerator displayEffects(){

        Debug.Log("ずんだもん「" + answer.Question.QuestionText + "！」");
        Debug.Log(answer.Evaluation);

    
        //演出の終了を確認
        while (time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }
        
        FinishDisplaySubject.OnNext(Unit.Default);
    }

    public void displayEvaluation(Answer answer){
        currentTime = 0;
        time = 5.0f;
        this.answer = answer;

        StartCoroutine(displayEffects()); 
    }

}
