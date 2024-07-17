using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI
{
    public class MainMenuDefinition : WindowDefinition
    {
        public Action OnMainMenuPressed;

        public MainMenuDefinition(Action onMainMenuPressed)
        {
            OnMainMenuPressed = onMainMenuPressed;
        }
    }
    
    public class MainMenuWindow : UIWindow
    {
        [SerializeField] private Button _playButton;

        private Action _onPlayPressed;
        
        public override void Open(WindowDefinition definition)
        {
            gameObject.SetActive(true);
            _onPlayPressed = ((MainMenuDefinition)definition).OnMainMenuPressed;
            _playButton.onClick.AddListener((() =>
            {
                _onPlayPressed.Invoke();
            }));
        }

        public override void Close()
        {
            gameObject.SetActive(false);
        }
    }
}