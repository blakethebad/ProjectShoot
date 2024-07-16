using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class GameWindow : UIWindow
    {
        [SerializeField] private UIPanel _powerUpPanel;
        [SerializeField] private UIPanel _timerPanel;
        [SerializeField] private UIPanel _scorePanel;
        
        private void Start()
        {
            _powerUpPanel.Open();
        }

        public override void Open()
        {
            _powerUpPanel.Open();
        }

        public override void Close()
        {
            _powerUpPanel.Close();
        }
    }
}