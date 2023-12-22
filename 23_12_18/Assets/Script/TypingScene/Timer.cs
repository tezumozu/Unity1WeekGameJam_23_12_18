using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float currentTime;
    bool isTimerOn;

    public float GetCurrentTime{
        get{return currentTime;}
    }
    
    public void InitObuject(){
        currentTime = 0;
        isTimerOn = false;
    }

    void Update(){
        if (isTimerOn){
            currentTime += Time.deltaTime;
        }        
    }

    public void StartTimer(){
        currentTime = 0;
        isTimerOn = true;
    }

    public float StopTimer(){
        isTimerOn = false;
        return currentTime;
    }
}
