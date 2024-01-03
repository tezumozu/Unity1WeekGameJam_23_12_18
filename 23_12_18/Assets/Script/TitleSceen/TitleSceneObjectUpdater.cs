using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;

public class TitleSceneObjectUpdater : SceneObjectUpdateManager{
    
    private TitleSceneGameManager gameManager;
    private GameObject loadingSlider;


    public TitleSceneObjectUpdater(){
    }


    public override void InitObject(GameObject loadingSlider){

        this.loadingSlider = loadingSlider;

        GameLoopManager loopManager = null;
        TitleSceneInput titleInputAction = null;

        titleInputAction = GameObject.Find("IA_TitleInput").GetComponent<TitleSceneInput>();
        loopManager = GameObject.Find("GameLoopManager").GetComponent<GameLoopManager>();

        gameManager = new TitleSceneGameManager();

        gameManager.InitObject(titleInputAction);
        loopManager.OnInitialize(gameManager);

        //シーンロード時にローディング画面を表示
        gameManager.ObserveSceneLoadAlert( _ => {
            //ロード画面表示
            loadingSlider.SetActive(true);
        });
    }


    public override void UpdateObject(){
        
    }


    public override void ReleaseObject(){

    }

    public override void GameStart(){
        //ロード画面非表示
    }
}
