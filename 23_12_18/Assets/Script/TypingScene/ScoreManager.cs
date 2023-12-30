using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    int Score;
    Dictionary <E_Evaluation,int> evaluationCountDic;
    Dictionary <E_Evaluation,int> ScoreDic;

    float currentTime = 0;
    float time = 1.0f;

    public bool IsSkip {get; private set;}


    [SerializeField] 
    private GameObject GreatUI;

    [SerializeField] 
    private Text GreatText;


    [SerializeField] 
    private GameObject GoodUI;

    [SerializeField] 
    private Text GoodText;


    [SerializeField] 
    private GameObject NiceUI;

    [SerializeField] 
    private Text NiceText;


    [SerializeField] 
    private GameObject BadUI;

    [SerializeField] 
    private Text BadText;


    [SerializeField] 
    private GameObject ScoreUI;

    [SerializeField] 
    private Text ScoreText;

    public void Start(){
        evaluationCountDic = new Dictionary<E_Evaluation, int>();
        evaluationCountDic.Add(E_Evaluation.GREAT,0);
        evaluationCountDic.Add(E_Evaluation.GOOD,0);
        evaluationCountDic.Add(E_Evaluation.NICE,0);
        evaluationCountDic.Add(E_Evaluation.BAD,0);

        IsSkip = false;
    }

    public void InitObject(){
        Score = 0;
        ScoreDic = ScoreDataManager.GetDic;
    }

    public void UpdateScore(Answer answer){
        Score += ScoreDic[answer.Evaluation];
        evaluationCountDic[answer.Evaluation] += 1;
    }

    public void DisplayScore(){
        ScoreText.text = Score.ToString();
        GreatText.text = evaluationCountDic[E_Evaluation.GREAT].ToString();
        GoodText.text = evaluationCountDic[E_Evaluation.GOOD].ToString();
        NiceText.text = evaluationCountDic[E_Evaluation.NICE].ToString();
        BadText.text = evaluationCountDic[E_Evaluation.BAD].ToString();

        currentTime = 0;
        StartCoroutine(ResultAnimation());
    }

    public IEnumerator ResultAnimation(){
        while(!IsSkip && time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }

        GreatUI.SetActive(true);

        currentTime = 0;
        while(!IsSkip && time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }

        GoodUI.SetActive(true);

        currentTime = 0;
        while(!IsSkip && time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }

        NiceUI.SetActive(true);

        currentTime = 0;
        while(!IsSkip && time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }

        BadUI.SetActive(true);

        currentTime = 0;
        while(!IsSkip && time > currentTime){
            currentTime += Time.deltaTime;
            yield return null;
        }

        ScoreUI.SetActive(true);
        IsSkip = true;
    }

    public void SkipAnim(){
        IsSkip = true;
    }
}
