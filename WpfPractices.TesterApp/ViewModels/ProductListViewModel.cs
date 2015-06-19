using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.Mvvm;
using System.Collections.Generic;
using System.Windows.Input;
using WpfPracticesLib.Interactivity;

namespace WpfPractices.TesterApp.ViewModels
{
    public class ProductListViewModel : BindableBase
    {
        readonly Models.IDataService dataService;
        readonly ICommand selectProductCommand;
        readonly IDialogHostService dialogHostService;

        private List<Models.Product> products;

        public ProductListViewModel(Models.IDataService dataService, IDialogHostService dialogHostService)
        {
            this.dataService = dataService;
            this.dialogHostService = dialogHostService;
            this.products = dataService.GetProducts();
            this.selectProductCommand = new DelegateCommand<object>(SelectProduct);
        }


        public List<Models.Product> Products
        {
            get { return this.products; }
            set { SetProperty(ref products, value); }
        }

        public ICommand SelectProductCommand
        {
            get { return selectProductCommand; }
        }

        private void SelectProduct(object parameter)
        {
            Models.Product product = parameter as Models.Product;
            string productName = product != null ? product.Name : "No product";
            string message = string.Format("{0} Selected", productName);

            WpfPracticesLib.Interactivity.MessageBoxService.Current.Show(message, "Products List");

            ProductDialogViewModel dialog = new ProductDialogViewModel(product);
            dialogHostService.RaiseDialog(dialog);
        }
    }
}
