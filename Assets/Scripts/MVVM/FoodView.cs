using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace MVVM
{
    public sealed class FoodView : MonoBehaviour
    {
        [SerializeField] private Sprite _apple;
        private ISnakeModelView _snakeModelView;
        private LevelSetup _levelSetup;
        private Vector2Int _foodGridPosition;
        private Transform _appleTransform;
        
        public void Initialize(ISnakeModelView snakeModelView, LevelSetup levelSetup)
        {
            _snakeModelView = snakeModelView;
            _levelSetup = levelSetup;
            _appleTransform = SnakeFactory.CreateGameObject(_apple);
            SpawnFood();
            _snakeModelView.OnEatApple += OnEatApple;
            
        }

        private void Update()
        {
            if(_snakeModelView.SnakeHeadPosition == _foodGridPosition)
            {
                _snakeModelView.EatApple();
            }
        }
        public void SpawnFood()
        {
            do
            {
                _foodGridPosition = new Vector2Int(UnityEngine.Random.Range(0, _levelSetup.Weight), UnityEngine.Random.Range(0, _levelSetup.Height));
            } while (_snakeModelView.FullSnakeGridPosition.IndexOf(_foodGridPosition) != -1);

            _appleTransform.position = new Vector3(_foodGridPosition.x, _foodGridPosition.y);

        }

        public void OnEatApple(int i)
        {
            SpawnFood();
        }

    }
}
