using System;
using UnityEngine.SceneManagement;

namespace MemoryGame.Game
{
    internal interface ISceneLoader
    {
        bool IsSceneLoaded(string sceneName);
        public void LoadScene(string sceneName, LoadSceneMode loadSceneMode);
        void LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode, Action onLoaded = null, bool allowActivation = true);
        void UnloadSceneAsync(string sceneName, Action onUnloaded = null);
    }
}
