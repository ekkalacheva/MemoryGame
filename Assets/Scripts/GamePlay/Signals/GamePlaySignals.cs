namespace MemoryGame.GamePlay
{
    internal class GamePlaySignals
    {
        public class CardClicked
        {
            public readonly IGameCardModel Card;

            public CardClicked(IGameCardModel card)
            {
                Card = card;
            }
        }

        public class GameStarted
        {
        }

        public class GameCompleted
        {
        }
    }
}
