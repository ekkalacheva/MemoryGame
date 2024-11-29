using System;

namespace Assets.Scripts.Game
{
    [Serializable]
    internal class GameComplexityConfig
    {
        public GameFieldSize Easy;
        public GameFieldSize Medium;
        public GameFieldSize Hard;

        public GameFieldSize GetFieldSize(GameComplexity complexity)
        {
            switch (complexity)
            {
                case GameComplexity.Easy: return Easy;
                case GameComplexity.Medium: return Medium;
                case GameComplexity.Hard: return Hard;

                default: throw new NotImplementedException("Unsupported complexity type");
            }
        }
    }

    [Serializable]
    internal class GameFieldSize
    {
        public int Rows;
        public int Columns;
    }
}
