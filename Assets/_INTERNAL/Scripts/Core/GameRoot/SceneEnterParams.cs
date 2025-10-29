﻿namespace Core.GameRoot
{
    public abstract class SceneEnterParams
    {
        public string SceneName { get; }

        protected SceneEnterParams(string sceneName)
        {
            SceneName = sceneName;
        }

        public T As<T>() where T : SceneEnterParams
        {
            return (T)this;
        }
    }
}