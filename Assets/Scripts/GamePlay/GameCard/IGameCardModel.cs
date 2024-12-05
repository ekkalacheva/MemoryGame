using System;

namespace MemoryGame.GamePlay
{
    public interface IGameCardModel
    {
        public event Action StateChanged;

        public int Id { get; }
        GameCardState State { get; set; }
    }
}
