using UnityEngine;

namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IProjectileFactory
    {
        IProjectile Pull();
        void Push(GameObject projectile);
    }
}