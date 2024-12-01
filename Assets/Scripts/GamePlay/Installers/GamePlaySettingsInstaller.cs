using UnityEngine;
using Zenject;

namespace Assets.Scripts.GamePlay
{
    [CreateAssetMenu(fileName = "GamePlaySettingsInstaller", menuName = "Installers/GamePlaySettingsInstaller")]
    public class GamePlaySettingsInstaller : ScriptableObjectInstaller<GamePlaySettingsInstaller>
    {
        [SerializeField] 
        private GameCardView _gameCardPrefab;

        [SerializeField]
        private GameFieldSettings _gameFieldSettings;

        public override void InstallBindings()
        {
            Container.BindFactory<Transform, GameCardView, GameCardView.Factory>()
                .FromComponentInNewPrefab(_gameCardPrefab);

            Container.BindInstance(_gameFieldSettings).WhenInjectedInto<GameFieldBuilder>();
        }
    }
}