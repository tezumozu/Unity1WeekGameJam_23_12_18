using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class ResultManager : MonoBehaviour {

    public Subject<Unit> FinishResultSubject = new Subject<Unit>();
    private ScoreManager ScoreManager;

    [SerializeField] 
    private GameObject ResutUI;

    public void InitObject( ScoreManager scoreManager , ResultInputAction resultInputAction ){
        if(scoreManager == null){
            Debug.Log("Scoer");
        }

        this.ScoreManager = scoreManager;

        resultInputAction.ResultExitSubject.Subscribe(_=>{
            if(!this.ScoreManager.IsSkip){
                this.ScoreManager.SkipAnim();
            }else{
                FinishResultSubject.OnNext(Unit.Default);
            }
        });
    }

    public void StartResult(){
        ResutUI.SetActive(true);
        ScoreManager.DisplayScore();
    }
}
