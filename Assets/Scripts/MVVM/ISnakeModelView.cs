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
        bool IsDead { get; }
        void EatApple();

        event Action<int> OnEatApple;
        event Action<Vector2Int> OnKeyInput;
    }
}
