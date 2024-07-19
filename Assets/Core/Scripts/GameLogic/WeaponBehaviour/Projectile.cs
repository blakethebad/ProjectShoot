using System;
using DG.Tweening;
using ProjectShoot.Core.GameLogic.Interfaces;
using UnityEngine;

namespace ProjectShoot.Core.GameLogic.WeaponBehaviour
{
    public class Projectile : MonoBehaviour, IProjectile
    {
        private float _speed;
        private Action<GameObject> _onJourneyComplete;

        void IProjectile.Init(float speed, Action<GameObject> onJourneyComplete)
        {
            _speed = speed;
            _onJourneyComplete = onJourneyComplete;
        }

        void IProjectile.Launch(Vector3 initPos, Vector3 direction)
        {
            gameObject.SetActive(true);
            transform.position = initPos;


            transform.DOMove(transform.position + direction * 3, _speed).OnComplete(OnJourneyComplete);
        }

        private void OnJourneyComplete()
        {
            _onJourneyComplete.Invoke(gameObject);
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