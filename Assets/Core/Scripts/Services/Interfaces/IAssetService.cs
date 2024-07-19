using UnityEngine;

namespace CaseWixot.Core.Scripts.Services
{
    public interface IAssetService : IService
    {
        public T GetAsset<T>(object key);
        public GameObject Instantiate(object key, Transform transform, bool isActive = false);
    }
}