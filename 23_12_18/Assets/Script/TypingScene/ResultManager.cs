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

    public void InitObject( ScoerManager scoerManager , ResultInputAction resultInputAction ){
        this.scoerManager = scoerManager;

        resultInputAction.ResultExitSubject.Subscribe(_=>{
            FinishResultSubject.OnNext(Unit.Default);
        });
    }

    public void StartResult(){
        scoerManager.DisplayScoer();
    }
}
