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

    public interface IContext
    {
        
    }

    public class StartGameContext : IContext
    {
        
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

        public void OpenPopUp(PopUpType popUpType)
        {
            if (popUpType == PopUpType.StartGamePopUp)
            {
                _startGamePopUp.Show();
            }

            if (popUpType == PopUpType.EndGamePopUp)
            {
                _endGamePopUp.Show();
            }
        }
        
    }
}