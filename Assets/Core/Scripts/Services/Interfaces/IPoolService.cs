using UnityEngine;

namespace ProjectShoot.Core.Services.Interfaces
{
    public interface IPoolService : IService
    {
        public T GetAssetWithComponent<T>(object key);
        public void ReleaseObject(GameObject gameObject, object key);
        public GameObject GetObject(object key);
    }
}