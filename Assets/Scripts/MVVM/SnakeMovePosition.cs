using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    public class SnakeMovePosition
    {
      
        private SnakeMovePosition previousSnakeMovePositon;
        private Vector2Int gridPosition;
        private Direction direction;

        public SnakeMovePosition(SnakeMovePosition previousSnakeMovePositon, Vector2Int gridPosition, Direction direction)
        {
            this.previousSnakeMovePositon = previousSnakeMovePositon;
            this.gridPosition = gridPosition;
            this.direction = direction;
        }

        public Vector2Int GetGridPosition() //+
        {
            return gridPosition;
        }

        public Direction GetDirection() //+
        {
            return direction;
        }

        public Direction GetPreviousDirection() //+
        {
            if (previousSnakeMovePositon == null)
            {
                return Direction.Right;
            }
            else
                return previousSnakeMovePositon.direction;
        }
    }
}
