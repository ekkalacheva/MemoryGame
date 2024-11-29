using System;
using Assets.Scripts.Base.States;
using Assets.Scripts.Game.States;
using Zenject;

namespace Assets.Scripts.Game
{
    internal class GameStatesController: StateController, IInitializable, IDisposable
    {
        private readonly GameStatesFactory _gameStatesFactory;
        private readonly SignalBus _signals;

        public GameStatesController(GameStatesFactory gameStatesFactory,
                                    SignalBus signals)
        {
            _gameStatesFactory = gameStatesFactory;
            _signals = signals;
        }

        public void Initialize()
        {
            Subscribe();

            SetNextState(GameState.MainMenu);
        }

        public void Dispose()
        {
            Unsubscribe();
        }

        private void SetNextState(GameState gameState)
        {
            var baseState = _gameStatesFactory.GetState(gameState);
            SetState(baseState);
        }

        private void Subscribe()
        {
            _signals.Subscribe<GameSignals.StartGamePlay>(StartGamePlay);
            _signals.Subscribe<GameSignals.OpenMainMenu>(OpenMainMenu);
        }

        private void Unsubscribe()
        {
            _signals.Unsubscribe<GameSignals.StartGamePlay>(StartGamePlay);
            _signals.Unsubscribe<GameSignals.OpenMainMenu>(OpenMainMenu);
        }

        private void StartGamePlay()
        {
            SetNextState(GameState.GamePlay);
        }

        private void OpenMainMenu()
        {
            SetNextState(GameState.MainMenu);
        }
    }
}
