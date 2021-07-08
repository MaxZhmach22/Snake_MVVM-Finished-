using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    public interface ISnakeModelView
    {
        ISnakeModel SnakeModel { get; }
        bool IsDead { get; set; }

        Vector2Int SnakeHeadPosition { get; }

        List<Vector2Int> FullSnakeGridPosition { get; }
        void EatApple();

        
        void GetSnakePosition(Vector2Int position);
        void GetFullSnakeGridPosition(List<Vector2Int> snakePositionList);


        void Move(Vector2Int position, Direction direction);


        event Action<int> OnEatApple;
        event Action<Vector2Int, Direction> OnKeyInput;

    }
}
