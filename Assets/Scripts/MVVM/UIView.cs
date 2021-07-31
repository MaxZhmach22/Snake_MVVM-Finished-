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
        private Transform _pauseMenu;

        public void Initialize(UIModelView uIModelView)
        {
            _menuBtn = uIModelView.MenuBtn;
            _menuBtn.onClick.AddListener(() => uIModelView.IsPauseGame());
        }


    }
}
