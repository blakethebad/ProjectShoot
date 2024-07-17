using System;
using CaseWixot.Core.Scripts.PowerUps;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class PopUpDefinition
    {
        
    }

    public class StartGamePopUpDefinition : PopUpDefinition
    {
        public Action OnScreenTap;
        public StartGamePopUpDefinition(Action onScreenTap)
        {
            OnScreenTap = onScreenTap;
        }
    }
    public class StartGamePopUp : UIPopUp
    {
        [SerializeField] private Button _tapToStartBtn;

        private StartGamePopUpDefinition _definition;
        public override void Show(PopUpDefinition popUpDefinition)
        {
            gameObject.SetActive(true);
            _definition = ((StartGamePopUpDefinition)popUpDefinition);
            _tapToStartBtn.onClick.AddListener(OnTap);
        }

        private void OnTap()
        {
            _definition.OnScreenTap.Invoke();
            Hide();
        }

        public override void Hide()
        {
            gameObject.SetActive(false);
            _tapToStartBtn.onClick.RemoveListener(OnTap);
        }
    }
}