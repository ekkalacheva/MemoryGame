using System;
using UnityEngine;

namespace MemoryGame.GamePlay
{
    public interface IGameCardModel
    {
        public event Action StateChanged;

        public int Id { get; }
        GameCardState State { get; set; }
        Vector2 Position { get; }
        float Size { get; }
    }
}
