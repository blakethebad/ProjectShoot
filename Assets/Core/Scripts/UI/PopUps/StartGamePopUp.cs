using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class StartGamePopUp : UIPopUp
    {
        [SerializeField] private Button _tapToStartBtn;

        private StartGamePopUpContext _context;
        public override void Show(PopUpContext popUpContext)
        {
            gameObject.SetActive(true);
            _context = ((StartGamePopUpContext)popUpContext);
            _tapToStartBtn.onClick.AddListener(OnTap);
        }

        private void OnTap()
        {
            _context.OnScreenTap.Invoke();
            Hide();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            _tapToStartBtn.onClick.RemoveListener(OnTap);
        }
    }
}