using System;
using CaseWixot.Core.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class Projectile : IProjectile
    {
        private float _speed;
        private readonly Transform _bulletObj;
        private readonly Action<IProjectile> _onJourneyComplete;
        
        public Projectile(Transform bulletObj, float speed, Action<IProjectile> onJourneyComplete)
        {
            _speed = speed;
            _bulletObj = bulletObj;
            _onJourneyComplete = onJourneyComplete;
        }
        
        
        public void Launch(Vector3 initPos, Vector3 direction)
        {
            _bulletObj.gameObject.SetActive(true);
            _bulletObj.position = initPos;
            
            
            _bulletObj.DOMove(_bulletObj.position + direction * 3, _speed).OnComplete((() =>
            {
                Object.Destroy(_bulletObj.gameObject);
            }));
        }
    }
}