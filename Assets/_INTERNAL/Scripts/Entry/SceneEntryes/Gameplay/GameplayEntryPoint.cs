using UnityEngine;
using Utils.DI;

public class GameplayEntryPoint : MonoBehaviour
{
    public void Run(DIContainer sceneContainer)
    {
        CreateGameplayScene(sceneContainer);
    }

    private void CreateGameplayScene(DIContainer sceneContainer)
    {
        //todo распределение всех зависимостей на сцене 
    }
}