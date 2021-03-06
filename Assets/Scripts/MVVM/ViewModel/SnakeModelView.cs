using System;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM
{
    public class SnakeModelView : ISnakeModelView
    {
        private bool _isDead;
        private Vector2Int _snakePosition;
        private List<Vector2Int> _fullSnakeGridPosition;
        public event Action<int> OnEatApple;
        public event Action<List<Vector2Int>, Direction> OnKeyInput;
        
        public ISnakeModel SnakeModel { get; }
        public bool IsDead { get => _isDead; set => _isDead = value; }
        public Vector2Int SnakeHeadPosition => _snakePosition;
        public List<Vector2Int> FullSnakeGridPosition => _fullSnakeGridPosition;

        public bool OneMovePerTimer { get; set; }

        public SnakeModelView(ISnakeModel snakeModel)
        {
            SnakeModel = snakeModel;
        }

        public void EatApple()
        {
            OnEatApple?.Invoke(100);
        }

        public void Move(List<Vector2Int> positions, Direction direction)
        {
            OnKeyInput?.Invoke(positions, direction);
        }

        public void GetSnakePosition(Vector2Int position)
        {
            _snakePosition = position;
        }

        public void GetFullSnakeGridPosition(List<Vector2Int> snakePositionList)
        {
            _fullSnakeGridPosition = new List<Vector2Int>() { _snakePosition };
            _fullSnakeGridPosition.AddRange(snakePositionList);
        }
    }
}
