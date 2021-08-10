using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public interface IUIModel
    {
        public Button MenuBtn { get ; }
        public Button ResumeBtn { get ; }
        public Button MainMenuBtn { get ; }
        public Button ResetBestScore { get ; }
        public Button LoseMenuBtn { get ; }
        public Button Muted { get ; }
        public Transform PauseMenu { get ; }
        public Transform LoseMenu { get ; }
        public TextMeshProUGUI BestScoreText { get ; }
        public TextMeshProUGUI ScoreText { get ; }
        public TextMeshProUGUI LoseScoreText { get ; }
        public TextMeshProUGUI LoseBestScoreText { get ; }
        public Sprite MuteSprite { get ; }
        public Sprite UnMuteSprite { get ; }
        public Image MuteSpriteImage { get ; }

        public bool IsPaused { get ; }

        public bool IsMuted { get ; }

        public void PauseGame();

        public void MuteSound();

        public void MainMenuLoad();


    }
}
