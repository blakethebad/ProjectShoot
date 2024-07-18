namespace CaseWixot.Core.Scripts.Interfaces
{
    public interface IPowerUp
    {
        void Toggle();
        bool IsActive { get; }
        void Enable();
        void Disable();
    }
}