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
        private Transform _snakeTransform;
        private Vector2Int _snakePosition;
        public event Action<int> OnEatApple;
        public event Action<Vector2Int> OnKeyInput;

        public ISnakeModel SnakeModel { get; }
        public bool IsDead => _isDead;
        public Vector2Int SnakePosition => _snakePosition;

        public SnakeModelView(ISnakeModel snakeModel)
        {
            SnakeModel = snakeModel;
            //_snakeTransform = CreateSnake(SnakeModel);
        }

        public void EatApple()
        {
            OnEatApple?.Invoke(100);
        }

        public void Move(Vector2Int direction)
        {
            OnKeyInput?.Invoke(direction);
        }

        private Transform CreateSnake(ISnakeModel snakeModel)
        {
            var gameObject = new GameObject("Snake", typeof(SpriteRenderer));
            var snakeHeadSprite = gameObject.GetComponent<SpriteRenderer>();
            snakeHeadSprite.sprite = snakeModel.SnakeHead;
            gameObject.transform.position = new Vector3(10, 10);
            return gameObject.transform;
        }

        public void GetSnakePosition(Vector2Int position)
        {
            _snakePosition = position;
        }

        public Transform GetSnakeTranform()
        {
            return _snakeTransform;
        }


    }
}
