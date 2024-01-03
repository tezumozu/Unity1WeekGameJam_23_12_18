using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingSceneObjectUpdater : SceneObjectUpdateManager{
    
    private TypingSceneGameManager gameManager;
    private GameObject loadingSlider;

    private Questioner questioner;
    private OpeningManager openingManager;
    private EndingManager endingManager;
    private ResultManager resultManager;

    ResultInputAction resultInputAction;

    private KeyTypeGetter keyTypeGetter;
    private AnswerEffectManager answerEffectManager;
    private Timer timer;


    public TypingSceneObjectUpdater (){

    }

    public override void InitObject(GameObject loadingSlider){//ローディング画面のためにマルチスレッドで実行される

        this.loadingSlider = loadingSlider;

        GameLoopManager loopManager = null;
        QuestionEffectManager questionEffectManager = null;
        ScoreManager ScoreManager = null;

        timer = GameObject.Find("Timer").GetComponent<Timer>();
        answerEffectManager = GameObject.Find("AnswerEffectManager").GetComponent<AnswerEffectManager>();
        questionEffectManager = GameObject.Find("QuestionEffectManager").GetComponent<QuestionEffectManager>();
        resultInputAction = GameObject.Find("IA_Result").GetComponent<ResultInputAction>();
        loopManager = GameObject.Find("GameLoopManager").GetComponent<GameLoopManager>();
        openingManager = GameObject.Find("OpeningManager").GetComponent<OpeningManager>();
        endingManager = GameObject.Find("EndingManager").GetComponent<EndingManager>();
        resultManager = GameObject.Find("ResultManager").GetComponent<ResultManager>();
        ScoreManager = GameObject.Find("ScoreManager").GetComponent<ScoreManager>();


        gameManager = new TypingSceneGameManager();
        questioner = new Questioner();

        keyTypeGetter = new KeyTypeGetter();

        loopManager.OnInitialize(gameManager);

        //各マネージャの初期化
        gameManager.InitObject( openingManager , questioner , endingManager , resultManager);

        openingManager.InitObject();
        resultManager.InitObject(ScoreManager,resultInputAction);
        endingManager.InitObject();
        questioner.InitObject(questionEffectManager,answerEffectManager,keyTypeGetter,ScoreManager,timer);

        keyTypeGetter.InitObject();
        answerEffectManager.InitObject();
        ScoreManager.InitObject();
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
        openingManager.StartOpening();
    }
}
