using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UniRx;

public class TypingSceneGameManager : GameManager{
    public E_GameMode currentGameMode {get; private set;}

    public void InitObject(OpningManager opningManager , Questioner questioner , EndingManager endingManager , ResultManager resultManager){
        currentGameMode = E_GameMode.TYPING_OPNING;


        //オープニングの終了待ち
        opningManager.FinishOpningSubject.Subscribe( _ => {
            currentGameMode = E_GameMode.TYPING_QUESTION;
            questioner.StartQuestion();
        });


        //クイズの終了待ち
        questioner.AllFinishQuestionSubject.Subscribe( _ =>{
            currentGameMode = E_GameMode.TYPING_ENDING;
            endingManager.StartEnding();
        });


        //エンディングの終了待ち
        endingManager.FinishEndingSubject.Subscribe( _ =>{
            currentGameMode = E_GameMode.TYPING_RESULT;
            resultManager.StartResult();
        });


        //リザルトの終了待ち
        resultManager.FinishResultSubject.Subscribe( _ =>{
            SceneLoadAlertSubject.OnNext(E_SceneName.TitleScene);
        });
    }
}
