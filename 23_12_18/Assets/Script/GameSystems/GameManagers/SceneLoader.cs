using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class SceneLoader {
    private AsyncOperation asyncLoad;
    
    public IEnumerator LoadScene(E_SceneName sceneName){
        //シーン読み込み開始
        asyncLoad = SceneManager.LoadSceneAsync(Enum.GetName(typeof(E_SceneName),sceneName));

        asyncLoad.allowSceneActivation = false;

        while(asyncLoad.progress < 0.9f){
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }
}
