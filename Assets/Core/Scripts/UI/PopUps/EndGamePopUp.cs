using System;
using CaseWixot.Core.Scripts.PowerUps;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class EndGamePopUpDefinition : PopUpDefinition
    {
        public Action OnMainMenuPressed;
        public Action OnRetryPressed;

        public EndGamePopUpDefinition(Action onMainMenuPressed, Action onRetryPressed)
        {
            OnMainMenuPressed = onMainMenuPressed;
            OnRetryPressed = onRetryPressed;
        }
    }
    public class EndGamePopUp : UIPopUp
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _retryButton;

        private EndGamePopUpDefinition _definition;

        public override void Show(PopUpDefinition popUpDefinition)
        {
            _definition = ((EndGamePopUpDefinition)popUpDefinition);
            _mainMenuButton.onClick.AddListener(OnMainMenuPressed);
            _retryButton.onClick.AddListener(OnRetryPressed);
            
            gameObject.SetActive(true);
        }

        private void OnMainMenuPressed()
        {
            _definition.OnMainMenuPressed.Invoke();
            Hide();
        }

        private void OnRetryPressed()
        {
            _definition.OnRetryPressed.Invoke();
            Hide();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuPressed);
            _retryButton.onClick.RemoveListener(OnRetryPressed);
        }
    }
}