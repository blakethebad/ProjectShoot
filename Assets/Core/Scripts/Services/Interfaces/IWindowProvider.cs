using CaseWixot.Core.Scripts.UI;

namespace CaseWixot.Core.Scripts
{
    public interface IWindowProvider
    {
        void OpenWindow(WindowKey key, WindowContext context = null);
        void CloseWindow(WindowKey key);
    }
}