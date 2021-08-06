using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace MVVM
{
    public sealed class UIView : MonoBehaviour
    {
        private Button _menuBtn;
        private Button _resumeBtn;
        private Button _mainMenuBtn;
        private Transform _pauseMenu;

        public void Initialize(UIModelView uIModelView)
        {
            _menuBtn = uIModelView.MenuBtn;
            _resumeBtn = uIModelView.ResumeBtn;
            _mainMenuBtn = uIModelView.MainMenuBtn;
            _resumeBtn.onClick.AddListener(() => uIModelView.IsPauseGame());
            _menuBtn.onClick.AddListener(() => uIModelView.IsPauseGame());
            _mainMenuBtn.onClick.AddListener(() => uIModelView.LoadScene());
        }


    }
}
