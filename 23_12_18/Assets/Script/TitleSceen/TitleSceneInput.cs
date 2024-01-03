using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TitleSceneInput : MonoBehaviour
{
    public Subject<Unit> StartGameSubject = new Subject<Unit>();

    public void Update(){ 
        if(!Input.GetKeyDown(KeyCode.Space)) return;

        StartGameSubject.OnNext(Unit.Default);
    }
}
