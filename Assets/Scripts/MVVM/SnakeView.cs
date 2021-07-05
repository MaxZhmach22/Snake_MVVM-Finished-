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

        private ISnakeModelView _snakeModelView;
        private Transform _snake;
        private float gridMoveTime;
        private float gridMoveTimerMax = 0.5f;
        private Vector2Int gridPosition = new Vector2Int(10, 10);

        public void Initialize(ISnakeModelView snakeModelView)
        {
            _snakeModelView = snakeModelView;
            _snakeModelView.OnEatApple += OnEatApple;
            _snakeModelView.OnKeyInput += OnMove;
            _snake = SnakeFactory.CreateGameObject(_snakeHead);
            
        }

        private void OnEatApple(int obj)
        {
            var gameObject = new GameObject("Body", typeof(SpriteRenderer));
            gameObject.GetComponent<SpriteRenderer>().sprite = _snakeBody;
            gameObject.transform.position = Vector2.zero;
        }

        private void OnMove(Vector2Int direction)
        {
            gridPosition += direction;
        }

        private void Update()
        {
            gridMoveTime += Time.deltaTime;
            if (gridMoveTime >= gridMoveTimerMax)
            {
                gridMoveTime -= gridMoveTimerMax;
                _snake.position = new Vector3(gridPosition.x, gridPosition.y);
            }
        }
    }
}
