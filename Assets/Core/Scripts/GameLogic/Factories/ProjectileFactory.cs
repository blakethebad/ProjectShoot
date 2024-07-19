using ProjectShoot.Core.Enums;
using ProjectShoot.Core.GameLogic.Interfaces;
using ProjectShoot.Core.Services.Interfaces;
using UnityEngine;

namespace ProjectShoot.Core.GameLogic.Factories
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

            newProjectile.Init(0.8f, Push);
            return newProjectile;
        }

        public void Push(GameObject projectile)
        {
            _objectPool.ReleaseObject(projectile, GameAssets.Projectile);

        }
    }
}