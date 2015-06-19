using System.Windows;

namespace WpfPracticesLib.Interactivity
{
    public interface IMessageBoxService
    {
        MessageBoxResult Show(string messageBoxText, string caption);
    }
}
