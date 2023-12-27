using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingSceneObjectUpdater : SceneObjectUpdateManager{
    
    private TypingSceneGameManager gameManager;
    private GameObject loadingSlider;

    private Questioner questioner;
    private OpningManager opningManager;
    private EndingManager endingManager;
    private ResultManager resultManager;

    ResultInputAction resultInputAction;

    private KeyTypeGetter keyTypeGetter;
    private AnswerEffectManager answerEffectManager;
    private Timer timer;

    private SynchronizationContext context;

    public TypingSceneObjectUpdater (){
        context = SynchronizationContext.Current;
    }

    public override void InitObject(GameObject loadingSlider){//ローディング画面のためにマルチスレッドで実行される

        QuestionSet.SetSynchronizationContext(context);
        this.loadingSlider = loadingSlider;

        bool loadAcynk = false;

        GameLoopManager loopManager = null;

        //メインスレッドで実行
        context.Post( _ => {
            timer = GameObject.Find("Timer").GetComponent<Timer>();
            answerEffectManager = GameObject.Find("AnswerEffectManager").GetComponent<AnswerEffectManager>();
            resultInputAction = GameObject.Find("IA_Result").GetComponent<ResultInputAction>();
            loopManager = GameObject.Find("GameLoopManager").GetComponent<GameLoopManager>();

            loadAcynk = true;

        } , null );

        //ロード待ち
        while(!loadAcynk){

        }

        gameManager = new TypingSceneGameManager();
        
        opningManager = new OpningManager();
        resultManager = new ResultManager();
        endingManager = new EndingManager();
        questioner = new Questioner();

        keyTypeGetter = new KeyTypeGetter();

        var scoerManager = new ScoerManager();

        loopManager.OnInitialize(gameManager);

        //各マネージャの初期化
        gameManager.InitObject( opningManager , questioner , endingManager , resultManager);

        opningManager.InitObject();
        resultManager.InitObject(scoerManager,resultInputAction);
        endingManager.InitObject();
        questioner.InitObject(answerEffectManager,keyTypeGetter,scoerManager,timer);

        keyTypeGetter.InitObject();
        answerEffectManager.InitObject();
        scoerManager.InitObject();
        resultInputAction.InitObject(gameManager);


        //シーンロード時にローディング画面を表示
        gameManager.ObserveSceneLoadAlert( _ => {
            //ロード画面表示
            loadingSlider.SetActive(true);
        });
        
    }

    public override void UpdateObject(){

        switch (gameManager.currentGameMode){
            case E_GameMode.TYPING_QUESTION:
                //キー入力を受け取る
                keyTypeGetter.GetKeyType();
            break;
            
            case E_GameMode.TYPING_RESULT:
                //入力を受け取る
                //inputManager.UpdateInput();
            break;
        }
    }

    public override void ReleaseObject(){

    }

    //ゲームを開始する
    public override void GameStart(){
        //オープニング開始
        opningManager.StartOpening();
    }
}
