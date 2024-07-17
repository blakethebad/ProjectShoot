namespace CaseWixot.Core.Scripts.UI.PopUps
{
    public interface IStartGamePopUp : IPopUp
    {
        void RegisterListener(IStartGameListener listener);
    }
}