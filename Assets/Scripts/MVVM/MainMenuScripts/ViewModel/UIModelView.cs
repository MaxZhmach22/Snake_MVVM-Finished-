using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.MainMenu
{
    public class UIModelView : IUIModelView
    {
        private IUIModel _uIModel;
        private GameData _gameData;
        private Transform _mainMenu;
        private Transform _howToPlayMenu;
        private Button _playBtn;
        private Button _quitBtn;
        private Button _howToPlayBtn;
        private Button _backBtn;

        public Transform MainMenu => _mainMenu;

        public Transform HowToPlayMenu => _howToPlayMenu;

        public Button PlayBtn => _playBtn;

        public Button QuitBtn => _quitBtn;

        public Button HowToPlayBtn => _howToPlayBtn;

        public Button BackBtn => _backBtn;

        public UIModelView(IUIModel uIModel, GameData gameData)
        {
            _uIModel = uIModel;
            _gameData = gameData;
            _playBtn = _uIModel.PlayBtn;
            _quitBtn = _uIModel.QuitBtn;
            _howToPlayBtn = _uIModel.HowToPlayBtn;
            _backBtn = _uIModel.BackBtn;
        }

        public void MainSceneLoad()
        {
            _uIModel.MainSceneLoad();
        }

        public void ShowHowToPlayMenu()
        {
            _uIModel.ShowHowToPlayMenu();
        }

        public void QuitApplication()
        {
            _uIModel.QuitApplication();
        }

        public void HideHowToPlayMenu()
        {
            _uIModel.HideHowToPlayMenu();
        }
    }
}
