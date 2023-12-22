using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface I_SceneObjectUpdatable {
    
    public void InitObject();

    public void UpdateObject();

    public void ReleaseObject();

    public void GameStart();
}
