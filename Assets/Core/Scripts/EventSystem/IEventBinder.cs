using System;

namespace CaseWixot.Core.Scripts.EventSystem
{
    public interface IEventBinder<T> where T : IEvent
    {
        void Bind(Action<T> method);
        void Unbind(Action<T> method);
        void Raise(T t);
    }
}