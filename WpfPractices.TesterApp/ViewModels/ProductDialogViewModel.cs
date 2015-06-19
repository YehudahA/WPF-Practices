using Microsoft.Practices.Prism.Commands;
using WpfPracticesLib.Interactivity;

namespace WpfPractices.TesterApp.ViewModels
{
    public class ProductDialogViewModel : DialogViewModelBase
    {
        public ProductDialogViewModel(Models.Product product)
        {
            base.SetTitle(product.Name);
            this.product = product;
            this.closeCommand = new DelegateCommand(this.Close);
        }

        private readonly Models.Product product;
        private readonly DelegateCommand closeCommand;

        public Models.Product Product
        {
            get { return product; }
        } 

        public DelegateCommand CloseCommand
        {
            get { return closeCommand; }
        }

        private void Close()
        {
            base.OnRequestClose();
        }
    }
}
