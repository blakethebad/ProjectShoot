using UnityEngine;

namespace ProjectShoot.Core.Services.Interfaces
{
    public interface IAssetService : IService
    {
        public T GetAsset<T>(object key);
        public GameObject Instantiate(object key, Transform transform, bool isActive = false);
    }
}