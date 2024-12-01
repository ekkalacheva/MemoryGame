using System;

namespace MemoryGame.UI.GamePlay
{
    internal interface IGamePlayHudView
    {
        event Action BackButtonClicked;
        event Action RestartButtonClicked;
    }
}
