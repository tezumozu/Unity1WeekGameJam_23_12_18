using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestionEffectManager : MonoBehaviour{

    Question currentQuestion;

    [SerializeField] 
    private GameObject questionUI;

    [SerializeField] 
    private Text answerText;
    
    [SerializeField] 
    private Text questionText;

    void Start(){
    }

    //入力された文字を更新する
    public void UpdateQuestion(int count){
        string inputed = "";
        string notinputed = "";

        for (int i = 0; i < currentQuestion.Spell.Length; i++){
            if(i < count){
                inputed += currentQuestion.Spell[i];
            }else{
                notinputed += currentQuestion.Spell[i];
            }
        }

        //入力分の色を変更 
        answerText.text = "<color=#222222>" + inputed + "</color>" + notinputed;
    }

    //問題を表示する
    public void DisplayQuestion(Question question){
        currentQuestion = question;
        questionUI.SetActive(true);
        answerText.text = currentQuestion.Spell;
        questionText.text = currentQuestion.QuestionText;
        
    }

    //問題を非表示にする
    public void NotActiveQuestion(){
        questionUI.SetActive(false);
    }
}
