using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class EndGameContext : PopUpContext
    {
        public Action OnMainMenuPressed;
        public Action OnRetryPressed;

        public EndGameContext(Action onMainMenuPressed, Action onRetryPressed)
        {
            OnMainMenuPressed = onMainMenuPressed;
            OnRetryPressed = onRetryPressed;
        }
    }
    
    public class EndGamePopUp : UIPopUp
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _retryButton;
        private EndGameContext _context;
        
        public override void Show(PopUpContext endGameContext)
        {
            _context = (EndGameContext)endGameContext;
            gameObject.SetActive(true);
            _mainMenuButton.onClick.AddListener(OnMainMenuPressed);
            _retryButton.onClick.AddListener(OnRetryPressed);
        }


        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnMainMenuPressed()
        {
            _context.OnMainMenuPressed.Invoke();
            Hide();
        }

        private void OnRetryPressed()
        {
            _context.OnRetryPressed.Invoke();
            Hide();
        }
    }
}