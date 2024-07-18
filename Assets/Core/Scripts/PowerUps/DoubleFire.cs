using CaseWixot.Core.Scripts.Interfaces;
using DG.Tweening;
using UnityEngine;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class DoubleFire : IWeaponStrategy, IDecorator
    {
        private IWeaponStrategy _decorated;
        private bool _isReleased;
        public void Execute(IProjectileFactory factory, Vector3 initPos, Vector3 velocity)
        {
            _decorated.Execute(factory, initPos, velocity);
            DOVirtual.DelayedCall(0.15f, (() =>
            {
                _decorated.Execute(factory, initPos, velocity);
            }));
        }

        public bool HandleNew(IWeaponStrategy weaponStrategy)
        {
            if (_isReleased)
                return false;
            
            _decorated = weaponStrategy;
            return true;
        }

        public void Decorate(IWeaponStrategy strategy) => _decorated = strategy;

        public IWeaponStrategy ReleaseDecorated()
        {
            _isReleased = true;
            return _decorated;
        }
    }
}