using System.Windows;

namespace WpfPracticesLib.Interactivity
{
    public sealed class MessageBoxService : IMessageBoxService
    {
        public MessageBoxResult Show(string messageBoxText, string caption)
        {
            MessageBoxResult result = MessageBox.Show(messageBoxText, caption);
            return result;
        }

        public static IMessageBoxService Current
        {
            get;
            set;
        }
    }
}
