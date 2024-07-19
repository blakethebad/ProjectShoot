using System;

namespace CaseWixot.Core.Scripts.EventSystem
{
    public sealed class EventBinder<T> : IEventBinder<T> where T : IEvent
    {
        private Action<T> _onEvent = raised => { };
        
        public void Bind(Action<T> method)
        {
            _onEvent += method;
        }

        public void Unbind(Action<T> method)
        {
            _onEvent -= method;
        }

        public void Raise(T t)
        {
            _onEvent.Invoke(t);
        }
    }
}