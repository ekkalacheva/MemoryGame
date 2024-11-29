using System;
using Assets.Scripts.Base.States;
using UnityEngine.SceneManagement;
using Zenject;

namespace Assets.Scripts.Game
{
    internal class GamePlayState: IState
    {
        private readonly ScenesConfig _scenesConfig;
        private readonly ISceneLoader _sceneLoader;

        public GamePlayState(ScenesConfig scenesConfig, 
                             ISceneLoader sceneLoader)
        {
            _scenesConfig = scenesConfig;
            _sceneLoader = sceneLoader;
        }

        public void OnEnter()
        {
            if (_sceneLoader.IsSceneLoaded(_scenesConfig.GameplaySceneName))
            {
                ShowScene();
                return;
            }

            _sceneLoader.LoadSceneAsync(_scenesConfig.GameplaySceneName, LoadSceneMode.Single, ShowScene);
        }

        public void OnExit()
        {
        }

        private void ShowScene()
        {
        }

        #region Factory

        public class Factory : PlaceholderFactory<IState>
        {
        }

        #endregion Factory
    }
}
