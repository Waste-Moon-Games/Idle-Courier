using Entry.SceneEntryes.Gameplay;
using R3;
using UnityEngine;
using Utils.DI;

public class GameplayEntryPoint : MonoBehaviour
{
    public Observable<Unit> Run(DIContainer sceneContainer, GameplayEnterParams enterParams)
    {
        CreateGameplayScene(sceneContainer);

        return null;
    }

    private void CreateGameplayScene(DIContainer sceneContainer)
    {
        //todo распределение всех зависимостей на сцене 
    }
}