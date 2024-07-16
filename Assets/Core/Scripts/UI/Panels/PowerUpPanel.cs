using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI
{
    public class PowerUpPanel : UIPanel 
    {
        [SerializeField] private List<Button> _powerUpButtons;
        public event Action<int> OnPowerUpPressed;


        public override void Open()
        {
            _powerUpButtons[0].onClick.AddListener((() =>
            {
                OnPowerUpPressed?.Invoke(0);
            }));
            _powerUpButtons[1].onClick.AddListener((() =>
            {
                OnPowerUpPressed?.Invoke(1);
            }));
            _powerUpButtons[2].onClick.AddListener((() =>
            {
                OnPowerUpPressed?.Invoke(2);
            }));
            _powerUpButtons[3].onClick.AddListener((() =>
            {
                OnPowerUpPressed?.Invoke(3);
            }));
            _powerUpButtons[4].onClick.AddListener((() =>
            {
                OnPowerUpPressed?.Invoke(4);
            }));
            
        }

        public override void Close()
        {
        }

    }
}