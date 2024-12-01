using Zenject;

namespace MemoryGame.GamePlay
{
    public class GamePlayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameField();
        }

        private void InstallGameField()
        {
            Container.BindInterfacesAndSelfTo<GameFieldBuilder>().AsSingle();

            Container.BindFactory<IGameCardView, GameCardPresenter, GameCardPresenter.Factory>()
                .To<GameCardPresenter>()
                .WhenInjectedInto<GameCardView>();
        }
    }
}