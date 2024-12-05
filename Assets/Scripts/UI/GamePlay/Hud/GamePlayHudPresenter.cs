using MemoryGame.Base.View;
using MemoryGame.Game;
using MemoryGame.GamePlay;
using UnityEngine;
using Zenject;

namespace MemoryGame.UI.GamePlay
{
    internal class GamePlayHudPresenter: IPresenter
    {
        private readonly IGamePlayHudView _view;
        private readonly SignalBus _signals;
        private readonly IGamePlayTimer _gamePlayTimer;

        public GamePlayHudPresenter(IGamePlayHudView view, 
                                    SignalBus signals,
                                    IGamePlayTimer gamePlayTimer)
        {
            _view = view;
            _signals = signals;
            _gamePlayTimer = gamePlayTimer;
        }

        public void Initialize()
        {
            _view.BackButtonClicked += OpenMainMenu;
            _view.RestartButtonClicked += RestartGame;
            _gamePlayTimer.TimeChanged += UpdateTime;
            _signals.Subscribe<GamePlaySignals.GameStarted>(OnGameStarted);
            _signals.Subscribe<GamePlaySignals.GameCompleted>(OnGameCompleted);
        }

        public void UnInitialize()
        {
            _view.BackButtonClicked -= OpenMainMenu;
            _view.RestartButtonClicked -= RestartGame;
            _gamePlayTimer.TimeChanged -= UpdateTime;
            _signals.Unsubscribe<GamePlaySignals.GameStarted>(OnGameStarted);
            _signals.Unsubscribe<GamePlaySignals.GameCompleted>(OnGameCompleted);
        }

        private void OnGameStarted()
        {
            _view.SetTimeState(true);
        }

        private void OnGameCompleted()
        {
            _view.SetTimeState(false);
        }

        private void UpdateTime()
        {
            _view.SetTime(_gamePlayTimer.ElapsedSeconds);
        }

        private void OpenMainMenu()
        {
            _signals.TryFire<GameSignals.OpenMainMenu>();
        }

        private void RestartGame()
        {
            throw new System.NotImplementedException();
        }

        #region Factory

        public class Factory : PlaceholderFactory<IGamePlayHudView, GamePlayHudPresenter>
        {
        }

        #endregion
    }
}
