using System;
using System.Collections.Generic;
using MemoryGame.Game;
using ModestTree;
using UnityEngine;
using Zenject;
using Random = UnityEngine.Random;

namespace MemoryGame.GamePlay
{
    internal class GameFieldBuilder: IInitializable, IDisposable
    {
        private readonly GameComplexityConfig _complexityConfig;
        private readonly GamePlayModel _gamePlayModel;
        private readonly GameFieldOffsets _gameFieldSettings;
        private readonly Transform _cardsContainer;
        private readonly int _availableCardsAmount;
        private readonly GameCardView.Pool _gameCardsPool;
        private readonly SignalBus _signals;

        private List<GameCardView> _cardViews;
        
        public GameFieldBuilder(GameComplexityConfig complexityConfig, 
                                GamePlayModel gamePlayModel, 
                                GameFieldSettings gameFieldSettings,
                                [Inject(Id = "GameCardsContainer")] Transform cardsContainer,
                                GameCardSprites gameCardSprites,
                                GameCardView.Pool gameCardsPool,
                                SignalBus signals)
        {
            _complexityConfig = complexityConfig;
            _gamePlayModel = gamePlayModel;
            _gameFieldSettings = gameFieldSettings.GetFieldSettings(_gamePlayModel.Complexity);
            _cardsContainer = cardsContainer;
            _availableCardsAmount = gameCardSprites.Faces.Length;
            _gameCardsPool = gameCardsPool;
            _signals = signals;
        }

        public void Initialize()
        {
            _signals.Subscribe<GamePlaySignals.RestartGame>(RestartGame);

            CreateGameField();
        }

        public void Dispose()
        {
            _signals.Unsubscribe<GamePlaySignals.RestartGame>(RestartGame);
        }

        private void CreateGameField()
        {
            var cardSize = CalculateCardSize();

            var fieldSize = _complexityConfig.GetFieldSize(_gamePlayModel.Complexity);
            var cardsOffset = _gameFieldSettings.CardsOffset;

            var startCardPositionX = -0.5f *(cardSize * (fieldSize.Columns - 1) + cardsOffset* (fieldSize.Columns - 1));
            var startCardPositionY = -0.5f *(cardSize * (fieldSize.Rows - 1) + cardsOffset* (fieldSize.Rows - 1));

            var ids = GenerateCardIds();
            _cardViews = new List<GameCardView>(fieldSize.Rows * fieldSize.Columns);

            for (var i = 0; i < fieldSize.Rows; i++)
            {
                for (var j = 0; j < fieldSize.Columns; j++)
                {
                    var id = ids[i * fieldSize.Columns + j];

                    var positionX = startCardPositionX + j * (cardSize + cardsOffset);
                    var positionY = startCardPositionY + i * (cardSize + cardsOffset);

                    var cardModel = new GameCardModel(id);
                    var cardView = _gameCardsPool.Spawn(_cardsContainer, new Vector2(positionX, positionY), cardSize);
                    IGameCardPresenter cardPresenter = (GameCardPresenter)cardView;
                    cardPresenter.SetModel(cardModel);

                    _cardViews.Add(cardView);
                }
            }
        }

        private float CalculateCardSize()
        {
            var cameraHeight = Camera.main.orthographicSize * 2;
            var cameraWidth = cameraHeight * Camera.main.aspect;

            var borderOffset = _gameFieldSettings.BorderOffset;
            var cardsOffset = _gameFieldSettings.CardsOffset;
            var fieldSize = _complexityConfig.GetFieldSize(_gamePlayModel.Complexity);

            var cardWidth = (cameraWidth - 2 * borderOffset.x - (fieldSize.Columns - 1) * cardsOffset) / fieldSize.Columns;
            var cardHeight = (cameraHeight - 2 * borderOffset.y - (fieldSize.Rows - 1) * cardsOffset) / fieldSize.Rows;

            var cardSize = Math.Min(cardWidth, cardHeight);

            return cardSize;
        }

        private int[] GenerateCardIds()
        {
            var availableCards = new List<int>(_availableCardsAmount);
            for (var i = 0; i < _availableCardsAmount; i++)
            {
                availableCards.Add(i);
            }
            var cardsAmount = _complexityConfig.GetCardsAmount(_gamePlayModel.Complexity);
            var cards = new int[cardsAmount];
            for (var i = 0; i < cardsAmount / 2; i++)
            {
                var randomIndex = Random.Range(0, availableCards.Count);
                var id = availableCards[randomIndex];
                availableCards.RemoveAt(randomIndex);

                cards[i * 2] = id;
                cards[i * 2 + 1] = id;
            }

            ShuffleArray(cards);

            return cards;
        }

        private void ShuffleArray(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                var tmp = numbers[i];
                var r = Random.Range(i, numbers.Length);
                numbers[i] = numbers[r];
                numbers[r] = tmp;
            }
        }

        private void RestartGame()
        {
            ClearGameField();
            CreateGameField();
        }

        private void ClearGameField()
        {
            if (_cardViews.IsEmpty())
                return;

            foreach (var card in _cardViews)
            {
                _gameCardsPool.Despawn(card);
            }
        }
    }
}
