using System;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public interface IUIIModelView
    {
        public Button MenuBtn { get; }
        public Button ResumeBtn { get ; }
        public Button MainMenuBtn { get ; }
        public Button ResetBestScore { get ; }
        public Button LoseMenuBtn { get ; }
        public Button Muted { get ; }
        public Sprite MuteSprite { get ; }
        public Sprite UnMuteSprite { get ; }
        public Image MuteSpriteRenderer { get ; }

        public event Action<bool> OnPauseGame;

        public void SetActivePanel();

        public void LoadScene();

        public void ResetBestScoreMethod();

        public void LooseGame(bool isDead);

        public void MuteSound();

        public void IsPauseGame();


    }
}
