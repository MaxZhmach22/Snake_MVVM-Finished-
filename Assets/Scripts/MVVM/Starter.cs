using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM
{
    public class Starter : MonoBehaviour
    {

        [SerializeField] private SnakeView _snakeView;
        [SerializeField] private FoodView  _foodView;
        [SerializeField] private InputView _inputView;
        [SerializeField] private UIView _uIView;

        private SnakeModel _snakeModel;
        private SnakeModelView _snakeModelView;
        private UIModel _uiModel;
        private UIModelView _uiModelView;

        void Start()
        {
            LevelSetup level = new LevelSetup(21, 21);
            _snakeModel = new SnakeModel(1f);
            _snakeModelView = new SnakeModelView(_snakeModel);
            _uiModel = new UIModel();
            _uiModelView = new UIModelView(_uiModel);
            _uIView.Initialize(_uiModelView);
            _snakeView.Initialize(_snakeModelView, level);
            _inputView.Initialize(_snakeModelView, level);
            _foodView.Initialize(_snakeModelView, level);
        }

    }

}
