using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;

namespace WpfPracticesLib.Windows.Controls
{
    public sealed class DataGridHyperlinkCommandColumn : DataGridHyperlinkColumn
    {
        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            TextBlock outerBlock = new TextBlock();
            Hyperlink link = new Hyperlink();

            UIHelper.ApplyBinding(link, Hyperlink.CommandProperty, Command);
            UIHelper.ApplyBinding(link, Hyperlink.CommandParameterProperty, CommandParameter);

            InlineUIContainer inlineContainer = new InlineUIContainer();
            ContentPresenter innerContentPresenter = new ContentPresenter();

            outerBlock.Inlines.Add(link);
            link.Inlines.Add(inlineContainer);
            inlineContainer.Child = innerContentPresenter;

            UIHelper.ApplyBinding(innerContentPresenter, ContentPresenter.ContentProperty, Binding);
            UIHelper.ApplyBinding(link, Hyperlink.NavigateUriProperty, null);

            return outerBlock;
        }

        #region properties

        public BindingBase Command
        {
            get;
            set;
        }

        public BindingBase CommandParameter
        {
            get;
            set;
        }

        #endregion // properties
    }
}