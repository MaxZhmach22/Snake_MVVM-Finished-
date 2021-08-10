using UnityEngine;

namespace MVVM
{
    public sealed class SnakeModel : ISnakeModel
    {
        private Sprite _snakeHead;
        private Sprite _snakeBody;

        public SnakeModel(float startSpeed, GameData gameData)
        {
            _snakeHead = gameData.SnakeHead;
            _snakeBody = gameData.SnakeBody;
        }

        public Sprite SnakeHead => _snakeHead;

        public Sprite SnakeBody => _snakeBody;

        
    }

}
