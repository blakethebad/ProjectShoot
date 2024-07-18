﻿using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class BasicFire : IWeaponStrategy
    {
        public void Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
        {
            IProjectile projectile = factory.Pull();
            projectile.Launch(initPos, velocity);
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