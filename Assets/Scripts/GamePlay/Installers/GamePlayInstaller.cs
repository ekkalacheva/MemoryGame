using Zenject;

namespace MemoryGame.GamePlay
{
    public class GamePlayInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallGameField();
            InstallSignals();
        }

        private void InstallGameField()
        {
            Container.BindInterfacesAndSelfTo<GameFieldBuilder>().AsSingle();
            Container.BindInterfacesAndSelfTo<GameCardsHandler>().AsSingle();

            Container.BindFactory<IGameCardView, GameCardPresenter, GameCardPresenter.Factory>()
                .To<GameCardPresenter>()
                .WhenInjectedInto<GameCardView>();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<GamePlaySignals.CardClicked>().OptionalSubscriber();
            Container.DeclareSignal<GamePlaySignals.GameCompleted>().OptionalSubscriber();
        }
    }
}