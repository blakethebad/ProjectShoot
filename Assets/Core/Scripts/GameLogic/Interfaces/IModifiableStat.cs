namespace ProjectShoot.Core.GameLogic.Interfaces
{
    public interface IModifiableStat<T>
    {
        T Get();
        void Modify(T modification);
        void Clear();
    }
}