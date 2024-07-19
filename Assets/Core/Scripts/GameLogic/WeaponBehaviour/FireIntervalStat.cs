using ProjectShoot.Core.GameLogic.Interfaces;

namespace ProjectShoot.Core.GameLogic.WeaponBehaviour
{
    public class FireIntervalStat : IModifiableStat<float>
    {
        private float _initialValue;
        private float _currentValue;
        public FireIntervalStat(float f)
        {
            _initialValue = f;
            _currentValue = _initialValue;
        }
        
        void IModifiableStat<float>.Modify(float modifiedValue) => _currentValue = modifiedValue;

        float IModifiableStat<float>.Get() => _currentValue;

        void IModifiableStat<float>.Clear()
        {
            _currentValue = _initialValue;
        }
    }
}