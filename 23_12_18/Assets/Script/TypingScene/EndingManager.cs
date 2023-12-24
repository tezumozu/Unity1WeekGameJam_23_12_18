using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class EndingManager{
    public Subject<Unit> FinishEndingSubject;

    public EndingManager(){
        FinishEndingSubject = new Subject<Unit>();
    }

    public void InitObject(){
    }

    public void StartEnding(){
        Debug.Log("めたん「 ずんだもんのみなさんありがとうございました 」");
        Debug.Log("めたん「 これにて第1回 ずんだもん卒業式は閉式といたします」");
        Debug.Log("めたん「 皆様ご起立ください 」");

        FinishEndingSubject.OnNext(Unit.Default);
    }
}
