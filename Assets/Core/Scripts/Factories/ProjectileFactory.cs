using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly Transform _bulletPrefab;

        public ProjectileFactory(Transform bulletPrefab)
        {
            _bulletPrefab = bulletPrefab;
        }
        
        public IProjectile Pull()
        {
            IProjectile projectile = new Projectile(Object.Instantiate(_bulletPrefab), 0.5f, Push);
            return projectile; //Convert to pool on implementation
        }

        public void Push(IProjectile projectile)
        {
            Debug.LogError($"projectile is pushed");
        }
    }
}