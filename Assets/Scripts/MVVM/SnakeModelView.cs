using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    class SnakeModelView : ISnakeModelView
    {
        private bool _isDead;


        public ISnakeModel SnakeModel { get; }
        public bool IsDead => _isDead;

        public event Action<int> OnEatApple;

        private Transform _snakeTransform;
        
        public SnakeModelView(ISnakeModel snakeModel)
        {
            SnakeModel = snakeModel;
            _snakeTransform = CreateSnake(SnakeModel);
        }

        public void EatApple()
        {
            OnEatApple?.Invoke(100);
        }

        private Transform CreateSnake(ISnakeModel snakeModel)
        {
            var gameObject = new GameObject("Snake", typeof(SpriteRenderer));
            var snakeHeadSprite = gameObject.GetComponent<SpriteRenderer>();
            snakeHeadSprite.sprite = snakeModel.SnakeHead;
            gameObject.transform.position = new Vector3(10, 10);
            return gameObject.transform;
        }

        public Transform GetSnakeTranform()
        {
            return _snakeTransform;
        }


    }
}
