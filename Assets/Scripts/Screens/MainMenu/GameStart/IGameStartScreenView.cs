using System;
using Assets.Scripts.Game;

namespace Assets.Scripts.Screens.MainMenu
{
    internal interface IGameStartScreenView
    {
        public event Action<GameComplexity> GameComplexityButtonClicked;
    }
}
