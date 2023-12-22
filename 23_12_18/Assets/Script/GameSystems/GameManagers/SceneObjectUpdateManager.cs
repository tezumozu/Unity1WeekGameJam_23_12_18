using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Zenject;

public abstract class SceneObjectUpdateManager : I_SceneObjectUpdatable{
    //DI
    [Inject] protected I_InputUpdatable inputManager;

    //メイン外で処理できる初期化処理
    public abstract void InitObject();

    public abstract void UpdateObject();

    public abstract void ReleaseObject();

    public abstract void GameStart();
}
