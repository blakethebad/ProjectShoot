using ProjectShoot.Core.UI.PopUps.Context;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectShoot.Core.UI.PopUps
{
    public class EndGamePopUp : UIPopUp
    {
        [SerializeField] private Button _mainMenuButton;
        [SerializeField] private Button _retryButton;

        private EndGamePopUpContext _context;

        public override void Show(PopUpContext popUpContext)
        {
            _context = ((EndGamePopUpContext)popUpContext);
            _mainMenuButton.onClick.AddListener(OnMainMenuPressed);
            _retryButton.onClick.AddListener(OnRetryPressed);
            
            gameObject.SetActive(true);
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

        public override void Hide()
        {
            gameObject.SetActive(false);
            _mainMenuButton.onClick.RemoveListener(OnMainMenuPressed);
            _retryButton.onClick.RemoveListener(OnRetryPressed);
        }
    }
}