using MemoryGame.Utils;
using UnityEngine;
using Zenject;

namespace MemoryGame.GamePlay
{
    [CreateAssetMenu(fileName = "GamePlaySettingsInstaller", menuName = "Installers/GamePlaySettingsInstaller")]
    public class GamePlaySettingsInstaller : ScriptableObjectInstaller<GamePlaySettingsInstaller>
    {
        [SerializeField] 
        private GameCardView _gameCardPrefab;

        [SerializeField]
        private GameFieldSettings _gameFieldSettingsPhone;

        [SerializeField]
        private GameFieldSettings _gameFieldSettingsTablet;

        [SerializeField]
        private GameCardSprites _gameCardSprites;

        public override void InstallBindings()
        {
            Container.BindMemoryPool<GameCardView, GameCardView.Pool>()
                .FromComponentInNewPrefab(_gameCardPrefab)
                .UnderTransformGroup("GameCardsPool");

            Container.BindInstance(DeviceUtils.IsTablet ? _gameFieldSettingsTablet : _gameFieldSettingsPhone).AsSingle();
            Container.BindInstance(_gameCardSprites).WhenInjectedInto(typeof(GameCardPresenter), typeof(GameFieldBuilder));
        }
    }
}