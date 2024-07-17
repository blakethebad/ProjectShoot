using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.Services;
using UnityEngine;
using Object = UnityEngine.Object;

namespace CaseWixot.Core.Scripts
{
    public class ProjectileFactory : IProjectileFactory
    {
        private IPoolService _objectPool;

        public ProjectileFactory(IPoolService poolService)
        {
            _objectPool = poolService;
        }
        
        public IProjectile Pull()
        {
            GameObject gameObject = _objectPool.GetObject("pref_projectile");
            IProjectile newProjectile = gameObject.GetComponent<IProjectile>();
            
            newProjectile.Init(0.5f, (projectile =>
            {
                _objectPool.ReleaseObject(gameObject, "pref_projectile");
            }));
            return newProjectile; //Convert to pool on implementation
        }

        public void Push(IProjectile projectile)
        {
        }
    }
}