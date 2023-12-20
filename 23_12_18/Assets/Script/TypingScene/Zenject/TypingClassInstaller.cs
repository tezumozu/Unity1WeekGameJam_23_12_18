using UnityEngine;
using Zenject;

public class TypingClassInstaller : MonoInstaller
{
    public override void InstallBindings(){
        Container
            .Bind<I_SpelCheckable>()
            .To<Questioner>()
            .AsSingle();
    }
}