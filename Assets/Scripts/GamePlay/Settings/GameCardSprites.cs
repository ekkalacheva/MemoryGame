using System;
using UnityEngine;

namespace MemoryGame.GamePlay
{
    [Serializable]
    public class GameCardSprites
    {
        [SerializeField] 
        private Sprite _back;

        [SerializeField]
        private Sprite[] _faces;

        public Sprite Back => _back;
        
        public Sprite[] Faces => _faces;
    }
}
