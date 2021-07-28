using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    
    public sealed class SnakeView : MonoBehaviour
    {
        [SerializeField] private Sprite _snakeHead;
        [SerializeField] private Sprite _snakeBody;

        private LevelSetup _levelSetup;
        private ISnakeModelView _snakeModelView;
        private Transform _snake;
        private float gridMoveTime;
        private float gridMoveTimerMax = 0.5f;
        private Vector2Int gridPosition = new Vector2Int(10, 10);
        private Vector2Int _direction;
        private Direction gridMoveDirection = Direction.Right;
        private int _snakeBodySize = 0; //Приходит из модели?
        private List<Vector2Int> _snakeMovesList = new List<Vector2Int>(); //ПРиходит из модели?
        private List<SnakeBodyPart> snakeBodyPartList = new List<SnakeBodyPart>();
        private List<SnakeMovePosition> snakeMovePositonList = new List<SnakeMovePosition>();

        public void Initialize(ISnakeModelView snakeModelView, LevelSetup levelSetup)
        {
            _snakeModelView = snakeModelView;
            _levelSetup = levelSetup;
            _snakeModelView.OnEatApple += OnEatApple;
            _snakeModelView.OnKeyInput += OnMove;
            _snake = SnakeFactory.CreateGameObject(_snakeHead);
            _snakeModelView.GetSnakePosition(gridPosition);
            _snakeModelView.GetFullSnakeGridPosition(_snakeMovesList);

        }

        private void Update()
        {
            SnakeMove();
        }

        private void SnakeMove()
        {
            gridMoveTime += Time.deltaTime;
            if (gridMoveTime >= gridMoveTimerMax)
            {
                gridMoveTime -= gridMoveTimerMax;
                SnakeMovePosition previousSnakeMovePosition = null;
                if (snakeMovePositonList.Count > 0)
                {
                    previousSnakeMovePosition = snakeMovePositonList[0];
                }

                SnakeMovePosition snakeMovePosition = new SnakeMovePosition(previousSnakeMovePosition, gridPosition, gridMoveDirection);

                snakeMovePositonList.Insert(0, snakeMovePosition);



                gridPosition += _direction;
                gridPosition = ValidateGridPosition(gridPosition);

                if(_snakeMovesList.Count >= _snakeBodySize + 1)
                {
                    _snakeMovesList.RemoveAt(_snakeMovesList.Count - 1);
                }

                UpdateSnakeBodyPart();

                foreach (SnakeBodyPart snakeBodyPart in snakeBodyPartList)
                {
                    Vector2Int snakeBodyPartGridPosition = snakeBodyPart.GetGridPosition();
                    if (gridPosition == snakeBodyPartGridPosition)
                    {
                        Debug.Log("Dead");
                        _snakeModelView.IsDead = true;
                    }
                }

                _snake.position = new Vector3(gridPosition.x, gridPosition.y);
                _snake.eulerAngles = new Vector3(0, 0, GetAngleFromDirection(_direction) - 90);
                _snakeModelView.GetSnakePosition(gridPosition);
                _snakeModelView.GetFullSnakeGridPosition(_snakeMovesList);

            }
        }

        private void OnEatApple(int obj)
        {
            _snakeBodySize++;
            gridMoveTimerMax -= 0.005f;
            CreateSnakeBodyPart();
        }

        private void OnMove(Vector2Int position, Direction direction)
        {
            _direction = position;
            gridMoveDirection = direction;
        }

        private float GetAngleFromDirection(Vector2Int direction) // +
        {
            float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            return n;
        }

        public Vector2Int GetSnakePosition()
        {
            return gridPosition;
        }
        public Vector2Int ValidateGridPosition(Vector2Int gridPosition)
        {
            if (gridPosition.x < 0)
            {
                gridPosition.x = _levelSetup.Weight - 1;
            }
            if (gridPosition.x > _levelSetup.Weight - 1)
            {
                gridPosition.x = 0;
            }
            if (gridPosition.y < 0)
            {
                gridPosition.y = _levelSetup.Height - 1;
            }
            if (gridPosition.y > _levelSetup.Height - 1)
            {
                gridPosition.y = 0;
            }
            return gridPosition;
        }

        private void CreateSnakeBodyPart() //+
        {
            snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count, _snakeBody));
        }

        private void UpdateSnakeBodyPart() //+
        {
            for (int i = 0; i < snakeBodyPartList.Count; i++)
            {
                snakeBodyPartList[i].SetSnakeMovePosition(snakeMovePositonList[i]);
            }
        }


    }
}
