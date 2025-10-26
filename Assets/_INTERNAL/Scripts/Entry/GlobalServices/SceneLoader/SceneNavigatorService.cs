using Core.Consts;
using Entry.SceneEntryes.MainMenu;
using R3;
using System;
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

        private void LoadScene(string sceneName)
        {
            _cachedContainer = null;

            _sceneLoader.OnSceneLoaded
                .Where(loadedScene => loadedScene == sceneName)
                .Take(1)
                .Subscribe(OnSceneLoaded)
                .AddTo(_disposables);

            _sceneLoader.LoadScene(sceneName);
        }

        private void OnSceneLoaded(string sceneName)
        {
            switch (sceneName)
            {
                case SceneNames.MAIN_GAME_SCENE:
                    CreateMainGameScene();
                    break;
            }
        }

        private void CreateMainGameScene()
        {
            var sceneContainer = _cachedContainer = new(_rootContainer);
            var entryPoint = Object.FindFirstObjectByType<MainGameEntryPoint>();

            entryPoint.Run(sceneContainer).Subscribe(action =>
            {
                //todo перебор action, переход на соответствующую сцену (LoadScene(sceneName)) 
                switch (action)
                {
                    case MainGameSceneButtonActions.SomeTo:
                        Debug.Log("Переход на первую сцену");
                        break;
                    case MainGameSceneButtonActions.SecondSomeTo:
                        Debug.Log("Переход на вторую сцену");
                        break;
                }
            }).AddTo(_disposables);
        }

        //todo аналогичные CreateScene-методы для разных сцен

        public void Dispose()
        {
            _disposables.Dispose();
        }
    }
}