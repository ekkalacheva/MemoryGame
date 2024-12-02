using UnityEngine;

namespace MemoryGame.GamePlay
{
    public interface IGameCardView
    {
        void SetPosition(Vector2 position);
        void SetSize(float size);
    }
}
