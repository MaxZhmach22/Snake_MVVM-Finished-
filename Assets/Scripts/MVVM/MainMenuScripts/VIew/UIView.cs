using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM.MainMenu
{
    public sealed class UIView : MonoBehaviour
    {
        private Button _playBtn;
        private Button _quitBtn;
        private Button _howToPlayBtn;
        private Button _backBtn;
        private List<Button> _buttons = new List<Button>();
        private IUIModelView _uIModelView;
        private GameData _gameData;
        private AudioSource _audioSource;

       public void Initialize(IUIModelView uIModelView, GameData gameData)
       {
            _uIModelView = uIModelView;
            _gameData = gameData;
            _playBtn = _uIModelView.PlayBtn;
            _quitBtn = _uIModelView.QuitBtn;
            _howToPlayBtn = _uIModelView.HowToPlayBtn;
            _backBtn = _uIModelView.BackBtn;
            _audioSource = gameObject.GetComponent<AudioSource>();
            AddToTheButtonsList();
            AddListenersToButtons();
       }

        public void AddToTheButtonsList()
        {
            _buttons.Add(_playBtn);
            _buttons.Add(_quitBtn);
            _buttons.Add(_howToPlayBtn);
            _buttons.Add(_backBtn);
        }

        public void AddListenersToButtons()
        {
            foreach (var button in _buttons)
            {
                button.onClick.AddListener(() => _audioSource.PlayOneShot(_gameData.ClickSound));
            }
            _playBtn.onClick.AddListener(() => _uIModelView.MainSceneLoad());
            _howToPlayBtn.onClick.AddListener(() => _uIModelView.ShowHowToPlayMenu());
            _quitBtn.onClick.AddListener(() => _uIModelView.QuitApplication());
            _backBtn.onClick.AddListener(() => _uIModelView.HideHowToPlayMenu());
        }
    }
}
