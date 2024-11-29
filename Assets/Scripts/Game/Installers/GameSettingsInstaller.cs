using UnityEngine;
using Zenject;

namespace Assets.Scripts.Game
{

    [CreateAssetMenu(fileName = "GameSettingsInstaller", menuName = "Installers/GameSettingsInstaller")]
    public class GameSettingsInstaller : ScriptableObjectInstaller<GameSettingsInstaller>
    {
        [SerializeField]
        private ScenesConfig _scenesConfig;

        public override void InstallBindings()
        {
            Container.BindInstance(_scenesConfig);
        }
    }
}