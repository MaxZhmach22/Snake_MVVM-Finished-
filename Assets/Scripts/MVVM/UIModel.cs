using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace MVVM
{ 
    //Класс, отвечающий за связывание и хранение ссылок на UI елементы, которые в дальнейшем будут переданы в UIModelView; 
    
    public sealed class UIModel
    {
        private TextMeshProUGUI _scoreText;
        private TextMeshProUGUI _bestScoreText;
        private int _score = 0;
        private int _bestScore;
        private Button _menuBtn;
        private Button _resumeBtn;
        private Button _mainMenuBtn;
        private Transform _pauseMenu;
        private bool isPaused = false;

        public Button MenuBtn { get => _menuBtn; }
        public Button ResumeBtn { get => _resumeBtn; }
        public Button MainMenuBtn { get => _mainMenuBtn; }
        public Transform PauseMenu { get => _pauseMenu; }
        public TextMeshProUGUI BestScoreText { get => _bestScoreText; }
        public TextMeshProUGUI ScoreText { get => _scoreText; }
        public bool IsPaused { get => isPaused; }

        public UIModel()
        {
            FindReferenceMethod();
            _scoreText.text = "Score: 0";
        }

        private void FindReferenceMethod()
        {
            _pauseMenu = GameObject.Find("PauseMenu").transform;
            _scoreText = GameObject.Find("ScoreText").GetComponent<TextMeshProUGUI>();
            _bestScoreText = GameObject.Find("BestScoreText").GetComponent<TextMeshProUGUI>();
            _menuBtn = GameObject.Find("MenuBtn").GetComponent<Button>();
            _resumeBtn = GameObject.Find("ResumeBtn").GetComponent<Button>();
            _mainMenuBtn = GameObject.Find("MainMenuBtn").GetComponent<Button>();
        }

        public void ScoreTextChange(int scoreChange)
        {
            if (scoreChange > 0)
            {
                _scoreText.text = scoreChange.ToString();
            }
        }

        public void PauseGame()
        {
            isPaused = !isPaused;

            if (isPaused)
            {
                Time.timeScale = 0;
                Debug.Log("Paused");
            }
            else
            {
                Time.timeScale = 1;
                Debug.Log("Resume");
            }
        }

        public void MainMenuLoad()
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
