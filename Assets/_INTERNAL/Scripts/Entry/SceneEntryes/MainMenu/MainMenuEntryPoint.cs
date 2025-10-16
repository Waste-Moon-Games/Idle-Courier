using UnityEngine;
using Utils.DI;

public class MainMenuEntryPoint : MonoBehaviour
{
    public void Run(DIContainer rootContainer)
    {
        DIContainer sceneContainer = new(rootContainer);
    }
}
