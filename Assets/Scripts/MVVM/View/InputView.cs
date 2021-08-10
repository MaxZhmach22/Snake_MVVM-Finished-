using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public sealed class InputView : MonoBehaviour
    {
        private ISnakeModelView _snakeModelView;
        private Direction gridMoveDirection = Direction.Right;
        private List<Vector2Int> _currentAndPreviousDirectionVector = new List<Vector2Int>();
        private Vector2Int gridMoveDirectionVector = new Vector2Int(+1, 0);
        private Vector2Int previousGridMoveDirectionVector = new Vector2Int(+1, 0);
        private Button _upBtn;
        private Button _downBtn;
        private Button _rightBtn;
        private Button _leftBtn;

        private void Awake()
        {
            InputButtonsInit();
           
        }

        public void Initialize(ISnakeModelView snakeModelView)
        {
            _snakeModelView = snakeModelView;
            _currentAndPreviousDirectionVector.Add(gridMoveDirectionVector);
            _currentAndPreviousDirectionVector.Add(previousGridMoveDirectionVector);
        }

        private void InputButtonsInit()
        {
            _upBtn = GameObject.Find("UpBtn").GetComponent<Button>();
            _downBtn = GameObject.Find("DownBtn").GetComponent<Button>();
            _rightBtn = GameObject.Find("RightBtn").GetComponent<Button>();
            _leftBtn = GameObject.Find("LeftBtn").GetComponent<Button>();
            _upBtn.onClick.AddListener(() => UpDirection(Direction.Up));
            _downBtn.onClick.AddListener(() => DownDirection(Direction.Down));
            _rightBtn.onClick.AddListener(() => RightDirection(Direction.Right));
            _leftBtn.onClick.AddListener(() => LeftDirection(Direction.Left));
        }

        private void Update()
        {
            HandleGridMovemet();
        }


        private void UpDirection(Direction direction)
        {
            if (gridMoveDirection != Direction.Down)
            {
                gridMoveDirection = direction;
                
            }
        }

        private void DownDirection(Direction direction)
        {
            if (gridMoveDirection != Direction.Up)
            {
                gridMoveDirection = direction;
                
            }
        }

        private void RightDirection(Direction direction)
        {
            if (gridMoveDirection != Direction.Left)
            {
                gridMoveDirection = direction;
                
            }
        }

        private void LeftDirection(Direction direction)
        {
            if (gridMoveDirection != Direction.Right)
            {
                gridMoveDirection = direction;
                
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
            if(previousGridMoveDirectionVector != gridMoveDirectionVector)
            {
                _currentAndPreviousDirectionVector.Add(gridMoveDirectionVector);
                previousGridMoveDirectionVector = gridMoveDirectionVector;
            }
            if (_currentAndPreviousDirectionVector.Count >= 3)
            {
                _currentAndPreviousDirectionVector.Reverse();
                _currentAndPreviousDirectionVector.RemoveAt(2);
            }

             _snakeModelView.Move(_currentAndPreviousDirectionVector, gridMoveDirection);
        }
    }
}
