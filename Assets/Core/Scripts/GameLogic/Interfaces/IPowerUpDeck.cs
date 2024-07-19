namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IPowerUpDeck
    { 
        void OnPowerUpToggled(int index);
        void Init();
    }
}