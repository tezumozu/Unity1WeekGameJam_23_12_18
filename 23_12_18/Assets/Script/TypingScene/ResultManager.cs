using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class ResultManager{

    public Subject<Unit> FinishResultSubject;
    private ScoerManager scoerManager;

    public ResultManager () {
        FinishResultSubject = new Subject<Unit>();
    }

    public void InitObject(ScoerManager scoerManager){
        this.scoerManager = scoerManager;
    }

    public void StartResult(){
        scoerManager.DisplayScoer();
    }
}
