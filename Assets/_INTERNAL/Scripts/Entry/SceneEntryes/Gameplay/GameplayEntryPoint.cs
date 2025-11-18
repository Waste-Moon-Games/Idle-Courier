using Core.Controllers.Gameplay;
using Entry.SceneEntryes.Gameplay;
using Entry.SceneEntryes.MainMenu;
using R3;
using UI.Roots.MainGameRootView;
using UI.Views.GameplayView;
using UnityEngine;
using Utils.DI;

public class GameplayEntryPoint : MonoBehaviour
{
    [SerializeField] private ResourceLoader _loader;

    private UIGameplayHUDController _hudController;
    private UIGameplayPauseController _pauseController;

    public Observable<Unit> Run(DIContainer sceneContainer, GameplayEnterParams enterParams)
    {
        CreateGameplayScene(sceneContainer);

        _loader.LoadRoot(out UIRootView rootView);
        _loader.LoadGameplayUIView(out UIGameplayHUDView hudView, out UIGameplayPauseView pauseView);

        rootView.AttachUI(hudView.gameObject);
        rootView.AttachUI(pauseView.gameObject);

        _hudController = new(hudView, pauseView, enterParams.Contex);
        _pauseController = new(pauseView, enterParams.Contex);

        return null;
    }

    private void OnDestroy()
    {
        _hudController.Dispose();
        _pauseController.Dispose();
    }

    private void CreateGameplayScene(DIContainer sceneContainer)
    {
        //todo распределение всех зависимостей на сцене 
    }
}