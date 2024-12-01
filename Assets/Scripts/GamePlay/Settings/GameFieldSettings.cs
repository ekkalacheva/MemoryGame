using System;
using UnityEngine;

namespace Assets.Scripts.GamePlay
{
    [Serializable]
    internal class GameFieldSettings
    {
        [SerializeField]
        private Vector2 _borderOffset;

        public Vector2 BorderOffset => _borderOffset;
    }
}
