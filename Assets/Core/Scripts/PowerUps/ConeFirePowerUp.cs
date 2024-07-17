using CaseWixot.Core.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class ConeFirePowerUp : Booster<IWeapon>
    {
        private IWeaponStrategy _enabledStrategy;
        private IWeaponStrategy _disabledStrategy;
        public ConeFirePowerUp(IWeapon modifiableEntity, int index) : base(modifiableEntity, index)
        {
            _enabledStrategy = new ConeFire();
            _disabledStrategy = new BasicFire();
        }

        public override void Enable()
        {
            base.Enable(); 
            ModifiedEntity.AddStrategy(_enabledStrategy);
        }

        public override void Disable()
        {
            base.Disable();
            ModifiedEntity.AddStrategy(_disabledStrategy);
        }
    }

    public interface IDecorator
    {
        void Decorate(IWeaponStrategy strategy);
        public IWeaponStrategy ReleaseDecorated();
    }
    
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

    public class DoubleFire : IWeaponStrategy, IDecorator
    {
        private IWeaponStrategy _decorated;
        public void Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
        {
            _decorated.Execute(factory, initPos, velocity);
            DOVirtual.DelayedCall(0.2f, (() =>
            {
                _decorated.Execute(factory, initPos, velocity);
            }));
        }

        public bool HandleNew(IWeaponStrategy weaponStrategy)
        {
            if (weaponStrategy is IDecorator) 
                return false;
            
            _decorated = weaponStrategy;
            return true;
        }

        public void Decorate(IWeaponStrategy strategy) => _decorated = strategy;

        public IWeaponStrategy ReleaseDecorated() => _decorated;
    }
}