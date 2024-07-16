using System.Collections;
using System.Collections.Generic;
using CaseWixot.Core.Scripts.Interfaces;
using UnityEngine;

namespace CaseWixot.Core.Scripts
{
    public class Weapon : IWeapon
    {
        private IProjectileFactory _projectileFactory;
        private IWeaponStrategy _currentStrategy;
        private float _shootInterval = 2f;
        private bool _isDoubleShot = false;

        void IWeapon.SetBulletProvider(IProjectileFactory projectileFactory) => _projectileFactory = projectileFactory;
        void IWeapon.SetStrategy(IWeaponStrategy strategy) => _currentStrategy = strategy;
        void IWeapon.SetBulletInterval(float interval) => _shootInterval = interval;
        void IWeapon.SetDoubleShot(bool isDoubleShot) => _isDoubleShot = isDoubleShot;

        public IEnumerator Shoot(IMoveHandler moveHandler)
        {
            yield return new WaitForSeconds(_shootInterval); //Will be modified

            _currentStrategy.Execute(_projectileFactory, moveHandler.GetPosition(), moveHandler.GetDirection());

            if (_isDoubleShot)
            {
                yield return new WaitForSeconds(0.1f);
                _currentStrategy.Execute(_projectileFactory, moveHandler.GetPosition(), moveHandler.GetDirection());
            }

            yield return Shoot(moveHandler);
        }
    }
}