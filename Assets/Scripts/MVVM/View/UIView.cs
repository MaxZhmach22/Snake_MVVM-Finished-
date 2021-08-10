using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public sealed class UIView : MonoBehaviour
    {

        private Button _menuBtn;
        private Button _resumeBtn;
        private Button _mainMenuBtn;
        private Button _resetBestScore;
        private Button _loseMenuBtn;
        private Button _muted;

        private List<Button> _buttons = new List<Button>();
        private AudioSource _audioSource;
        private IUIIModelView _uIModelView;
        private GameData _gameData;


        public void Initialize(IUIIModelView uIModelView, GameData gameData)
        {
            _uIModelView = uIModelView;
            _gameData = gameData;
            _menuBtn = _uIModelView.MenuBtn;
            _muted = _uIModelView.Muted;
            _resumeBtn = _uIModelView.ResumeBtn;
            _mainMenuBtn = _uIModelView.MainMenuBtn;
            _resetBestScore = _uIModelView.ResetBestScore;
            _loseMenuBtn = _uIModelView.LoseMenuBtn;
            _audioSource = gameObject.GetComponent<AudioSource>();
            _gameData.OnMutedSound += OnMutedSound;
            AddButtonToTheList();
            AddListenersToButtons();
        }
        public void AddButtonToTheList()
        {
            _buttons.Add(_loseMenuBtn);
            _buttons.Add(_menuBtn);
            _buttons.Add(_mainMenuBtn);
            _buttons.Add(_resumeBtn);
            _buttons.Add(_resetBestScore);
            _buttons.Add(_muted);
        }

        private void AddListenersToButtons()
        {
            foreach (var button in _buttons)
            {
                button.onClick.AddListener(() => _audioSource.PlayOneShot(_gameData.ClickSound));
            }

            _resumeBtn.onClick.AddListener(() => _uIModelView.IsPauseGame());
            _menuBtn.onClick.AddListener(() => _uIModelView.IsPauseGame());
            _mainMenuBtn.onClick.AddListener(() => _uIModelView.LoadScene());
            _resetBestScore.onClick.AddListener(() => _uIModelView.ResetBestScoreMethod());
            _loseMenuBtn.onClick.AddListener(() => _uIModelView.LoadScene());
            _muted.onClick.AddListener(() => _uIModelView.MuteSound());
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

    }
}
