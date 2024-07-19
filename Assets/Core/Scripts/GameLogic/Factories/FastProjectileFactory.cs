using ProjectShoot.Core.Enums;
using ProjectShoot.Core.GameLogic.Interfaces;
using ProjectShoot.Core.Services.Interfaces;
using UnityEngine;

namespace ProjectShoot.Core.GameLogic.Factories
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
            IProjectile newProjectile = _objectPool.GetAssetWithComponent<IProjectile>(GameAssets.FastProjectile);

            newProjectile.Init(0.45f, Push);
            return newProjectile;
        }

        public void Push(GameObject projectile)
        {
            _objectPool.ReleaseObject(projectile, GameAssets.FastProjectile);
        }

    }
}