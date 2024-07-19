using ProjectShoot.Core.Enums;
using ProjectShoot.Core.UI.Windows;

namespace ProjectShoot.Core.Services.Interfaces
{
    public interface IWindowProvider
    {
        void OpenWindow(WindowKey key, WindowContext context = null);
        void CloseWindow(WindowKey key);
    }
}