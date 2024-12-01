using System;
using MemoryGame.Base.States;
using Zenject;

namespace MemoryGame.Game
{
    public class GameInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            InstallModel();
            InstallScenesLoading();
            InstallStates();
            InstallSignals();
        }

        private void InstallModel()
        {
            Container.Bind<GamePlayModel>().ToSelf().AsSingle();
        }

        private void InstallStates()
        {
            Container.Bind(typeof(IInitializable), typeof(IDisposable))
                .To<GameStatesController>()
                .AsSingle();

            Container.BindFactory<IState, MainMenuState.Factory>()
                .To<MainMenuState>()
                .WhenInjectedInto<GameStatesFactory>();

            Container.BindFactory<IState, GamePlayState.Factory>()
                .To<GamePlayState>()
                .WhenInjectedInto<GameStatesFactory>();

            Container.Bind<GameStatesFactory>().ToSelf().AsSingle();
        }

        private void InstallScenesLoading()
        {
            Container.Bind<ISceneLoader>().To<SceneLoader>().AsSingle();
        }

        private void InstallSignals()
        {
            SignalBusInstaller.Install(Container);

            Container.DeclareSignal<GameSignals.StartGamePlay>().OptionalSubscriber();
            Container.DeclareSignal<GameSignals.OpenMainMenu>().OptionalSubscriber();
        }
    }
}