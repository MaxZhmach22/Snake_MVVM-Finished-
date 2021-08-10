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

        bool OneMovePerTimer { get; set; }

        Vector2Int SnakeHeadPosition { get; }

        List<Vector2Int> FullSnakeGridPosition { get; }
        void EatApple();

        
        void GetSnakePosition(Vector2Int position);
        void GetFullSnakeGridPosition(List<Vector2Int> snakePositionList);


        void Move(List<Vector2Int> position, Direction direction);


        event Action<int> OnEatApple;
        event Action<List<Vector2Int>, Direction> OnKeyInput;

    }
}
