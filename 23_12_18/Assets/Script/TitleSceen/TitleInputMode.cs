using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.InputSystem;
using UniRx;

public class TitleInputAction : MonoBehaviour{
    public Subject<Unit> StartGameSubject = new Subject<Unit>();

    public void StartGameInput(InputAction.CallbackContext context){ 
        if(!(context.phase == InputActionPhase.Performed)) return;

        StartGameSubject.OnNext(Unit.Default);
    }
}
