using System;

namespace ProjectShoot.Core.Services.Interfaces
{
    public interface IService
    {
        void Init(Action onComplete);
    }
}