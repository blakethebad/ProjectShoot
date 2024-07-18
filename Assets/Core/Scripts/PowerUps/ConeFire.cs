﻿using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class ConeFire : IWeaponStrategy
    {
        public void Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
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

        public bool HandleNew(IWeaponStrategy weaponStrategy)
        {
            if (weaponStrategy is IDecorator decorator)
            {
                decorator.Decorate(this);
            }
            return false;
        }
    }
}