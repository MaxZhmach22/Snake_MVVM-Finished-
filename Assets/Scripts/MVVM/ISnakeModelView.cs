using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    interface ISnakeModelView
    {
        ISnakeModel SnakeModel { get; }
        bool IsDead { get; }
        void EatApple();

        event Action<int> OnEatApple;
    }
}
