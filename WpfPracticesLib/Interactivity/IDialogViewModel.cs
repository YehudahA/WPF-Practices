using System;

namespace WpfPracticesLib.Interactivity
{
    public interface IDialogViewModel
    {
        string Title { get; }
        bool? DialogResult { get; }
        event EventHandler RequestClose;
    }
}
