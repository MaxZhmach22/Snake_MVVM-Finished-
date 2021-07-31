using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;

namespace MVVM
{
    public sealed class UIModelView
    {
        private Button _menuBtn;
        private Button _resumeBtn;
        private Button _mainMenuBtn;

        private Transform _pauseMenu;

        private UIModel _uiModel;

        public Button MenuBtn { get => _menuBtn; }

        public event Action<bool> OnPauseGame;


        private bool isActive = false;
        public UIModelView(UIModel uiModel)
        {
            _uiModel = uiModel;
            _menuBtn = _uiModel.MenuBtn;
            _resumeBtn = _uiModel.ResumeBtn;
            _mainMenuBtn = _uiModel.MainMenuBtn;
            _pauseMenu = _uiModel.PauseMenu;
            _pauseMenu.gameObject.SetActive(false);

        }

        public void IsPauseGame()
        {
            _pauseMenu.gameObject.SetActive(true);
            _uiModel.PauseGame();
            OnPauseGame?.Invoke(_uiModel.IsPaused);

        }

    }
}
