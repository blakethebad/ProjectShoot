using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.EventSystem.Events;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEditor.PackageManager.UI;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI
{
    public class PowerUpPanel : UIPanel
    {
        [SerializeField] private List<Button> _powerUpButtons;
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _defaultColor;

        private Action<int> _onPowerUpPressed;
        
        public override void Open(WindowDefinition windowDefinition)
        {
            gameObject.SetActive(true);
            _onPowerUpPressed = ((GameWindowDefinition)windowDefinition).PowerUpButtonPressed;
            EventMediator.PowerUpEnableEvent.Bind(OnPowerUpEnable);
            EventMediator.PowerUpDisableEvent.Bind(OnPowerUpDisable);
            EventMediator.PowerUpAddedEvent.Bind(OnPowerUpAdded);
        }

        void OnPowerUpAdded(PowerUpDeckEvent powerUpDeckEvent)
        {
            _powerUpButtons[powerUpDeckEvent.Index].gameObject.SetActive(true);
            _powerUpButtons[powerUpDeckEvent.Index].onClick.AddListener((() =>
            {
                _onPowerUpPressed.Invoke(powerUpDeckEvent.Index);
            }));
        }

        void OnPowerUpEnable(PowerUpToggleEvent powerUpToggleEvent)
        {
            _powerUpButtons[powerUpToggleEvent.EnabledIndex].image.color = _selectedColor;
        }

        void OnPowerUpDisable(PowerUpToggleEvent powerUpToggleEvent)
        {
            _powerUpButtons[powerUpToggleEvent.DisabledIndex].image.color = _defaultColor;
        }
        
        public override void Close()
        {
            gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            EventMediator.PowerUpEnableEvent.Unbind(OnPowerUpEnable);
            EventMediator.PowerUpDisableEvent.Unbind(OnPowerUpDisable);
            EventMediator.PowerUpAddedEvent.Unbind(OnPowerUpAdded);
        }
    }
}