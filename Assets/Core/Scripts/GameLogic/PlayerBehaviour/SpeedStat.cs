namespace CaseWixot.Core.Scripts.PowerUps
{
    public class SpeedStat : IModifiableStat<int>
    {
        private int _currentValue;
        private int _initialValue;
        
        public SpeedStat(int initialValue)
        {
            _initialValue = initialValue;
            _currentValue = _initialValue;
        }

        int IModifiableStat<int>.Get() => _currentValue;

        void IModifiableStat<int>.Modify(int modification)
        {
            _currentValue = modification;
        }

        void IModifiableStat<int>.Clear()
        {
            _currentValue = _initialValue;
        }
    }
}