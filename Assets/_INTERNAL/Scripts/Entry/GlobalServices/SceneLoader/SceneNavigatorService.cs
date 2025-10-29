using Core.Consts;
using Core.GameRoot;
using Entry.SceneEntryes.Gameplay;
using Entry.SceneEntryes.MainMenu;
using R3;
using System;
using System.ComponentModel.DataAnnotations;
using UI.Views.MainGameViews;
using UnityEngine;
using Utils.DI;
using Object = UnityEngine.Object;

namespace Entry.GlobalServices.SceneLoader
{
    public class SceneNavigatorService : IDisposable
    {
        private readonly SceneLoaderService _sceneLoader;
        private readonly DIContainer _rootContainer;
        private readonly CompositeDisposable _disposables = new();

        private DIContainer _cachedContainer;

        public SceneNavigatorService(SceneLoaderService sceneLoader, DIContainer rootContainer)
        {
            _sceneLoader = sceneLoader;
            _rootContainer = rootContainer;
        }

        public void StartFromMainMenu()
        {
            LoadScene(SceneNames.MAIN_GAME_SCENE);
        }

        private void LoadScene(string sceneName, SceneEnterParams enterParams = null)
        {
            _cachedContainer?.Dispose();

            _sceneLoader.OnSceneLoaded
                .Where(loadedScene => loadedScene == sceneName)
                .Take(1)
                .Subscribe(sceneName => OnSceneLoaded(sceneName, enterParams))
                .AddTo(_disposables);

            _sceneLoader.LoadScene(sceneName);
        }

        private void OnSceneLoaded(string sceneName, SceneEnterParams enterParams = null)
        {
            switch (sceneName)
            {
                case SceneNames.MAIN_GAME_SCENE:
                    CreateMainGameScene();
                    break;
                case SceneNames.GAMEPLAY_SCENE:
                    CreateGameplayScene(enterParams.As<GameplayEnterParams>());
                    break;
            }
        }

        private void CreateMainGameScene()
        {
            var sceneContainer = _cachedContainer = new(_rootContainer);
            var entryPoint = Object.FindFirstObjectByType<MainGameEntryPoint>();

            entryPoint.Run(sceneContainer).Subscribe(mainGameExitParams =>
            {
                string targetSceneName = mainGameExitParams.TargetSceneEnterParams.SceneName;

                if (targetSceneName == SceneNames.GAMEPLAY_SCENE)
                    LoadScene(targetSceneName, mainGameExitParams.TargetSceneEnterParams);
            }).AddTo(_disposables);
        }

        private void CreateGameplayScene(GameplayEnterParams enterParams = null)
        {
            var sceneContainer = _cachedContainer = new(_rootContainer);
            var entryPoint = Object.FindFirstObjectByType<GameplayEntryPoint>();

            entryPoint.Run(sceneContainer, enterParams);
        }

        //todo аналогичные CreateScene-методы для разных сцен

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}