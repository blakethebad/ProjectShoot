using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class GameWindow : UIWindow
    {
        [SerializeField] private UIPanel _powerUpPanel;
        [SerializeField] private UIPanel _timerPanel;
        [SerializeField] private UIPanel _scorePanel;

        public override void Open()
        {
            _powerUpPanel.Open();
            _timerPanel.Open();
            _scorePanel.Open();
        }


        public override void Close()
        {
            _powerUpPanel.Close();
            _timerPanel.Close();
            _scorePanel.Close();
        }
    }
}