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
        private GameFieldSettings _gameFieldSettings;

        [SerializeField]
        private GameCardSprites _gameCardSprites;

        public override void InstallBindings()
        {
            Container.BindFactory<Transform, GameCardView, GameCardView.Factory>()
                .FromComponentInNewPrefab(_gameCardPrefab);

            Container.BindInstance(_gameFieldSettings).AsSingle();
            Container.BindInstance(_gameCardSprites).WhenInjectedInto(typeof(GameCardPresenter), typeof(GameFieldBuilder));
        }
    }
}