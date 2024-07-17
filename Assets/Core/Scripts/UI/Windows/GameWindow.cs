using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI
{
    public class GameWindow : UIWindow
    {
        [SerializeField] private UIPanel _powerUpPanel;
        [SerializeField] private UIPanel _scorePanel;
        [SerializeField] private Button _exitButton;

        private GameWindowDefinition _definition;

        public override void Open(WindowDefinition definition)
        {
            _definition = ((GameWindowDefinition)definition);
            _powerUpPanel.Open(definition);
            _scorePanel.Open(definition);

            _exitButton.gameObject.SetActive(true);
            _exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        private void OnExitButtonPressed()
        {
            _definition.OnExitButtonPressed.Invoke();
        }

        public override void Close()
        {
            _powerUpPanel.Close();
            _scorePanel.Close();
            
            _exitButton.onClick.RemoveListener(OnExitButtonPressed);
            _exitButton.gameObject.SetActive(false);
        }
    }
}