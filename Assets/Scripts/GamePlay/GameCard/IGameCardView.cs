using System;
using UnityEngine;

namespace MemoryGame.GamePlay
{
    public interface IGameCardView
    {
        event Action Clicked;

        void SetPosition(Vector2 position);
        void SetSize(float size);
        void SetBackSprite(Sprite sprite);
        void SetFaceSprite(Sprite sprite);
        void Open();
        void Close();
    }
}
