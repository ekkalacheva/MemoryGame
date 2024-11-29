using System;

namespace Assets.Scripts.Screens.GamePlay
{
    internal interface IGamePlayHudView
    {
        event Action BackButtonClicked;
        event Action RestartButtonClicked;
    }
}
