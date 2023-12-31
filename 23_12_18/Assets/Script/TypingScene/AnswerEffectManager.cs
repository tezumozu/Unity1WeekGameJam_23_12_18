using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class AnswerEffectManager : MonoBehaviour{

    //仮のディレイ用
    float currentTime;
    float time = 1.0f;

    public Subject<Unit> FinishDisplaySubject;

    [SerializeField]
    private AudioClip Correct;

    [SerializeField]
    private AudioClip Incorrect;

    private AudioSource audioSource;



    [SerializeField]
    private List<EvaluationSprite> spriteList;

    [SerializeField] 
    private Text answerText;

    [SerializeField] 
    private Image evaluationImage;

    [SerializeField] 
    private GameObject answerObject;

    Answer answer;

    private void Start(){
        FinishDisplaySubject = new Subject<Unit>();
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    public void InitObject (){
    }

    private IEnumerator displayEffects(){
    
        answerObject.SetActive(true);

        if(this.answer.IsClear){
            audioSource.Play();
        }

        //演出の終了を確認
        while (audioSource.isPlaying){
            yield return null;
        }

        if(this.answer.IsClear){
            audioSource.clip = Correct;
        }else{
            audioSource.clip = Incorrect;
        }

        audioSource.Play();
        evaluationImage.gameObject.SetActive(true);
        currentTime = 0;
        //演出の終了を確認
        while (audioSource.isPlaying || time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }
        
        answerObject.SetActive(false);
        evaluationImage.gameObject.SetActive(false);
        FinishDisplaySubject.OnNext(Unit.Default);

    }

    public void displayEvaluation(Answer answer){
        this.answer = answer;

        //音声読み込み
        var clip = Resources.Load<AudioClip> ("Wav/Voice/QuestionVoice/" + answer.Question.VoiceFileName.ToString());
        if(clip == null){
            Debug.Log("NonCrip");
        }else{
            audioSource.clip = clip;
        }

        //評価入力
        foreach(var data in spriteList){
            if( data.Evaluation == this.answer.Evaluation ) {
                evaluationImage.sprite = data.Sprite;
            }
        }

        //テキスト入力
        if(this.answer.IsClear){
            answerText.text = this.answer.Question.QuestionText + "！";
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
