using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    internal class SceneLoader: ISceneLoader
    {
        public bool IsSceneLoaded(string sceneName)
        {
            var scene = SceneManager.GetSceneByName(sceneName);
            return scene.name == sceneName;
        }

        public void LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode, Action onLoaded, bool allowActivation = true)
        {
            LoadScene(sceneName, loadSceneMode, onLoaded, allowActivation);
        }

        public void UnloadSceneAsync(string sceneName, Action onUnloaded = null)
        {
            var asyncOperation = SceneManager.UnloadSceneAsync(sceneName);
            if (onUnloaded != null)
            {
                asyncOperation.completed += _ => onUnloaded?.Invoke();
            }
        }

        private void LoadScene(string sceneName, LoadSceneMode loadSceneMode, Action onLoaded, bool allowActivation = true)
        {
            AsyncOperation async = SceneManager.LoadSceneAsync(sceneName, loadSceneMode);

            if (onLoaded != null)
            {
                async.completed += _ => onLoaded?.Invoke();
            }

            async.allowSceneActivation = allowActivation;
        }
    }
}
