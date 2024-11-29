using System;
using UnityEngine.SceneManagement;

namespace Assets.Scripts.Game
{
    internal interface ISceneLoader
    {
        bool IsSceneLoaded(string sceneName);
        void LoadSceneAsync(string sceneName, LoadSceneMode loadSceneMode, Action onLoaded, bool allowActivation = true);
        void UnloadSceneAsync(string sceneName, Action onUnloaded = null);
    }
}
