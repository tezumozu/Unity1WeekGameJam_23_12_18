using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour{

    float currentTime;
    bool isTimerOn;
    
    public void InitObuject(){
        currentTime = 0;
        isTimerOn = false;
    }

    void Update(){
        if (isTimerOn){
            currentTime += Time.deltaTime;
        }        
    }
}
