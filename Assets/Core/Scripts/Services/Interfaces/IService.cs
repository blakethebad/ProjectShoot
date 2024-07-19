using System;

namespace CaseWixot.Core.Scripts.Services
{
    public interface IService
    {
        void Init(Action onComplete);
    }
}