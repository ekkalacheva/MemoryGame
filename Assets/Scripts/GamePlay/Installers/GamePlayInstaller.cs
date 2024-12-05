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
            Container.BindInterfacesAndSelfTo<GamePlayTimer>().AsSingle();

            Container.BindFactory<IGameCardView, GameCardPresenter, GameCardPresenter.Factory>()
                .To<GameCardPresenter>()
                .WhenInjectedInto<GameCardView>();
        }

        private void InstallSignals()
        {
            Container.DeclareSignal<GamePlaySignals.CardClicked>().OptionalSubscriber();
            Container.DeclareSignal<GamePlaySignals.GameStarted>().OptionalSubscriber();
            Container.DeclareSignal<GamePlaySignals.GameCompleted>().OptionalSubscriber();
            Container.DeclareSignal<GamePlaySignals.RestartGame>().OptionalSubscriber();
        }
    }
}