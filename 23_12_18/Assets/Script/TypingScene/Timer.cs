using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UniRx;

public class Timer : MonoBehaviour
{
    float currentTime;
    bool isTimerOn;
    float limitTime;
    Slider timerSlider;

    public Subject<float> TimeLimitSubject;

    public float GetCurrentTime{
        get{return currentTime;}
    }
    
    public void Start(){
        currentTime = 0;
        isTimerOn = false;

        TimeLimitSubject = new Subject<float>();
        timerSlider = GameObject.Find("TimerSlider").GetComponent<Slider>();
    }

    void Update(){
        if (!isTimerOn) return;

        currentTime += Time.deltaTime;
        timerSlider.value = 1.0f - currentTime / limitTime;

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
        timerSlider.value = 1;
    }

    public float StopTimer(){
        isTimerOn = false;
        return currentTime;
    }
}
