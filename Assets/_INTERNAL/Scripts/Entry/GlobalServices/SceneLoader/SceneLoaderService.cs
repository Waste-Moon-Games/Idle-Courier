using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils.ModCoroutines;

namespace Entry.GlobalServices.SceneLoader
{
    public class SceneLoaderService
    {
        private readonly UILoadingScreen _loadindScreen;
        private readonly Coroutines _coroutine;

        public event Action<float> OnProgressUpdated;

        public event Action<string> OnSceneLoaded;

        public SceneLoaderService(UILoadingScreen loadindScreen, Coroutines coroutine)
        {
            _loadindScreen = loadindScreen;
            _coroutine = coroutine;
        }

        public void LoadScene(string sceneName)
        {
            _coroutine.StartRoutine(LoadSceneRoutine(sceneName));
        }

        private IEnumerator LoadSceneRoutine(string sceneName)
        {
            _loadindScreen.ShowLoadingScreen();

            AsyncOperation asyncOp = SceneManager.LoadSceneAsync(sceneName);
            asyncOp.allowSceneActivation = true;

            while (!asyncOp.isDone)
            {
                _loadindScreen.SetLoadingProgress(asyncOp.progress / 0.9f);
                OnProgressUpdated?.Invoke(asyncOp.progress / 0.9f);
                yield return null;
            }

            _loadindScreen.HideLoadingScreen();

            OnSceneLoaded?.Invoke(sceneName);
        }
    }
}