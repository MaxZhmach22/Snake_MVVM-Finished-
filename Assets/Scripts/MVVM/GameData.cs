using System;
using UnityEngine;

namespace MVVM
{
    [CreateAssetMenu (fileName = "Data", menuName = "Game Data", order = 1)]
   public sealed class GameData : ScriptableObject
    {
        [SerializeField] private Sprite _backgroundSprite;
        [SerializeField] private Sprite _snakeHead;
        [SerializeField] private Sprite _snakeBody;
        [SerializeField] private Sprite _appleSprite;
        [SerializeField] private Sprite _mute;
        [SerializeField] private Sprite _unMute;

        [SerializeField] private AudioClip _eatSound;
        [SerializeField] private AudioClip _loseSound;
        [SerializeField] private AudioClip _clickSound;
        [SerializeField] private AudioClip _backGroundMusic;

        private bool _isMuted = false;

        public Action<bool> OnMutedSound;

        public Sprite BackgroundSprite { get => _backgroundSprite; }
        public Sprite SnakeHead { get => _snakeHead; }
        public Sprite SnakeBody { get => _snakeBody;  }
        public Sprite AppleSprite { get => _appleSprite; }
        public AudioClip EatSound { get => _eatSound; }
        public AudioClip LoseSound { get => _loseSound; }
        public AudioClip ClickSound { get => _clickSound; }
        public AudioClip BackGroundMusic { get => _backGroundMusic; }
        public Sprite Mute { get => _mute; }
        public Sprite UnMute { get => _unMute; }
        public bool IsMuted { get => _isMuted; set => _isMuted = value; }

        public void MuteSound()
        {
            _isMuted = !IsMuted;
            OnMutedSound?.Invoke(IsMuted);
        }
    }

    
}
