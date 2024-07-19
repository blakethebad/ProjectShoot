using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace CaseWixot.Core.Scripts.Services
{
    public sealed class PoolService : IPoolService
    {
        private readonly StringBuilder _popBuilder;
        private readonly StringBuilder _releaseBuilder;
        private readonly IAssetService _assetService;
        private readonly Transform _poolTransform;

        private Dictionary<string, Stack<GameObject>> _poolElements;

        public PoolService(IAssetService assetService, Transform poolTransform)
        {
            _poolTransform = poolTransform;
            _assetService = assetService;
            _popBuilder = new StringBuilder();
            _releaseBuilder = new StringBuilder();
        }

        void IService.Init(Action onComplete)
        {
            _poolElements = new Dictionary<string, Stack<GameObject>>(10);
            PrewarmPool();
            onComplete.Invoke();
        }

        private void PrewarmPool()
        {
            _poolElements.Add(GameAssets.Projectile.ToString(), new Stack<GameObject>());
            _poolElements.Add(GameAssets.FastProjectile.ToString(), new Stack<GameObject>());

            for (int i = 0; i < 3; i++)
            {
                _poolElements[GameAssets.FastProjectile.ToString()].Push(_assetService.Instantiate(GameAssets.FastProjectile, _poolTransform));
                _poolElements[GameAssets.Projectile.ToString()].Push(_assetService.Instantiate(GameAssets.Projectile, _poolTransform));
            }
        }

        void IPoolService.ReleaseObject(GameObject gameObject, object key)
        {
            gameObject.SetActive(false);
            gameObject.transform.position = Vector3.zero;

            _releaseBuilder.Clear();
            _releaseBuilder.Append(key);

            if (!_poolElements.ContainsKey(_releaseBuilder.ToString()))
            {
                throw new Exception($"Pool with key : {key} cannot be found");
            }
            
            _poolElements[_releaseBuilder.ToString()].Push(gameObject);
        }

        GameObject IPoolService.GetObject(object key)
        {
            _popBuilder.Clear();
            _popBuilder.Append(key);
            if (!_poolElements.ContainsKey(_popBuilder.ToString()))
            {
                throw new Exception($"Asset with key : {key} cannot be found");
            }

            var poolInstance = _poolElements[_popBuilder.ToString()].Count > 0 ? 
                _poolElements[_popBuilder.ToString()].Pop() : 
                _assetService.Instantiate(_popBuilder.ToString(), _poolTransform);

            return poolInstance;
        }

        T IPoolService.GetAssetWithComponent<T>(object key)
        {
            _popBuilder.Clear();
            _popBuilder.Append(key);
            if (!_poolElements.ContainsKey(_popBuilder.ToString()))
            {
                throw new Exception($"Asset with key {key} cannot be found");
            }

            var poolInstance = _poolElements[_popBuilder.ToString()].Count > 0 ? 
                _poolElements[_popBuilder.ToString()].Pop().GetComponent<T>() : 
                _assetService.Instantiate(_popBuilder.ToString(), _poolTransform).GetComponent<T>();

            return poolInstance;
        }

    }
}