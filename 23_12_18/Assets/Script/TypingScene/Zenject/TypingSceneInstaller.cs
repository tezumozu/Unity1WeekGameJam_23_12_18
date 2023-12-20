using UnityEngine;
using Zenject;

public class TypingSceneInstaller : MonoInstaller{

    public override void InstallBindings(){

        //各インスタンス生成
        var sceneObjecdtUpdater = new TypingSceneObjectUpdater();
        var gameManager = new TypingSceneGameManager();
        var inputManager = new InputManager();


        //SceneObjectUpdatable
        Container
            .Bind<I_SceneObjectUpdatable>()
            .To<TypingSceneObjectUpdater>()
            .FromInstance(sceneObjecdtUpdater)
            .AsTransient();


        //GameManager
        Container
            .Bind<GameManager>()
            .To<TypingSceneGameManager>()
            .FromInstance(gameManager)
            .AsTransient();

        Container
            .Bind<I_SceneLoadAlertable>()
            .To<TypingSceneGameManager>()
            .FromInstance(gameManager)
            .AsTransient();


        //InputManager
        Container
            .Bind<I_InputUpdatable>()
            .To<InputManager>()
            .FromInstance(inputManager)
            .AsTransient();
        
        Container
            .Bind<I_InputDataAddable>()
            .To<InputManager>()
            .FromInstance(inputManager)
            .AsTransient();
    }
}