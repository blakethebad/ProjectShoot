namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IWeaponDecorator : IWeaponStrategy
    {
        void Decorate(IWeaponStrategy strategy);
        public IWeaponStrategy ReleaseDecorated();
    }
}