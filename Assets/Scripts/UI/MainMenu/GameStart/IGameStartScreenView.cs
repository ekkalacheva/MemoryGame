using System;
using MemoryGame.Game;

namespace MemoryGame.UI.MainMenu
{
    internal interface IGameStartScreenView
    {
        public event Action<GameComplexity> GameComplexityButtonClicked;
    }
}
