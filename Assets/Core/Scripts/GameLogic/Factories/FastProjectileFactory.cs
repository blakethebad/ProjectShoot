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