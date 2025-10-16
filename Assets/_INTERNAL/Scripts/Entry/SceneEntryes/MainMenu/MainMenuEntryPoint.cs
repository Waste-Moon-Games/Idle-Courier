using Core.StageFactory;
using Core.StateMachine;
using UnityEngine;
using Utils.DI;

public class MainMenuEntryPoint : MonoBehaviour
{
    [SerializeField] private Example _examplePrefab;

    public void Run(DIContainer rootContainer)
    {
        DIContainer sceneContainer = new(rootContainer);
        Example example = Instantiate(_examplePrefab);
        sceneContainer.RegisterFactory<Factory>(f => new(example));

        StageController sc = new(sceneContainer.Resolve<Factory>());
        sc.StartCycle();
    }
}
