using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class OpeningManager : MonoBehaviour {
    public Subject<Unit> FinishOpningSubject = new Subject<Unit>();

    //仮のディレイ用
    float currentTime;
    float time = 3.0f;


    [SerializeField] 
    private Text MetanLinesText;

    [SerializeField] 
    private GameObject MetanLines;

    [SerializeField] 
    private Text ZundaLinesText;

    [SerializeField] 
    private GameObject ZundaLines;


    public void InitObject(){
    }

    private IEnumerator DisplayOpening(){


        while(currentTime < time){
            currentTime += Time.deltaTime;

            yield return null;
        }

        MetanLinesText.text = "ずんだもんの皆さん";

        currentTime = 0;
        while(currentTime < time){
            currentTime += Time.deltaTime;
            yield return null;
        }

        MetanLinesText.text = "おねがいします";
        
        currentTime = 0;
        while(currentTime < time){
            currentTime += Time.deltaTime;
            yield return null;
        }
        MetanLines.SetActive(false);
        ZundaLines.SetActive(true);

        ZundaLinesText.text = "はいなのだ！";
        
        currentTime = 0;
        while(currentTime < time){
            currentTime += Time.deltaTime;
            yield return null;
        }
        ZundaLines.SetActive(false);


        FinishOpningSubject.OnNext(Unit.Default);
    }

    public void StartOpening(){
        currentTime = 0;
        MetanLinesText.text = "おくることば";
        MetanLines.SetActive(true);
        StartCoroutine(DisplayOpening());
    }

}
