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
    public class WindowDefinition
    {
    }

    public class GameWindowDefinition : WindowDefinition
    {
        public Action<int> PowerUpButtonPressed;
        public Action OnExitButtonPressed;

        public GameWindowDefinition(Action<int> onPowerUpPressed, Action onExitPressed)
        {
            PowerUpButtonPressed = onPowerUpPressed;
            OnExitButtonPressed = onExitPressed;
        }
    }
    
    
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

            foreach (Button button in _powerUpButtons)
            {
                button.onClick.AddListener((() =>
                {
                    int index = _powerUpButtons.IndexOf(button);
                    _onPowerUpPressed.Invoke(index);
                }));
            }
        }

        void OnPowerUpEnable(PowerUpEvent powerUpEvent)
        {
            _powerUpButtons[powerUpEvent.EnabledIndex].image.color = _selectedColor;
        }

        void OnPowerUpDisable(PowerUpEvent powerUpEvent)
        {
            _powerUpButtons[powerUpEvent.DisabledIndex].image.color = _defaultColor;
        }
        
        public override void Close()
        {
            gameObject.SetActive(false);
            EventMediator.PowerUpEnableEvent.Unbind(OnPowerUpEnable);
            EventMediator.PowerUpDisableEvent.Unbind(OnPowerUpDisable);
        }
    }
}