using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    public sealed class InputView : MonoBehaviour
    {
        

        private ISnakeModelView _snakeModelView;
        private LevelSetup _levelSetup;
        private Direction gridMoveDirection = Direction.Right;
        private Vector2Int gridMoveDirectionVector = new Vector2Int(+1, 0);


        public void Initialize(ISnakeModelView snakeModelView, LevelSetup levelSetup)
        {
            _snakeModelView = snakeModelView;
            _levelSetup = levelSetup;
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _snakeModelView.EatApple();
            }
            HandInput();
            HandleGridMovemet();
        }

        private void HandInput()
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                if (gridMoveDirection != Direction.Down)
                {
                    gridMoveDirection = Direction.Up;
                }

            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                if (gridMoveDirection != Direction.Up)
                {
                    gridMoveDirection = Direction.Down;
                }
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                if (gridMoveDirection != Direction.Left)
                {
                    gridMoveDirection = Direction.Right;
                }
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                if (gridMoveDirection != Direction.Right)
                {
                    gridMoveDirection = Direction.Left;
                }
            }
        }

        private void HandleGridMovemet()
        {
            switch (gridMoveDirection)
            {
                default:
                case Direction.Right: gridMoveDirectionVector = new Vector2Int(+1, 0); break;
                case Direction.Left: gridMoveDirectionVector = new Vector2Int(-1, 0); break;
                case Direction.Up: gridMoveDirectionVector = new Vector2Int(0, +1); break;
                case Direction.Down: gridMoveDirectionVector = new Vector2Int(0, -1); break;
            }
            
            _snakeModelView.Move(gridMoveDirectionVector, gridMoveDirection);
        }
       
    }
}
