using UnityEngine;

namespace CaseWixot.Core.Scripts.UI
{
    public class GameWindow : UIWindow
    {
        [SerializeField] private PowerUpPanel _powerUpPanel;

        public IPowerUpPublisher PowerUpPublisher;

        private void Start()
        {
            PowerUpPublisher = _powerUpPanel;
            _powerUpPanel.Open();
        }
    }
}