using System.Collections;
using CaseWixot.Core.Scripts.Interfaces;
using CaseWixot.Core.Scripts.PowerUps;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Weapon : IWeapon
    {
        private readonly IModifiableStat<float> _fireInterval;
        private IProjectileFactory _projectileFactory;
        private IWeaponStrategy _weaponStrategy;


        public Weapon(IModifiableStat<float> interval, IWeaponStrategy initialStrategy, IProjectileFactory initialFactory)
        {
            _fireInterval = interval;
            _weaponStrategy = initialStrategy;
            _projectileFactory = initialFactory;
        }
        
        void IWeapon.ChangeBulletFactory(IProjectileFactory projectileFactory) => _projectileFactory = projectileFactory;

        void IWeapon.AddStrategy(IWeaponStrategy strategy)
        {
            if(_weaponStrategy.HandleNew(strategy))
                return;

            _weaponStrategy = strategy;
        }
        
        public IEnumerator StartShoot(IMoveComponent moveComponent)
        {
            yield return new WaitForSeconds(_fireInterval.Get());
            
            _weaponStrategy.Execute(_projectileFactory, moveComponent.GetPosition(), moveComponent.GetDirection());

            yield return StartShoot(moveComponent);
        }
    }


}