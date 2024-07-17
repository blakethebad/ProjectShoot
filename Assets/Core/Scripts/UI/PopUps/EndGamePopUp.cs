using System;
using UnityEngine;
using UnityEngine.Pool;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class EndGamePopUp : UIPopUp, IPopUp
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _retryButton;

        public static event Action OnMainMenuPressed;
        public static event Action OnRetryPressed; 

        public void Show()
        {
            _mainMenuButton.onClick.AddListener((() =>
            {
                OnMainMenuPressed?.Invoke();
                Hide();
            }));
            
            _retryButton.onClick.AddListener((() =>
            {
                OnRetryPressed?.Invoke();
                Hide();
            }));
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}