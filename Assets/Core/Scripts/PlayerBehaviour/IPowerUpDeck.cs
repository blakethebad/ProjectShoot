namespace CaseWixot.Core.Scripts
{
    public interface IPowerUpDeck
    { 
        void OnPowerUpToggled(int index);
        void Init();
    }
}