using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class Timer : MonoBehaviour
{
    float currentTime;
    bool isTimerOn;
    float limitTime;

    public Subject<float> TimeLimitSubject;

    public float GetCurrentTime{
        get{return currentTime;}
    }
    
    public void Start(){
        currentTime = 0;
        isTimerOn = false;

        TimeLimitSubject = new Subject<float>();
    }

    void Update(){
        if (!isTimerOn) return;

        currentTime += Time.deltaTime;

        //時間切れ
        if(limitTime < currentTime){
            isTimerOn = false;
            TimeLimitSubject.OnNext(limitTime);
        }
    }

    public void StartTimer(float limit){
        currentTime = 0;
        limitTime = limit;
        isTimerOn = true;
    }

    public float StopTimer(){
        isTimerOn = false;
        return currentTime;
    }
}
