using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly Transform _bulletPrefab;
        private Dictionary<IProjectile, Transform> _activeProjectiles = new Dictionary<IProjectile, Transform>();

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