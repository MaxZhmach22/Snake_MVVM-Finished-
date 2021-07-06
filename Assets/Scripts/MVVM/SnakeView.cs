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

        public void Initialize(ISnakeModelView snakeModelView, LevelSetup levelSetup)
        {
            _snakeModelView = snakeModelView;
            _levelSetup = levelSetup;
            _snakeModelView.OnEatApple += OnEatApple;
            _snakeModelView.OnKeyInput += OnMove;
            _snake = SnakeFactory.CreateGameObject(_snakeHead);
            
        }

        private void Update()
        {
            gridMoveTime += Time.deltaTime;
            if (gridMoveTime >= gridMoveTimerMax)
            {
                gridMoveTime -= gridMoveTimerMax;
                gridPosition += _direction;
                gridPosition = ValidateGridPosition(gridPosition);
                _snake.position = new Vector3(gridPosition.x, gridPosition.y);
                _snake.eulerAngles = new Vector3(0, 0, GetAngleFromDirection(_direction) - 90);
                _snakeModelView.GetSnakePosition(gridPosition);
                
            }
        }

        private void OnEatApple(int obj)
        {
            var gameObject = new GameObject("Body", typeof(SpriteRenderer));
            gameObject.GetComponent<SpriteRenderer>().sprite = _snakeBody;
            gameObject.transform.position = Vector2.zero;
        }

        private void OnMove(Vector2Int direction)
        {
            _direction = direction;
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


    }
}
