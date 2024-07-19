using ProjectShoot.Core.GameLogic.Interfaces;
using UnityEngine;

namespace ProjectShoot.Core.GameLogic.WeaponBehaviour.Strategies
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