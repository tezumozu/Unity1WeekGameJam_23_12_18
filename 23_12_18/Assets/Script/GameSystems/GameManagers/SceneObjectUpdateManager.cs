using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

public abstract class SceneObjectUpdateManager : I_SceneObjectUpdatable{
    //DI
    [Inject] protected GameManager gameManager;
    [Inject] protected I_InputUpdatable inputManager;
    

    public abstract void InitObject();

    public abstract void UpdateObject();

    public abstract void ReleaseObject();
}
