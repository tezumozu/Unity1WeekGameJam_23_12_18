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

    public void InputExit(InputAction.CallbackContext context){ 
        if(!(context.phase == InputActionPhase.Performed)) return;

        if (gameManager.currentGameMode == E_GameMode.TYPING_RESULT){
            ResultExitSubject.OnNext(Unit.Default);
        }
    }
}
