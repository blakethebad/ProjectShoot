﻿using System;
using System.Collections.Generic;
using ProjectShoot.Core.EventSystem;
using ProjectShoot.Core.EventSystem.Events;
using ProjectShoot.Core.UI.Windows;
using ProjectShoot.Core.UI.Windows.Context;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectShoot.Core.UI.Panels
{
    public class PowerUpPanel : UIPanel
    {
        [SerializeField] private List<Button> _powerUpButtons;
        [SerializeField] private Color _selectedColor;
        [SerializeField] private Color _defaultColor;

        private Action<int> _onPowerUpPressed;
        
        public override void Open(WindowContext windowContext)
        {
            gameObject.SetActive(true);
            _onPowerUpPressed = ((GameWindowContext)windowContext).PowerUpButtonPressed;
            GameEvents.PowerUpEnableEvent.Bind(OnPowerUpEnable);
            GameEvents.PowerUpDisableEvent.Bind(OnPowerUpDisable);
            GameEvents.PowerUpAddedEvent.Bind(OnPowerUpAdded);
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
            foreach (var powerUpButton in _powerUpButtons)
            {
                powerUpButton.image.color = _defaultColor;
                powerUpButton.onClick.RemoveAllListeners();
            }
            
            GameEvents.PowerUpEnableEvent.Unbind(OnPowerUpEnable);
            GameEvents.PowerUpDisableEvent.Unbind(OnPowerUpDisable);
            GameEvents.PowerUpAddedEvent.Unbind(OnPowerUpAdded);
        }
    }
}