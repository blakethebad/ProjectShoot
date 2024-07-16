using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class GameWindow : UIWindow
    {
        [SerializeField] private UIPanel _powerUpPanel;
        [SerializeField] private TimerPanel _timerPanel;
        [SerializeField] private ScorePanel _scorePanel;
        
        private void Start()
        {
            _powerUpPanel.Open();
        }
    }
}