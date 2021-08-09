using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MVVM
{ 

    public sealed class UIModel
    {
        private TextMeshProUGUI _scoreText;
        private TextMeshProUGUI _bestScoreText;
        private TextMeshProUGUI _loseScoreText;
        private TextMeshProUGUI _loseBestScoreText;
        private Button _menuBtn;
        private Button _resumeBtn;
        private Button _mainMenuBtn;
        private Button _resetBestScore;
        private Button _loseMenuBtn;
        private Button _muted;
        private Transform _pauseMenu;
        private Transform _loseMenu;
        private Sprite _muteSprite;
        private Sprite _unMuteSprite;
        private Image _muteSpriteImage;
        private bool isPaused = false;
        private bool _isMuted = false;
        private GameData _gameData;


        public Button MenuBtn { get => _menuBtn; }
        public Button ResumeBtn { get => _resumeBtn; }
        public Button MainMenuBtn { get => _mainMenuBtn; }
        public Button ResetBestScore { get => _resetBestScore; }
        public Button LoseMenuBtn { get => _loseMenuBtn; }
        public Button Muted { get => _muted; }
        public Transform PauseMenu { get => _pauseMenu; }
        public Transform LoseMenu { get => _loseMenu; }
        public TextMeshProUGUI BestScoreText { get => _bestScoreText; }
        public TextMeshProUGUI ScoreText { get => _scoreText; }
        public TextMeshProUGUI LoseScoreText { get => _loseScoreText; }
        public TextMeshProUGUI LoseBestScoreText { get => _loseBestScoreText; }
        public Sprite MuteSprite { get => _muteSprite; }
        public Sprite UnMuteSprite { get => _unMuteSprite; }
        public Image MuteSpriteImage { get => _muteSpriteImage; }

        public bool IsPaused { get => isPaused; }

        public bool IsMuted { get => _isMuted; }

        public UIModel(GameData gameData)
        {
            _gameData = gameData;
            FindReferenceMethod();
            _scoreText.text = "Score: 0";
        }

        private void FindReferenceMethod()
        {
            _pauseMenu = GameObject.Find("PauseMenu").transform;
            _loseMenu = GameObject.Find("LoseMenu").transform;
            _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            _bestScoreText = GameObject.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
            _loseScoreText = GameObject.Find("LoseCurrentScoreText").GetComponent<TextMeshProUGUI>();
            _loseBestScoreText = GameObject.Find("LoseBestScoreText").GetComponent<TextMeshProUGUI>();
            _menuBtn = GameObject.Find("MenuBtn").GetComponent<Button>();
            _resumeBtn = GameObject.Find("ResumeBtn").GetComponent<Button>();
            _resetBestScore = GameObject.Find("ResetBestScoreBtn").GetComponent<Button>();
            _mainMenuBtn = GameObject.Find("MainMenuBtn").GetComponent<Button>();
            _loseMenuBtn = GameObject.Find("LoseMenuBtn").GetComponent<Button>();
            _muted = GameObject.Find("MuteBtn").GetComponent<Button>();
            _muteSpriteImage = GameObject.Find("MuteBtn").GetComponent<Image>();
            _muteSprite = _gameData.Mute;
            _unMuteSprite = _gameData.UnMute;
        }

  
        public void PauseGame()
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        public void MuteSound()
        {
            _gameData.MuteSound();
                
        }

        public void MainMenuLoad()
        {
            PauseGame();
            SceneManager.LoadScene("MainMenu");
        }

    }
}
