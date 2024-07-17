using System;
using System.Collections.Generic;
using System.Text;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.U2D;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts.Services
{
    public interface IPoolService : IService
    {
        public T GetAssetWithComponent<T>(object key);
        public void ReleaseObject(GameObject gameObject, object key);
        public GameObject GetObject(object key);
    }
    
    public class PoolService : IPoolService
    {
        private StringBuilder _popBuilder;
        private StringBuilder _releaseBuilder;

        private Dictionary<string, Stack<GameObject>> _poolElements;
        private Dictionary<string, GameObject> _objects; // IAssetService will provide these so; TEMP
        private Transform _poolTransform;

        private bool _isInitialized = false;

        public PoolService(Transform poolTransform, Dictionary<string, GameObject> poolElements)
        {
            _poolTransform = poolTransform;
            _objects = poolElements;
            _popBuilder = new StringBuilder();
            _releaseBuilder = new StringBuilder();
        }
                
        public void Init(Action onComplete)
        {
            if (_isInitialized)
            {
                onComplete.Invoke();
                return;
            }

            _poolElements = new Dictionary<string, Stack<GameObject>>(10);
            PrewarmPool();
            onComplete.Invoke();
        }

        private void PrewarmPool()
        {
            foreach (var poolElement in _objects)
            {
                if (!_poolElements.ContainsKey(poolElement.Key))
                {
                    _poolElements.Add(poolElement.Key, new Stack<GameObject>());
                }

                for (int i = 0; i < 2; i++)
                {
                    GameObject obj = Object.Instantiate(poolElement.Value, _poolTransform, true);
                    obj.SetActive(false);
                    _poolElements[poolElement.Key].Push(obj);
                }
            }
        }

        public void ReleaseObject(GameObject gameObject, object key)
        {
            gameObject.SetActive(false);
            
            _releaseBuilder.Clear();
            _releaseBuilder.Append(key);

            if (!_poolElements.ContainsKey(_releaseBuilder.ToString()))
            {
                throw new Exception($"Pool with key : {key} cannot be found");
            }

            Debug.LogError("Released");
            _poolElements[_releaseBuilder.ToString()].Push(gameObject);

        }

        public GameObject GetObject(object key)
        {
            _popBuilder.Clear();
            _popBuilder.Append(key);
            if (!_poolElements.ContainsKey(_popBuilder.ToString()))
            {
                throw new Exception($"Asset with key : {key} cannot be found");
            }

            GameObject obj;

            if (_poolElements[_popBuilder.ToString()].Count > 0)
            {
                obj = _poolElements[_popBuilder.ToString()].Pop();
            }
            else
            {
                obj = Object.Instantiate(_objects[_popBuilder.ToString()], _poolTransform, true);
            }

            return obj;
        }

        public T GetAssetWithComponent<T>(object key)
        {
            _popBuilder.Clear();
            _popBuilder.Append(key);
            if (!_poolElements.ContainsKey(_popBuilder.ToString()))
            {
                throw new Exception($"Asset with key : {key} cannot be found");
            }

            return _poolElements[_popBuilder.ToString()].Pop().GetComponent<T>();
        }

    }

    public interface IService
    {
        void Init(Action onComplete);
    }
}