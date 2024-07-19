using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts.PowerUps
{
    public interface IWeaponDecorator : IWeaponStrategy
    {
        void Decorate(IWeaponStrategy strategy);
        public IWeaponStrategy ReleaseDecorated();
    }
}