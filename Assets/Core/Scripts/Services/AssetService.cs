using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;

namespace CaseWixot.Core.Scripts.Services
{
    public interface IAssetService : IService
    {
        public T GetAsset<T>(object key);
    }
    
    public class AssetService : IAssetService
    {
        private Dictionary<string, object> _objects;

        public AssetService(UIWindow gameWindow, UIWindow mainMenuWindow, UIPopUp startGame, UIPopUp endGame)
        {
            _objects = new Dictionary<string, object>()
            {
                {WindowKey.GameWindow.ToString(), gameWindow},
                {WindowKey.MainMenuWindow.ToString(), mainMenuWindow},
                {PopUpKey.StartGame.ToString(), startGame},
                {PopUpKey.EndGame.ToString(), endGame},
            };
        }
        
        
        public void Init(Action onComplete)
        {
            onComplete.Invoke();
        }
        
        public T GetAsset<T>(object key)
        {
            if (_objects.ContainsKey(key.ToString()))
            {
                return (T)_objects[key.ToString()];
            }

            return default;
        }

    }
}