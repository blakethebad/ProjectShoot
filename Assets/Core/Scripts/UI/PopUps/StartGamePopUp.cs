using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class StartGamePopUp : UIPopUp
    {
        [SerializeField] private Button _tapToStartBtn;
        private StartGameContext _context;

        public override void Show(PopUpContext context = null)
        {
            _context = (StartGameContext) context;
            gameObject.SetActive(true);
            _tapToStartBtn.onClick.AddListener((OnTap));
        }


        public override void Hide()
        {
            gameObject.SetActive(false);
        }

        private void OnTap()
        {
            _context.OnTapPressed.Invoke();
            Hide();
        }
    }
}