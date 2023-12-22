using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TypingSceneGameManager : GameManager{
    public E_GameMode currentGameMode {get; private set;}

    public void InitObject(OpningManager opningManager , Questioner questioner , EndingManager endingManager , ResultManager resultManager){
        currentGameMode = E_GameMode.TYPING_OPNING;


        //オープニングの終了待ち
        opningManager.FinishOpningSubject.Subscribe(()=>{
            questioner.StartQuestion();
        });


        //クイズの終了待ち
        questioner.AllFinishQuestionSubject.Subscribe(()=>{
            endingManager.StartEnding();
        });


        //エンディングの終了待ち
        endingManager.AllFinishQuestionSubject.Subscribe(()=>{
            resultManager.StartResult();
        });


        //リザルトの終了待ち
        resultManager.FinishResultSubject.Subscribe(()=>{
            SceneLoadAlertSubject.OnNext(E_SceneName.TitleScene);
        });
    }
}
