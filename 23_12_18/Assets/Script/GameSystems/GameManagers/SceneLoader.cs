using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;

public class SceneLoader {
    private AsyncOperation asyncLoad;
    private Slider loadingSlider;
    private float time;

    //演出としてローディングの時間を一定時間確保する
    private float loadingDilay;

    public SceneLoader(GameObject loadingSliderObject){
        loadingSlider = loadingSliderObject.GetComponent<Slider>();
        loadingSlider.value = 0;
        time = 0;
        loadingDilay = 2.0f;
    }
    
    public IEnumerator LoadScene(E_SceneName sceneName){
        //シーン読み込み開始
        asyncLoad = SceneManager.LoadSceneAsync(Enum.GetName(typeof(E_SceneName),sceneName));

        asyncLoad.allowSceneActivation = false;

        while( asyncLoad.progress < 0.9f || time < loadingDilay ){
            time += Time.deltaTime;
            loadingSlider.value = asyncLoad.progress * (time / loadingDilay) + 0.1f;
            yield return null;
        }

        asyncLoad.allowSceneActivation = true;
    }
}
