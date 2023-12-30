using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class EndingManager : MonoBehaviour {
    public Subject<Unit> FinishEndingSubject = new Subject<Unit>();

    //仮のディレイ用
    float currentTime;
    float time = 3.0f;


    [SerializeField] 
    private Text MetanLinesText;

    [SerializeField] 
    private GameObject MetanLines;

    public void InitObject(){
    }

    private IEnumerator DisplayEnding(){


        while(currentTime < time){
            currentTime += Time.deltaTime;

            yield return null;
        }

        MetanLinesText.text = "第一回ずんだ小学校";

        currentTime = 0;
        while(currentTime < time){
            currentTime += Time.deltaTime;
            yield return null;
        }

        MetanLinesText.text = "卒業式を終了します";
        
        currentTime = 0;
        while(currentTime < time){
            currentTime += Time.deltaTime;
            yield return null;
        }
        MetanLines.SetActive(false);

        FinishEndingSubject.OnNext(Unit.Default);
    }

    public void StartEnding(){
        currentTime = 0;
        MetanLinesText.text = "これにて";
        MetanLines.SetActive(true);
        StartCoroutine(DisplayEnding());
    }
}
