using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class BasicFire : IWeaponStrategy
    {
        void IWeaponStrategy.Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
        {
            IProjectile projectile = factory.Pull();
            projectile.Launch(initPos, velocity);
        }

        bool IWeaponStrategy.HandleNew(IWeaponStrategy weaponStrategy)
        {
            if (weaponStrategy is IWeaponDecorator decorator)
            {
                decorator.Decorate(this);
            }
            
            return false;
        }
    }
}