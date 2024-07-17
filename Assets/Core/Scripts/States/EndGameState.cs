using System;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CaseWixot.Core.Scripts.States
{
    //The state in which the timer is over or the player stopped the game
    public class EndGameState : BaseGameState
    {
        private readonly IPopUpFactory _popUpFactory;
        
        public EndGameState(Action<GameState> changeStateCallback, IPopUpFactory popUpFactory) : base(changeStateCallback)
        {
            _popUpFactory = popUpFactory;
        }

        public override void EnterState()
        {
            _popUpFactory.Pull(PopUpType.EndGame);
            EndGamePopUp.OnMainMenuPressed += OnMenuButtonPressed;
            EndGamePopUp.OnRetryPressed += OnRetryPressed;
        }

        public override void ExitState()
        {
            EndGamePopUp.OnMainMenuPressed -= OnMenuButtonPressed;
            EndGamePopUp.OnRetryPressed -= OnRetryPressed;
        }

        public void OnMenuButtonPressed()
        {
            SceneManager.UnloadSceneAsync(0);
            SceneManager.LoadScene(0);
        }

        public void OnRetryPressed()
        {
            SceneManager.UnloadSceneAsync(0);
            SceneManager.LoadScene(0);
        }
    }
}