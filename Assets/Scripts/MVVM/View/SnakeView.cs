using System;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM
{
    
    public sealed class SnakeView : MonoBehaviour
    {

        private float gridMoveTime;
        private float gridMoveTimerMax = 0.4f;
        private int _snakeBodySize = 0;
        private Vector2Int gridPosition = new Vector2Int(10, 10);
        private Vector2Int _correctDirection = Vector2Int.right;
        private Direction gridMoveDirection = Direction.Right;
        private List<Vector2Int> _direction = new List<Vector2Int>();
        private List<Vector2Int> _snakeMovesList = new List<Vector2Int>();
        private List<SnakeBodyPart> snakeBodyPartList = new List<SnakeBodyPart>();
        private List<SnakeMovePosition> snakeMovePositonList = new List<SnakeMovePosition>();
        public Action<bool> OnSelfEating;

        private Transform _snake;
        private GameData _gameData;
        private AudioSource _audioSource;
        private LevelSetup _levelSetup;
        private ISnakeModelView _snakeModelView;


        public void Initialize(ISnakeModelView snakeModelView, LevelSetup levelSetup, GameData gameData)
        {
            _snakeModelView = snakeModelView;
            _levelSetup = levelSetup;
            _gameData = gameData;
            _audioSource = gameObject.GetComponent<AudioSource>();
            _snakeModelView.OnEatApple += OnEatApple;
            _snakeModelView.OnKeyInput += OnMove;
            _snake = SnakeFactory.CreateGameObject(_gameData.SnakeHead);
            _snake.position = new Vector3(gridPosition.x, gridPosition.y);
            _snake.eulerAngles = new Vector3(0, 0, GetAngleFromDirection(_correctDirection) - 90);
            _snakeModelView.GetSnakePosition(gridPosition);
            _snakeModelView.GetFullSnakeGridPosition(_snakeMovesList);
            _gameData.OnMutedSound += OnMutedSound;

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
                if(!(_direction[0] == -_correctDirection))
                {
                    _correctDirection = _direction[0];
                }
                else
                {
                    _correctDirection = _direction[1];
                }

                gridPosition += _correctDirection;
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
                        _audioSource.PlayOneShot(_gameData.LoseSound);
                        OnSelfEating?.Invoke(true);
                    }
                }

                _snake.position = new Vector3(gridPosition.x, gridPosition.y);
                _snake.eulerAngles = new Vector3(0, 0, GetAngleFromDirection(_correctDirection) - 90);
                _snakeModelView.GetSnakePosition(gridPosition);
                _snakeModelView.GetFullSnakeGridPosition(_snakeMovesList);
                _snakeModelView.OneMovePerTimer = true;

            }
        }

        public void OnMutedSound(bool muted)
        {
            if (muted)
            {
                _audioSource.volume = 0;
            }
            else
            {
                _audioSource.volume = 1;
            }
        }

        private void OnEatApple(int score)
        {
            _snakeBodySize++;
            gridMoveTimerMax -= 0.01f;
            _audioSource.PlayOneShot(_gameData.EatSound);
            CreateSnakeBodyPart();
        }

        private void OnMove(List<Vector2Int> positions, Direction direction)
        {
            _direction = positions;
            gridMoveDirection = direction;
        }

        private float GetAngleFromDirection(Vector2Int direction) 
        {
            float n = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            if (n < 0) n += 360;
            return n;
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

        private void CreateSnakeBodyPart() 
        {
            snakeBodyPartList.Add(new SnakeBodyPart(snakeBodyPartList.Count, _gameData.SnakeBody));
        }

        private void UpdateSnakeBodyPart()
        {
            for (int i = 0; i < snakeBodyPartList.Count; i++)
            {
                snakeBodyPartList[i].SetSnakeMovePosition(snakeMovePositonList[i]);
            }
        }


    }
}
