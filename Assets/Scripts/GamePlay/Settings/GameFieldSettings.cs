using MemoryGame.Game;
using System;
using UnityEngine;

namespace MemoryGame.GamePlay
{
    [Serializable]
    internal class GameFieldSettings
    {
        [SerializeField]
        private GameFieldOffsets _easy;

        [SerializeField]
        private GameFieldOffsets _medium;

        [SerializeField]
        private GameFieldOffsets _hard;

        public GameFieldOffsets Easy => _easy;
        public GameFieldOffsets Medium => _medium;
        public GameFieldOffsets Hard => _hard;

        public GameFieldOffsets GetFieldSettings(GameComplexity complexity)
        {
            switch (complexity)
            {
                case GameComplexity.Easy: return _easy;
                case GameComplexity.Medium: return _medium;
                case GameComplexity.Hard: return _hard;

                default: throw new NotImplementedException("Unsupported complexity type");
            }
        }
    }

    [Serializable]
    internal class GameFieldOffsets
    {
        [SerializeField]
        private Vector2 _borderOffset;

        [SerializeField]
        private float _cardsOffset;

        public Vector2 BorderOffset => _borderOffset;

        public float CardsOffset => _cardsOffset;
    }
}
