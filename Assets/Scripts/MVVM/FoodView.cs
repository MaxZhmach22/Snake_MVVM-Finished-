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
        
        public void Initialize(ISnakeModelView snakeModelView, LevelSetup levelSetup)
        {
            _snakeModelView = snakeModelView;
            _levelSetup = levelSetup;
            SpawnFood(_snakeModelView, _levelSetup);
            _snakeModelView.OnEatApple += OnEatApple;
        }

        public void SpawnFood(ISnakeModelView snakeModelView, LevelSetup levelSetup)
        {
            //do
            //{
            //    _foodGridPosition = new Vector2Int(UnityEngine.Random.Range(0, levelSetup.Weight), UnityEngine.Random.Range(0,levelSetup.Height));
            //}
        }

        public void OnEatApple(int i)
        {
            SpawnFood(_snakeModelView, _levelSetup);
        }
    }
}
