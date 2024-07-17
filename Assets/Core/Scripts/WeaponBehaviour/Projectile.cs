using System;
using CaseWixot.Core.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        private float _speed;
        private Action<IProjectile> _onJourneyComplete;
        
        public void Init(float speed, Action<IProjectile> onJourneyComplete)
        {
            _speed = speed;
            _onJourneyComplete = onJourneyComplete;
        }

        public void Launch(Vector3 initPos, Vector3 direction)
        {
            gameObject.SetActive(true);
            transform.position = initPos;
            
            
            transform.DOMove(transform.position + direction * 3, _speed).OnComplete((() =>
            {
                _onJourneyComplete.Invoke(this);
            }));
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.TryGetComponent(out IHittable hittable))
            {
                hittable.TakeHit();
            }
        }
    }
}