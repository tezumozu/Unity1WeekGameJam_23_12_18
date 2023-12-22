using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class OpningManager {
    public Subject<Unit> FinishOpningSubject;
    private Timer timer;

    public OpningManager(){
    }

    public void StartOpening(){
        Debug.Log("めたん「 おくることば 」");
        Debug.Log("めたん「 ずんだもんのみなさん、おねがいします 」");

        Debug.Log("ずんだもんたち「 はぁい！ 」");
    }

}
