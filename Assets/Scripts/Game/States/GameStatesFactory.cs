using MemoryGame.Base.States;
using MemoryGame.Game.States;

namespace MemoryGame.Game
{
    internal class GameStatesFactory
    {
        private readonly MainMenuState.Factory _mainMenuStateFactory;
        private readonly GamePlayState.Factory _gamePlayStateFactory;

        public GameStatesFactory(MainMenuState.Factory mainMenuStateFactory,
                                 GamePlayState.Factory gamePlayStateFactory)
        {
            _mainMenuStateFactory = mainMenuStateFactory;
            _gamePlayStateFactory = gamePlayStateFactory;
        }

        public IState GetState(GameState gameState)
        {
            switch (gameState)
            {
                case (GameState.MainMenu):
                    return _mainMenuStateFactory.Create();

                case (GameState.GamePlay):
                    return _gamePlayStateFactory.Create();
            }
            return null;
        }
    }
}
