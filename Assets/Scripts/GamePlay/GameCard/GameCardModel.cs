using System;
using UnityEngine;

namespace MemoryGame.GamePlay
{
    public class GameCardModel: IGameCardModel
    {
        private int _id;
        private GameCardState _state;
        private Vector2 _position;
        private float _size;

        public event Action StateChanged;

        public int Id => _id;

        public Vector2 Position => _position;

        public float Size => _size;

        public GameCardState State
        {
            get => _state;
            set
            {
                _state = value;
                RiseStateChangedEvent();
            }
        }

        public GameCardModel(int id, Vector2 position, float size)
        {
            _id = id;
            _position = position;
            _size = size;
        }

        private void RiseStateChangedEvent()
        {
            StateChanged?.Invoke();
        }
    }
}
