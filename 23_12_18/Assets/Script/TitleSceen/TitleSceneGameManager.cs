using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TitleSceneGameManager : GameManager{
    public void InitObject(TitleInputAction titleInputAction){
        titleInputAction.StartGameSubject.Subscribe(_=>{
            SceneLoadAlertSubject.OnNext(E_SceneName.TypingScene);
        });
    }
}
