using Assets.Scripts.Base.States;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Game
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
                ShowScene();
                return;
            }

            _sceneLoader.LoadSceneAsync(_scenesConfig.MainMenuSceneName, LoadSceneMode.Single, ShowScene);
        }

        public void OnExit()
        {
            HideScene();
        }

        private void ShowScene()
        {
        }

        private void HideScene()
        {

        }

        #region Factory

        public class Factory : PlaceholderFactory<IState>
        {
        }

        #endregion Factory
    }
}
