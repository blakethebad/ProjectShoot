using ProjectShoot.Core.GameLogic.Interfaces;
using UnityEngine;

namespace ProjectShoot.Core.GameLogic.WeaponBehaviour.Strategies
{
    public class ConeFire : IWeaponStrategy
    {
        void IWeaponStrategy.Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
        {
            IProjectile leftProjectile = factory.Pull();
            IProjectile rightProjectile = factory.Pull();
            IProjectile projectile = factory.Pull();
            Vector3 leftDirection = Quaternion.Euler(0, 0, 45) * velocity;
            Vector3 rightDirection = Quaternion.Euler(0, 0, -45) * velocity;

            projectile.Launch(initPos,velocity);
            leftProjectile.Launch(initPos, leftDirection);
            rightProjectile.Launch(initPos, rightDirection);

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