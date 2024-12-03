using System;
using Zenject;

namespace MemoryGame.GamePlay
{
    internal class GameCardsHandler: IInitializable, IDisposable
    {
        private readonly SignalBus _signals;

        private IGameCardModel _openedCard1;
        private IGameCardModel _openedCard2;

        public GameCardsHandler(SignalBus signals)
        {
            _signals = signals;
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
                return;
            }

            //TODO: Hide cards with delay;
        }
    }
}
