﻿using System;
using UnityEngine;
using UnityEngine.UI;

namespace CaseWixot.Core.Scripts.UI
{
    public class MainMenuWindow : UIWindow
    {
        [SerializeField] private Button _playButton;

        private Action _onPlayPressed;
        
        public override void Open(WindowContext context)
        {
            gameObject.SetActive(true);
            _onPlayPressed = ((MainMenuContext)context).OnMainMenuPressed;
            _playButton.onClick.AddListener(OnPlayPressed);
        }

        private void OnPlayPressed()
        {
            _onPlayPressed.Invoke();
        }

        public override void Close()
        {
            gameObject.SetActive(false);
            _playButton.onClick.RemoveListener(OnPlayPressed);
        }
    }
}