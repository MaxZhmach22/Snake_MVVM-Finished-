using UnityEngine.UI;

namespace MVVM.MainMenu
{
    interface IUIView
    {

        public Button PlayBtn { get; }
        public Button QuitBtn { get; }
        public Button HowToPlayBtn { get; }
        public Button BackBtn { get; }
    }
}
