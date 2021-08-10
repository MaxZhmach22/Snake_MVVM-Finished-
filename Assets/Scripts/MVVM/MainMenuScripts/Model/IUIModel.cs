using UnityEngine;
using UnityEngine.UI;

namespace MVVM.MainMenu
{
    public interface IUIModel
    {
        public Transform MainMenu { get ; }
        public Transform HowToPlayMenu { get ; }
        public Button PlayBtn { get ; }
        public Button QuitBtn { get ; }
        public Button HowToPlayBtn { get ; }
        public Button BackBtn { get ; }

        public void MainSceneLoad();
        public void ShowHowToPlayMenu();

        public void QuitApplication();

        public void HideHowToPlayMenu();

    }
}
