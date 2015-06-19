using System.Windows;
using WpfPracticesLib.Interactivity;

namespace WpfPractices.TesterApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            MessageBoxService.Current = new MessageBoxService();
            Models.IDataService dataService = new Models.DataService();
            WpfPracticesLib.Interactivity.IDialogHostService dialogHostService = new WpfPracticesLib.Interactivity.DialogHostService();
            ViewModels.ProductListViewModel productsListViewModel = new ViewModels.ProductListViewModel(dataService, dialogHostService);
            Views.ProductListView productsListView = new Views.ProductListView { DataContext = productsListViewModel };

            this.MainWindow = new MainWindow { Content = productsListView };
            this.MainWindow.Show();
        }
    }
}
