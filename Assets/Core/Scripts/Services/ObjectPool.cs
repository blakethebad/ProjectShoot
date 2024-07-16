using System;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.UI;
using CaseWixot.Core.Scripts.UI.PopUps;
using UnityEngine;
using UnityEngine.Pool;

namespace CaseWixot.Core.Scripts.Services
{
    public class ObjectPool 
    {
        private Dictionary<Type, Queue<IPoolObject>> _dictionary;

        private IObjectPool<IProjectile> _projectilePool;

        private IObjectPool<ISpawnable> _spawnablePool;

        private IObjectPool<UIWindow> _windowPool;
        private IObjectPool<UIPopUp> _popUpPool;

        private Dictionary<string, Queue<GameObject>> _pool;
        
        public void Init()
        {
        }

        public void PushAsset<T>(IPoolObject poolObject)
        {
        }

        public T PullAsset<T>()
        {
            return (T)_dictionary[typeof(T)].Dequeue();
        }


    }

    public interface IPoolObject
    {
        
    }


    public interface IObjectPool<T>
    {
        T Get();
        void Release(T obj);
    }
    
    
    

    public interface IService
    {
        void Init();
    }
}