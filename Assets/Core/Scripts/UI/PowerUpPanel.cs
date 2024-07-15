using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI
{
    public class PowerUpPanel : UIPanel , IPowerUpPublisher
    {
        [SerializeField] private List<Button> _powerUpButtons;
        public event Action<int> PowerUpActivated;

        public override void Open()
        {
            _powerUpButtons[0].onClick.AddListener((() =>
            {
                PowerUpActivated?.Invoke(0);
            }));
            _powerUpButtons[1].onClick.AddListener((() =>
            {
                PowerUpActivated?.Invoke(1);
            }));
            _powerUpButtons[2].onClick.AddListener((() =>
            {
                PowerUpActivated?.Invoke(2);
            }));
            _powerUpButtons[3].onClick.AddListener((() =>
            {
                PowerUpActivated?.Invoke(3);
            }));
            _powerUpButtons[4].onClick.AddListener((() =>
            {
                PowerUpActivated?.Invoke(4);
            }));
            
        }

        public override void Close()
        {
        }

    }
}