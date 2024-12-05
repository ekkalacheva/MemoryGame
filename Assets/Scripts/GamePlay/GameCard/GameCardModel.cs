using System;
using UnityEngine;

namespace MemoryGame.GamePlay
{
    public class GameCardModel: IGameCardModel
    {
        private int _id;
        private GameCardState _state;

        public event Action StateChanged;

        public int Id => _id;

        public GameCardState State
        {
            get => _state;
            set
            {
                _state = value;
                RiseStateChangedEvent();
            }
        }

        public GameCardModel(int id)
        {
            _id = id;
        }

        private void RiseStateChangedEvent()
        {
            StateChanged?.Invoke();
        }
    }
}
