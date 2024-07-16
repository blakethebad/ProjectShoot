using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public enum PopUpType
    {
        StartGamePopUp,
        EndGamePopUp,
    }

    public enum WindowType
    {
        GameWindow,
        MainMenu
    }

    public class PopUpContext
    {
        
    }

    public class StartGameContext : PopUpContext
    {
        public Action OnTapPressed;

        public StartGameContext(Action onTapPressed)
        {
            OnTapPressed = onTapPressed;
        }
    }
    
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance;
        
        [SerializeField] private UIWindow _gameWindow;
        [SerializeField] private UIWindow _mainMenuWindow;

        [SerializeField] private UIPopUp _startGamePopUp;
        [SerializeField] private UIPopUp _endGamePopUp;


        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(this);
            }

            DontDestroyOnLoad(this);
        }

        public void OpenWindow(WindowType windowType)
        {
            if (windowType == WindowType.GameWindow)
            {
                _gameWindow.Open();
            }
        }

        public void OpenPopUp(PopUpType popUpType, PopUpContext context = null)
        {
            if (popUpType == PopUpType.StartGamePopUp)
            {
                _startGamePopUp.Show(context);
            }

            if (popUpType == PopUpType.EndGamePopUp)
            {
                _endGamePopUp.Show(context);
            }
        }
        
    }
}