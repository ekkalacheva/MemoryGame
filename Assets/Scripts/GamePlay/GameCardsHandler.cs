using System;
using MemoryGame.Game;
using MemoryGame.Utils;
using Zenject;

namespace MemoryGame.GamePlay
{
    internal class GameCardsHandler: IInitializable, IDisposable
    {
        private const float CardsHideDelaySeconds = 0.8f;

        private readonly SignalBus _signals;
        private readonly ICoroutineHandler _coroutineHandler;
        private readonly int _cardsAmount;

        private IGameCardModel _openedCard1;
        private IGameCardModel _openedCard2;
        private int _collectedCardsAmount;
        private bool _gameStarted;
        
        public GameCardsHandler(SignalBus signals,
                                ICoroutineHandler coroutineHandler,
                                GamePlayModel gamePlayModel,
                                GameComplexityConfig complexityConfig)
        {
            _signals = signals;
            _coroutineHandler = coroutineHandler;
            _cardsAmount = complexityConfig.GetCardsAmount(gamePlayModel.Complexity);
        }

        public void Initialize()
        {
            _signals.Subscribe<GamePlaySignals.CardClicked>(OnGameCardClicked);
        }

        public void Dispose()
        {
            _signals.Unsubscribe<GamePlaySignals.CardClicked>(OnGameCardClicked);
        }

        private void OnGameCardClicked(GamePlaySignals.CardClicked args)
        {
            var card = args.Card;

            if (card.State == GameCardState.Collected || card.State == GameCardState.Opened)
            {
                return;
            }

            if (_openedCard1 == null)
            {
                _openedCard1 = args.Card;
                _openedCard1.State = GameCardState.Opened;
                CheckGameStart();
                return;
            }

            if (_openedCard2 != null)
            {
                return;
            }

            _openedCard2 = card;
            _openedCard2.State = GameCardState.Opened;

            if (_openedCard2.Id == _openedCard1.Id)
            {
                _openedCard1.State = GameCardState.Collected;
                _openedCard2.State = GameCardState.Collected;
                _openedCard1 = null;
                _openedCard2 = null;
                PairCardsCollected();
                return;
            }

            _coroutineHandler.DelayAction(() =>
            {
                _openedCard1.State = GameCardState.Closed;
                _openedCard2.State = GameCardState.Closed;
                _openedCard1 = null;
                _openedCard2 = null;
            }, CardsHideDelaySeconds);
        }

        private void CheckGameStart()
        {
            if (!_gameStarted)
            {
                _gameStarted = true;
                _signals.TryFire<GamePlaySignals.GameStarted>();
            }
        }

        private void PairCardsCollected()
        {
            _collectedCardsAmount += 2;
            if (_collectedCardsAmount == _cardsAmount)
            {
                _signals.TryFire<GamePlaySignals.GameCompleted>();
            }
        }
    }
}
