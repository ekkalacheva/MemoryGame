using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{

    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField]
        private ScenesConfig _scenesConfig;

        [SerializeField]
        private GameComplexityConfig _gameComplexityConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_scenesConfig);
            Container.BindInstance(_gameComplexityConfig);
        }
    }
}