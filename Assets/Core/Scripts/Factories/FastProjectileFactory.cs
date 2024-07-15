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
            IProjectile projectile = new Projectile(Object.Instantiate(_bulletPrefab), 0.25f, Push);
            return projectile;
        }

        public void Push(IProjectile projectile)
        {
            
        }
    }
}