using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM
{
    public sealed class SnakeModel : ISnakeModel
    {
        private Sprite _snakeHead;
        private Sprite _snakeBody;
        private float _startSpeed;
        private Transform _transform;

        public SnakeModel(float startSpeed)
        {
            _startSpeed = startSpeed;
            _snakeHead = Resources.Load<Sprite>("Snakehead");
        }

        public float StartSpeed => _startSpeed;

        public Sprite SnakeHead => _snakeHead;

        public Sprite SnakeBody => _snakeBody;

        
    }

}
