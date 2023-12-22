using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public abstract class  GameManager : I_SceneLoadAlertable , I_GameModeChangeAlertable{
    protected Subject<E_SceneName> SceneLoadAlertSubject;
    protected Subject<E_GameMode> GameModeChangeAlertSubject;

    public GameManager (){
        SceneLoadAlertSubject = new Subject<E_SceneName>();
        GameModeChangeAlertSubject = new Subject<E_GameMode>();
    }

    public void ObserveSceneLoadAlert(Action<E_SceneName> action){
        SceneLoadAlertSubject.Subscribe( sceneName => {
            action(sceneName);
        });
    }

    public void ObserveGameModeChange(Action<E_GameMode> action){
       GameModeChangeAlertSubject.Subscribe( nextMode => {
            action(nextMode);
        });
    }
}
