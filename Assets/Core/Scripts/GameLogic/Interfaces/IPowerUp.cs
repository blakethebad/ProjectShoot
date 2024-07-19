namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IPowerUp
    {
        bool IsActive { get; }
        void Enable();
        void Disable();
    }
}