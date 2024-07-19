namespace CaseWixot.Core.Scripts.PowerUps
{
    public interface IModifiableStat<T>
    {
        T Get();
        void Modify(T modification);
        void Clear();
    }
}