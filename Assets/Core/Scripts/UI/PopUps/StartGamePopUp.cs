using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class StartGamePopUp : UIPopUp, IPopUp
    {
        [SerializeField] private Button _tapToStartBtn;

        public static event Action OnTap;
        
        public void Show()
        {
            gameObject.SetActive(true);
            _tapToStartBtn.onClick.AddListener((() =>
            {
                OnTap?.Invoke();
                Hide();
            }));
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}