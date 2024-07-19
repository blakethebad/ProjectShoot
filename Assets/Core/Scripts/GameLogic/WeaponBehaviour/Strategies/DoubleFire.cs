using CaseWixot.Core.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class DoubleFire : IWeaponDecorator
    {
        private IWeaponStrategy _decorated;
        private bool _isReleased;

        void IWeaponStrategy.Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
        {
            _decorated.Execute(factory, initPos, velocity);
            DOVirtual.DelayedCall(0.15f, (() =>
            {
                _decorated.Execute(factory, initPos, velocity);
            }));
        }

        bool IWeaponStrategy.HandleNew(IWeaponStrategy weaponStrategy)
        {
            if (_isReleased)
                return false;
            
            _decorated = weaponStrategy;
            return true;
        }

        void IWeaponDecorator.Decorate(IWeaponStrategy strategy) => _decorated = strategy;

        IWeaponStrategy IWeaponDecorator.ReleaseDecorated()
        {
            _isReleased = true;
            return _decorated;
        }
    }
}