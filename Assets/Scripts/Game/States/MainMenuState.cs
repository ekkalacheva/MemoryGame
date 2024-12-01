using MemoryGame.Base.States;
using UnityEngine.SceneManagement;
using Zenject;

namespace MemoryGame.Game
{
    internal class MainMenuState: IState
    {
        private readonly ScenesConfig _scenesConfig;
        private readonly ISceneLoader _sceneLoader;

        public MainMenuState(ScenesConfig scenesConfig,
                             ISceneLoader sceneLoader)
        {
            _scenesConfig = scenesConfig;
            _sceneLoader = sceneLoader;
        }

        public void OnEnter()
        {
            if (_sceneLoader.IsSceneLoaded(_scenesConfig.MainMenuSceneName))
            {
                return;
            }

            _sceneLoader.LoadScene(_scenesConfig.MainMenuSceneName, LoadSceneMode.Single);
        }

        public void OnExit()
        {
        }

        #region Factory

        public class Factory : PlaceholderFactory<IState>
        {
        }

        #endregion Factory
    }
}
