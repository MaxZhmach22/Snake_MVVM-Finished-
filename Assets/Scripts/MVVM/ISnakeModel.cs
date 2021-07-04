using UnityEngine;

namespace MVVM
{
    public interface ISnakeModel
    {
        public Sprite SnakeHead { get; }
        public Sprite SnakeBody { get; }

        public float StartSpeed { get; }
    }
}