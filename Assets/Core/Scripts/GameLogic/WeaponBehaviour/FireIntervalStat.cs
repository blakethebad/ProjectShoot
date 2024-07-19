using CaseWixot.Core.Scripts.PowerUps;

namespace CaseWixot.Core.Scripts
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