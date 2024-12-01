using System;
using System.Numerics;
using MemoryGame.Game;
using UnityEngine;
using Zenject;

namespace MemoryGame.GamePlay
{
    internal class GameFieldBuilder: IInitializable, IDisposable
    {
        private readonly GameComplexityConfig _complexityConfig;
        private readonly GamePlayModel _gamePlayModel;
        private readonly GameCardView.Factory _gameCardViewFactory;
        private readonly GameFieldSettings _gameFieldSettings;

        public GameFieldBuilder(GameComplexityConfig complexityConfig, 
                                GamePlayModel gamePlayModel, 
                                GameCardView.Factory gameCardViewFactory, 
                                GameFieldSettings gameFieldSettings)
        {
            _complexityConfig = complexityConfig;
            _gamePlayModel = gamePlayModel;
            _gameCardViewFactory = gameCardViewFactory;
            _gameFieldSettings = gameFieldSettings;
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
            var cardSize = CalculateGameCardSize();
        }

        private float CalculateGameCardSize()
        {
            var cameraHeight = Camera.main.orthographicSize * 2;
            var cameraWidth = cameraHeight * Camera.main.aspect;

            return 0;
        }
    }
}
