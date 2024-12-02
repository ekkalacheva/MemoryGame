using UnityEngine;

namespace MemoryGame.GamePlay
{
    public class GameCardModel
    {
        private int _id;
        private Vector2 _position;
        private float _size;

        public int Id => _id;

        public Vector2 Position => _position;

        public float Size => _size;

        public GameCardModel(int id, Vector2 position, float size)
        {
            _id = id;
            _position = position;
            _size = size;
        }
    }
}
