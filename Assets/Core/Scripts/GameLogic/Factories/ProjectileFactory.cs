using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.Services;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class ProjectileFactory : IProjectileFactory
    {
        private readonly IPoolService _objectPool;

        public ProjectileFactory(IPoolService poolService)
        {
            _objectPool = poolService;
        }
        
        public IProjectile Pull()
        {
            IProjectile newProjectile = _objectPool.GetAssetWithComponent<IProjectile>(GameAssets.Projectile);

            newProjectile.Init(0.5f, Push);
            return newProjectile;
        }

        public void Push(GameObject projectile)
        {
            _objectPool.ReleaseObject(projectile, GameAssets.Projectile);

        }
    }
}