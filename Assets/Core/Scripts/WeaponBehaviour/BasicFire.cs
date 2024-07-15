using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public struct BasicFire : IWeaponStrategy
    {
        public void Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
        {
            IProjectile projectile = factory.Pull();
            projectile.Launch(initPos,velocity);
        }
    }
}