using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace MVVM.MainMenu
{
    public class UIModel : IUIModel
    {
        private Transform _mainMenu;
        private Transform _howToPlayMenu;
        private Button _playBtn;
        private Button _quitBtn;
        private Button _howToPlayBtn;
        private Button _backBtn;
       

        public Transform MainMenu { get => _mainMenu; }
        public Transform HowToPlayMenu { get => _howToPlayMenu; }
        public Button PlayBtn { get => _playBtn; }
        public Button QuitBtn { get => _quitBtn; }
        public Button HowToPlayBtn { get => _howToPlayBtn; }
        public Button BackBtn { get => _backBtn; }
        

        public UIModel()
        {
            FindReferenceMethod();
        }

        private void FindReferenceMethod()
        {
            _mainMenu = GameObject.Find("MainMenu").transform;
            _howToPlayMenu = GameObject.Find("HowToPlaySubMenu").transform;
            _playBtn = GameObject.Find("playBtn").GetComponent<Button>();
            _quitBtn = GameObject.Find("quitBtn").GetComponent<Button>();
            _howToPlayBtn = GameObject.Find("howToPlayBtn").GetComponent<Button>();
            _backBtn = GameObject.Find("backBtn").GetComponent<Button>();
            
            
        }

        public void MainSceneLoad()
        {
            SceneManager.LoadScene("GameScene");
        }

        public void ShowHowToPlayMenu()
        {
            _howToPlayMenu.gameObject.SetActive(true);
            _howToPlayMenu.gameObject.GetComponent<RectTransform>().localPosition = Vector3.zero;
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        public void HideHowToPlayMenu()
        {
            _howToPlayMenu.gameObject.GetComponent<RectTransform>().localPosition = new Vector3(2000,0,0);
            _howToPlayMenu.gameObject.SetActive(false);
        }
    }
}
