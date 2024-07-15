namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IProjectileFactory
    {
        IProjectile Pull();
        void Push(IProjectile projectile);
    }
}