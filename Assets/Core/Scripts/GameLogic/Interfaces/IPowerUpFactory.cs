using CaseWixot.Core.Scripts.Interfaces;

namespace CaseWixot.Core.Scripts
{
    public interface IPowerUpFactory
    {
        public IPowerUp[] GenerateAll();
    }
}