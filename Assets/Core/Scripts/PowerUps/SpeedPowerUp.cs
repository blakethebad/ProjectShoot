using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class SpeedPowerUp : PowerUp<IModifiableStat<int>>
    {
        public SpeedPowerUp(IModifiableStat<int> modifiableEntity, int index) : base(modifiableEntity, index)
        {
        }

        public override void Enable()
        {
            base.Enable();
            ModifiedEntity.Modify(3);
        }

        public override void Disable()
        {
            base.Disable();
            ModifiedEntity.Clear();
        }
    }

    public interface IModifiableStat<T>
    {
        T Get();
        void Modify(T modification);
        void Clear();
    }

    public class SpeedStat : IModifiableStat<int>
    {
        private int _currentValue;
        private int _initialValue;
        
        public SpeedStat(int initialValue)
        {
            _initialValue = initialValue;
            _currentValue = _initialValue;
        }

        public int Get() => _currentValue;
        
        public void Modify(int modification)
        {
            _currentValue = modification;
        }
        
        public void Clear()
        {
            _currentValue = _initialValue;
        }
    }
}