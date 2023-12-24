using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class OpningManager {
    public Subject<Unit> FinishOpningSubject;

    public OpningManager(){
        FinishOpningSubject = new Subject<Unit>();
    }

    public void InitObject(){
    }

    public void StartOpening(){
        Debug.Log("めたん「 おくることば 」");
        Debug.Log("めたん「 ずんだもんのみなさん、おねがいします 」");

        Debug.Log("ずんだもんたち「 はぁい！ 」");

        FinishOpningSubject.OnNext(Unit.Default);
    }

}
