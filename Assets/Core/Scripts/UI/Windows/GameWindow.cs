using ProjectShoot.Core.UI.Panels;
using ProjectShoot.Core.UI.Windows.Context;
using UnityEngine;
using UnityEngine.UI;

namespace ProjectShoot.Core.UI.Windows
{
    public abstract class WindowContext
    {
    }
    public class GameWindow : UIWindow
    {
        [SerializeField] private UIPanel _powerUpPanel;
        [SerializeField] private Button _exitButton;

        private GameWindowContext _context;

        public override void Open(WindowContext context)
        {
            _context = ((GameWindowContext)context);
            _powerUpPanel.Open(context);

            _exitButton.gameObject.SetActive(true);
            _exitButton.onClick.AddListener(OnExitButtonPressed);
        }

        private void OnExitButtonPressed()
        {
            _context.OnExitButtonPressed.Invoke();
        }

        public override void Close()
        {
            _powerUpPanel.Close();
            
            _exitButton.onClick.RemoveListener(OnExitButtonPressed);
            _exitButton.gameObject.SetActive(false);
        }
    }
}