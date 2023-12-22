using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingSceneObjectUpdater : SceneObjectUpdateManager{
    
    private TypingSceneGameManager gameManager;

    private Questioner questioner;
    private OpningManager opningManager;
    private EndingManager endingManager;
    private ResultManager resultManager;

    private KeyTypeGeter keyTypeGeter;
    private AnswerEffectManager AnswerEffectManager;
    private Timer timer;

    private SynchronizationContext context;

    public TypingSceneObjectUpdater (){
        context = SynchronizationContext.Current;
    }

    public override void InitObject(){//ローディング画面のためにマルチスレッドで実行される
        QuestionSet.SetSynchronizationContext(context);

        bool loadAcynk = false;

        //メインスレッドで実行
        context.Post(() => {
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            effectManager = GameObject.Find("EffectManager").GetComponent<EffectManager>();

            loadAcynk = true;
        });

        //ロード待ち
        while(!loadAcynk){

        }

        gameManager = new TypingSceneGameManager();
        
        opningManager = new OpningManager();
        resultManager = new ResultManager();
        endingManager = new EndingManager();
        questioner = new Questioner();

        keyTypeGeter = new KeyTypeGeter();
        AnswerEffectManager = new AnswerEffectManager();
        

        //各マネージャの初期化
        gameManager.InitObject( questioner , opningManager , endingManager , resultManager);

        opningManager.InitObject();
        resultManager.InitObject();
        endingManager.InitObject();
        questioner.InitObject(keyTypeGeter , timer , AnswerEffectManager , context);

        keyTypeGeter.InitObject();
        AnswerEffectManager.InitObject();


        //シーンロード時にローディング画面を表示
        gameManager.ObserveSceneLoadAlert(()=>{
            //ロード画面表示
        });
        
    }

    public override async void UpdateObject(){

        switch (gameManager.currentGameMode){
            case E_GameMode.TYPING_PLAY_INGAME:
                //キー入力を受け取る
                keyTypeGeter.UpdateObject();
            break;
            
            case E_GameMode.TYPING_Result:
                //入力を受け取る
                inputManager.UpdateManager();
            break;
        }
    }

    public override void ReleaseObject(){

    }

    //ゲームを開始する
    public override void GameStart(){
        //ロード画面非表示にする

        //オープニング開始
        opningManager.StartOpening();
    }
}
