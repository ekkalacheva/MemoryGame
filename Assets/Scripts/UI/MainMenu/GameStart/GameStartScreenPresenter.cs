using MemoryGame.Base.View;
using MemoryGame.Game;
using Zenject;

namespace MemoryGame.UI.MainMenu
{
    internal class GameStartScreenPresenter: IPresenter
    {
        private readonly IGameStartScreenView _view;
        private readonly GamePlayModel _gamePlayModel;
        private readonly SignalBus _signals;

        public GameStartScreenPresenter(IGameStartScreenView view,
                                        GamePlayModel gamePlayModel,
                                        SignalBus signals)
        {
            _view = view;
            _gamePlayModel = gamePlayModel;
            _signals = signals;
        }

        public void Initialize()
        {
            _view.GameComplexityButtonClicked += StartGame;
        }

        public void UnInitialize()
        {
            _view.GameComplexityButtonClicked -= StartGame;
        }

        private void StartGame(GameComplexity complexity)
        {
            _gamePlayModel.Complexity = complexity;
            _signals.TryFire<GameSignals.StartGamePlay>();
        }

        #region Factory

        public class Factory : PlaceholderFactory<IGameStartScreenView, GameStartScreenPresenter>
        {
        }

        #endregion
    }
}
