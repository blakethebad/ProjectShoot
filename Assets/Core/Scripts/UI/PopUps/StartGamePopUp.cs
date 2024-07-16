using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public class StartGamePopUp : UIPopUp
    {
        [SerializeField] private Button _tapToStartBtn;

        private void Start()
        {
            Show();
        }

        public override void Show()
        {
            
            _tapToStartBtn.onClick.AddListener((() =>
            {
                Debug.LogError("Tap detected");
            }));
        }

        public override void Hide()
        {
        }
    }
}