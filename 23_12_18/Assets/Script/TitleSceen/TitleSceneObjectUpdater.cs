using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Threading;

public class TitleSceneObjectUpdater : SceneObjectUpdateManager{

    private SynchronizationContext context;
    private TitleSceneGameManager gameManager;
    private GameObject loadingSlider;


    public TitleSceneObjectUpdater(){
        context = SynchronizationContext.Current;
    }


    public override void InitObject(GameObject loadingSlider){
        QuestionSet.SetSynchronizationContext(context);

        this.loadingSlider = loadingSlider;

        bool loadAcynk = false;

        GameLoopManager loopManager = null;
        TitleInputAction titleInputAction = null;

        //メインスレッドで実行
        context.Post( _ => {
            titleInputAction = GameObject.Find("IA_TitleInput").GetComponent<TitleInputAction>();
            loopManager = GameObject.Find("GameLoopManager").GetComponent<GameLoopManager>();

            loadAcynk = true;

        } , null );

        //ロード待ち
        while(!loadAcynk){

        }

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
