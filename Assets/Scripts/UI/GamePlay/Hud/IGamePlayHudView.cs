using System;

namespace MemoryGame.UI.GamePlay
{
    internal interface IGamePlayHudView
    {
        event Action BackButtonClicked;
        event Action RestartButtonClicked;

        public void SetTime(float timeSeconds);
        public void SetTimeState(bool isActive);
    }
}
