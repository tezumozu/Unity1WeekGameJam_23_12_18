using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingSceneObjectUpdater : SceneObjectUpdateManager{
    
    private KeyTypeGeter keyTypeGeter;

    public override void InitObject(){
        var questioner = new Questioner();
        keyTypeGeter = new KeyTypeGeter(questioner);

        keyTypeGeter.InitObject();
    }

    public override void UpdateObject(){
        keyTypeGeter.UpdateObject();
    }

    public override void ReleaseObject(){

    }
}
