using MemoryGame.Base.View;
using MemoryGame.Game;
using Zenject;

namespace MemoryGame.UI.GamePlay
{
    internal class GamePlayHudPresenter: IPresenter
    {
        private readonly IGamePlayHudView _view;
        private readonly SignalBus _signals;

        public GamePlayHudPresenter(IGamePlayHudView view, 
                                    SignalBus signals)
        {
            _view = view;
            _signals = signals;
        }

        public void Initialize()
        {
            _view.BackButtonClicked += OpenMainMenu;
            _view.RestartButtonClicked += RestartGame;
        }

        public void UnInitialize()
        {
            _view.BackButtonClicked -= OpenMainMenu;
            _view.RestartButtonClicked -= RestartGame;
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
