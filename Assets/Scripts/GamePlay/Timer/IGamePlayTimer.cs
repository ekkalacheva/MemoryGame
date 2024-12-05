using System;

namespace MemoryGame.GamePlay
{
    internal interface IGamePlayTimer
    {
        float ElapsedSeconds { get; }

        public event Action TimeChanged;
    }
}
