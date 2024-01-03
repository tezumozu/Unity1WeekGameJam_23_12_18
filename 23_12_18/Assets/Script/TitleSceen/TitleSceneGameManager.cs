using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TitleSceneGameManager : GameManager{
    public void InitObject(TitleSceneInput titleInputAction){
        titleInputAction.StartGameSubject.Subscribe(_=>{
            SceneLoadAlertSubject.OnNext(E_SceneName.TypingScene);
        });
    }
}
