using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MVVM.MainMenu
{
    public class MainMenuStarter : MonoBehaviour
    {
        [SerializeField] private UIView _uiView;

        private GameData _gameData;
        private IUIModel _uiModel;
        private IUIModelView _uiModelView;

        private void Start()
        {
            _gameData = Resources.Load<GameData>("GameData");
            _uiModel = new UIModel();
            _uiModelView = new UIModelView(_uiModel, _gameData);
            _uiView.Initialize(_uiModelView, _gameData);

        }
    }
}
