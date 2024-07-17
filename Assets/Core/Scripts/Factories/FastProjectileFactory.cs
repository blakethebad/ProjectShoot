using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.Services;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class FastProjectileFactory : IProjectileFactory
    {
        private IPoolService _objectPool;

        public FastProjectileFactory(IPoolService poolService)
        {
            _objectPool = poolService;
        }
        public IProjectile Pull()
        {
            GameObject gameObject = _objectPool.GetObject("pref_fastProjectile");
            IProjectile newProjectile = gameObject.GetComponent<IProjectile>();
            
            newProjectile.Init(0.25f, (projectile =>
            {
                _objectPool.ReleaseObject(gameObject, "pref_fastProjectile");
            }));
            return newProjectile;
        }

        public void Push(IProjectile projectile)
        {
        }
    }
}