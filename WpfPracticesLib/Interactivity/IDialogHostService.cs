
namespace WpfPracticesLib.Interactivity
{
    public interface IDialogHostService
    {
        bool? RaiseDialog<T>(T viewModel) where T : IDialogViewModel;
    }
}
