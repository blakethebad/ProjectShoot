using UnityEngine;

namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IProjectileFactory
    {
        IProjectile Pull();
        void Push(GameObject projectile);
    }
}