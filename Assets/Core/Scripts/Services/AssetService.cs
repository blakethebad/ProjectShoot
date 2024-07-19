using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ProjectShoot.Core.Services.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.AddressableAssets.ResourceLocators;
using Object = UnityEngine.Object;

namespace ProjectShoot.Core.Services
{
    public sealed class AssetService : IAssetService
    {
        private readonly Dictionary<string, object> _assets = new Dictionary<string, object>();
        private readonly StringBuilder _builder = new StringBuilder();

        private const string WindowKey = "Window";
        private const string PopUpKey = "PopUp";
        private const string GameAssetKey = "GameAsset";

        async void IService.Init(Action onComplete)
        {
            var resourceLocator = await InitAddressable();
            if(resourceLocator == null)
                return;

            try
            {
                await Addressables.LoadAssetsAsync<GameObject>(WindowKey, window =>
                {
                    _assets.Add(window.name, window);
                }).Task;

                await Addressables.LoadAssetsAsync<GameObject>(PopUpKey, popUp =>
                {
                    _assets.Add(popUp.name, popUp);
                }).Task;
                
                await Addressables.LoadAssetsAsync<GameObject>(GameAssetKey, gameAsset =>
                {
                    _assets.Add(gameAsset.name, gameAsset);
                }).Task;

            }
            catch (Exception exception)
            {
                Debug.LogError(exception.Message);
                throw;
            }
            onComplete.Invoke();
        }

        private async Task<IResourceLocator> InitAddressable()
        {
            try
            {
                var resourceLocator = await Addressables.InitializeAsync().Task;
                return resourceLocator;
            }
            catch (Exception e)
            {
                Debug.LogError($"Asset Management Error {e.Message}");
                throw;
            }
        }

        T IAssetService.GetAsset<T>(object key)
        {
            _builder.Clear();
            _builder.Append(key);
            if (!_assets.ContainsKey(_builder.ToString()))
            {
                throw new Exception($"Key {key} cannot be found");
            }

            return (T)_assets[_builder.ToString()];
        }

        GameObject IAssetService.Instantiate(object key, Transform transform, bool isActive)
        {
            _builder.Clear();
            _builder.Append(key);
            if (!_assets.ContainsKey(_builder.ToString()))
            {
                throw new Exception($"Key {key} cannot be found");
            }
            
            GameObject prefab = (GameObject)_assets[key.ToString()];
            GameObject instance = Object.Instantiate(prefab, transform, true);
            instance.SetActive(isActive);
            instance.transform.position = Vector3.zero;
            return instance;

        }

    }
}