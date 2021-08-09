using System;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace MVVM
{
    public sealed class UIModelView
    {
        private Button _menuBtn;
        private Button _resumeBtn;
        private Button _mainMenuBtn;
        private Button _resetBestScore;
        private Button _loseMenuBtn;
        private Button _muted;
        private Sprite _muteSprite;
        private Sprite _unMuteSprite;
        private Image _muteSpriteImage;

        private Transform _pauseMenu;
        private Transform _loseMenu;

        private TextMeshProUGUI _scoreText;
        private TextMeshProUGUI _bestScoreText;
        private TextMeshProUGUI _loseScoreText;
        private TextMeshProUGUI _loseBestScoreText;

        private UIModel _uiModel;
        private ScoreJson _scoreJson;
        public Button MenuBtn { get => _menuBtn; }
        public Button ResumeBtn { get => _resumeBtn; }
        public Button MainMenuBtn { get => _mainMenuBtn; }
        public Button ResetBestScore { get => _resetBestScore; }
        public Button LoseMenuBtn { get => _loseMenuBtn; }
        public Button Muted { get => _muted; }
        public Sprite MuteSprite { get => _muteSprite; }
        public Sprite UnMuteSprite { get => _unMuteSprite; }
        public Image MuteSpriteRenderer { get => _muteSpriteImage; }

        private bool _muteClicked = false;

        public event Action<bool> OnPauseGame;

        public UIModelView(UIModel uiModel, ScoreJson scoreJson)
        {
            _uiModel = uiModel;
            _menuBtn = _uiModel.MenuBtn;
            _resumeBtn = _uiModel.ResumeBtn;
            _mainMenuBtn = _uiModel.MainMenuBtn;
            _pauseMenu = _uiModel.PauseMenu;
            _loseMenu = _uiModel.LoseMenu;
            _muted = _uiModel.Muted;
            _muteSprite = _uiModel.MuteSprite;
            _unMuteSprite = _uiModel.UnMuteSprite;
            _muteSpriteImage = _uiModel.MuteSpriteImage;
            _scoreText = _uiModel.ScoreText;
            _loseMenuBtn = uiModel.LoseMenuBtn;
            _resetBestScore = _uiModel.ResetBestScore;
            _bestScoreText = uiModel.BestScoreText;
            _loseBestScoreText = uiModel.LoseBestScoreText;
            _loseScoreText = uiModel.LoseScoreText;
            _scoreJson = scoreJson;
            _scoreJson.OnScoreChanged += ShowScore;
            _loseMenu.gameObject.SetActive(false);
            SetActivePanel();
          
        }


        public void IsPauseGame()
        {
            _uiModel.PauseGame();
            SetActivePanel();
            OnPauseGame?.Invoke(_uiModel.IsPaused);
            ShowScore(_scoreJson.Score.bestScore, _scoreJson.Score._currentScore);
        }

        public void MuteSound()
        {
            _muteClicked = !_muteClicked;
            if (_muteClicked)
            {
                _uiModel.MuteSound();
                _muteSpriteImage.sprite = _uiModel.MuteSprite;
            }
            else
            {
                _uiModel.MuteSound();
                _muteSpriteImage.sprite = _uiModel.UnMuteSprite;
            }
           
        }

        public void SetActivePanel()
        {
            _pauseMenu.gameObject.SetActive(_uiModel.IsPaused);
        }

        public void LoadScene()
        {
            _uiModel.MainMenuLoad();
        }

        public void ShowScore(int bestScore, int currentScore)
        {
            _scoreText.text = "Score: " + currentScore.ToString();
            _bestScoreText.text = "Best Score: " + bestScore.ToString();
            _loseBestScoreText.text = "Best Score: " + bestScore.ToString();
            _loseScoreText.text = "Your score: " + currentScore.ToString();
        }

        public void ResetBestScoreMethod()
        {
            _scoreJson.ResetBestScore();
        }

        public void LooseGame(bool isDead)
        {
            if (isDead)
            {
                _uiModel.PauseGame();
                _loseMenu.gameObject.SetActive(true);
            }
        }

    }
}
