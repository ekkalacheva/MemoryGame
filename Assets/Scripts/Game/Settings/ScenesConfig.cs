using System;
using UnityEngine;

namespace Assets.Scripts.Game
{
    [Serializable]
    internal class ScenesConfig
    {
        [SerializeField]
        private string _mainMenuSceneName;

        [SerializeField]
        private string _gameplaySceneName;

        public string MainMenuSceneName => _mainMenuSceneName;

        public string GameplaySceneName => _gameplaySceneName;
    }
}
