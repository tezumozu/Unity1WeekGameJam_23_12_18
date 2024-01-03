using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UniRx;

public class ResultInputAction : MonoBehaviour{
    public Subject<Unit> ResultExitSubject = new Subject<Unit>();
    TypingSceneGameManager gameManager;

    public void InitObject(TypingSceneGameManager gameManager){
        this.gameManager = gameManager;
    }

    public void Update(){ 
        if(!Input.GetKeyDown(KeyCode.Space)) return;

        if (gameManager.currentGameMode == E_GameMode.TYPING_RESULT){
            ResultExitSubject.OnNext(Unit.Default);
        }
    }
}
