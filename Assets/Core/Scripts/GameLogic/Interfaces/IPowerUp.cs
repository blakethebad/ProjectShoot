namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IPowerUp
    {
        bool IsActive { get; }
        void Enable();
        void Disable();
    }
}