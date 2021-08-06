using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

namespace MVVM
{
    public sealed class UIModelView
    {
        private Button _menuBtn;
        private Button _resumeBtn;
        private Button _mainMenuBtn;
        private Transform _pauseMenu;
        private TextMeshProUGUI _scoreText;
        private TextMeshProUGUI _bestScoreText;

        private UIModel _uiModel;
        private ScoreData _scoreData;
        private SnakeModelView _snakeModelView;
        public Button MenuBtn { get => _menuBtn; }
        public Button ResumeBtn { get => _resumeBtn; }
        public Button MainMenuBtn { get => _mainMenuBtn; }

        public event Action<bool> OnPauseGame;

        public UIModelView(UIModel uiModel, ScoreData scoreData, SnakeModelView snakeModelView)
        {
            _uiModel = uiModel;
            _menuBtn = _uiModel.MenuBtn;
            _resumeBtn = _uiModel.ResumeBtn;
            _mainMenuBtn = _uiModel.MainMenuBtn;
            _pauseMenu = _uiModel.PauseMenu;
            _scoreData = scoreData;
            _scoreText = _uiModel.ScoreText;
            _bestScoreText = uiModel.BestScoreText;
            _snakeModelView = snakeModelView;
            _snakeModelView.OnEatApple += SetCurrentScore;
            SetActivePanel();
        }

        public void SetCurrentScore(int currentScore)
        {
            _scoreData.CurrentScore += currentScore;
            _scoreText.text = _scoreData.CurrentScore.ToString();
            _scoreData.AddToScoreList();
            ScoreListToText();
        }

        public void ScoreListToText()
        {
            for (int i = 0; i < _scoreData.ScoreList.Count; i++)
            {
                _bestScoreText.text = i + 1 + " " + _scoreData.ScoreList[i].ToString();
            }
            
        }

        public void IsPauseGame()
        {

            _uiModel.PauseGame();
            SetActivePanel();
            OnPauseGame?.Invoke(_uiModel.IsPaused);
        }

        public void SetActivePanel()
        {
            _pauseMenu.gameObject.SetActive(_uiModel.IsPaused);
        }

        public void LoadScene()
        {
            _uiModel.MainMenuLoad();
        }

    }
}
