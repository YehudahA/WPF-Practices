using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfPracticesLib.Windows.Controls
{
    public sealed class DataGridButtonColumn : DataGridColumn
    {
        #region propetries

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

        public BindingBase ContentBinding
        {
            get;
            set;
        }

        #endregion // propetries

        #region Content DependencyProperty

        /// <summary>
        /// The <see cref="Content" /> dependency property's name.
        /// </summary>
        public const string ContentPropertyName = "Content";

        /// <summary>
        /// Gets or sets the value of the <see cref="Content" />
        /// property. This is a dependency property.
        /// </summary>
        public object Content
        {
            get { return (object)GetValue(ContentProperty); }
            set { SetValue(ContentProperty, value); }
        }

        /// <summary>
        /// Identifies the <see cref="Content" /> dependency property.
        /// </summary>
        public static readonly DependencyProperty ContentProperty = DependencyProperty.Register(
            ContentPropertyName,
            typeof(object),
            typeof(DataGridButtonColumn),
            new UIPropertyMetadata(null));

        #endregion // Content DependencyProperty

        protected override FrameworkElement GenerateEditingElement(DataGridCell cell, object dataItem)
        {
            return GenerateElement(cell, dataItem);
        }

        protected override FrameworkElement GenerateElement(DataGridCell cell, object dataItem)
        {
            Button button = new Button();
            DependencyHelper.SyncDependencyProperties(this, DataGridButtonColumn.ContentProperty, button, Button.ContentProperty);
            DependencyHelper.ApplyBinding(button, Button.CommandProperty, this.Command);
            DependencyHelper.ApplyBinding(button, Button.CommandParameterProperty, this.CommandParameter);
            DependencyHelper.ApplyBinding(button, Button.ContentProperty, this.ContentBinding);
            return button;
        }
    }
}