using Core.Consts;
using System;
using Utils.DI;
using Object = UnityEngine.Object;

namespace Entry.GlobalServices.SceneLoader
{
    public class SceneNavigatorService : IDisposable
    {
        private readonly SceneLoaderService _sceneLoader;
        private readonly DIContainer _rootContainer;

        private DIContainer _cachedContainer;

        public SceneNavigatorService(SceneLoaderService sceneLoader, DIContainer rootContainer)
        {
            _sceneLoader = sceneLoader;
            _rootContainer = rootContainer;
        }

        public void StartFromMainMenu()
        {
            LoadScene(SceneNames.MAIN_MENU);
        }

        private void LoadScene(string sceneName)
        {
            _cachedContainer = null;

            _sceneLoader.OnSceneLoaded += OnSceneLoaded;

            _sceneLoader.LoadScene(sceneName);
        }

        private void OnSceneLoaded(string sceneName)
        {
            switch (sceneName)
            {
                case SceneNames.MAIN_MENU:
                    CreateMainMenu();
                    break;
            }
        }

        private void CreateMainMenu()
        {
            var container = _cachedContainer = new(_rootContainer);
            var entryPoint = Object.FindFirstObjectByType<MainMenuEntryPoint>();

            entryPoint.Run(container);
        }

        public void Dispose()
        {
            _sceneLoader.OnSceneLoaded -= OnSceneLoaded;
        }
    }
}