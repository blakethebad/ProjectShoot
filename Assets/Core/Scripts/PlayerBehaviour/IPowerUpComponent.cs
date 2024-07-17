namespace CaseWixot.Core.Scripts
{
    public interface IPowerUpComponent
    {
        void Init();
        void OnPowerUpToggled(int index);
    }
}