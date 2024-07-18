using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public class ConeFirePowerUp : PowerUp<IWeapon>
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
}