using System;
using Assets.Scripts.Game;
using Zenject;

namespace Assets.Scripts.GamePlay
{
    internal class GameFieldBuilder: IInitializable, IDisposable
    {
        private readonly GameComplexityConfig _complexityConfig;
        private readonly GamePlayModel _gamePlayModel;
        private readonly GameCardView.Factory _gameCardViewFactory;

        public GameFieldBuilder(GameComplexityConfig complexityConfig, 
                                GamePlayModel gamePlayModel, 
                                GameCardView.Factory gameCardViewFactory)
        {
            _complexityConfig = complexityConfig;
            _gamePlayModel = gamePlayModel;
            _gameCardViewFactory = gameCardViewFactory;
        }

        public void Initialize()
        {
            CreateGameField();
        }

        public void Dispose()
        {

        }

        private void CreateGameField()
        {

        }
    }
}
