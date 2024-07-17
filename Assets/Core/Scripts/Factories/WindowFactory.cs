using System.Collections.Generic;
using CaseWixot.Core.Scripts.UI;
using UnityEditor.PackageManager.UI;

namespace CaseWixot.Core.Scripts
{
    public enum WindowKey
    {
        GameWindow,
        MainMenuWindow,
    }
    
    public class WindowFactory : IWindowFactory
    {
        private UIPanel _gameWindow;
        private UIPanel _mainMenuWindow;

        private Dictionary<WindowKey, UIWindow> _windows;

        public WindowFactory(UIWindow gameWindow, UIWindow mainMenuWindow) //Get them from pool
        {
            _windows = new Dictionary<WindowKey, UIWindow>()
            {
                { WindowKey.GameWindow, gameWindow },
                { WindowKey.MainMenuWindow, mainMenuWindow }
            };
        }

        public void Pull(WindowKey windowType)
        {
            if (_windows.TryGetValue(windowType, out UIWindow window))
            {
                window.Open();
            }
        }

        public void Release(WindowKey windowType)
        {
            if (_windows.TryGetValue(windowType, out UIWindow window))
            {
                window.Close();
            }
        }
    }

    public interface IWindowFactory
    {
        void Pull(WindowKey windowType);
        void Release(WindowKey windowType);
    }
}