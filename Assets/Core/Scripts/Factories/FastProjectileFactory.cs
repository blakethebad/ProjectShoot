using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class FastProjectileFactory : IProjectileFactory
    {
        private readonly Transform _bulletPrefab;
        public FastProjectileFactory(Transform bulletPrefab)
        {
            _bulletPrefab = bulletPrefab;
        }
        public IProjectile Pull()
        {
            Transform newProjectile = Object.Instantiate(_bulletPrefab);
            IProjectile projectile = newProjectile.GetComponent<IProjectile>();
            projectile.Init(0.25f, Push);
            return projectile;
        }

        public void Push(IProjectile projectile)
        {
            
        }
    }
}