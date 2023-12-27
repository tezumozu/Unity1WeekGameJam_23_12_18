using UnityEngine;
using Zenject;

public class TitleSceneInstller : MonoInstaller
{
    public override void InstallBindings(){
        //各インスタンス生成
        var sceneObjecdtUpdater = new TitleSceneObjectUpdater();
        var gameManager = new TitleSceneGameManager();
        var inputManager = new InputManager();

        //SceneObjectUpdatable
        Container
            .Bind<I_SceneObjectUpdatable>()
            .To<TitleSceneObjectUpdater>()
            .FromInstance(sceneObjecdtUpdater)
            .AsTransient();


        //GameManager
        Container
            .Bind<GameManager>()
            .To<TitleSceneGameManager>()
            .FromInstance(gameManager)
            .AsTransient();

        Container
            .Bind<I_SceneLoadAlertable>()
            .To<TitleSceneGameManager>()
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