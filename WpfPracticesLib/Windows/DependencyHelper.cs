using System.Windows;
using System.Windows.Data;

namespace WpfPracticesLib.Windows
{
    internal static class DependencyHelper
    {
        public static void ApplyBinding(DependencyObject target, DependencyProperty property, BindingBase binding)
        {
            if (binding != null)
            {
                BindingOperations.SetBinding(target, property, binding);
            }
            else
            {
                BindingOperations.ClearBinding(target, property);
            }
        }

        public static void SyncDependencyProperties(DependencyObject sourceObject, DependencyProperty sourceProperty, DependencyObject targetObject, DependencyProperty taretProperty)
        {
            if (DependencyPropertyHelper.GetValueSource(sourceObject, sourceProperty).BaseValueSource == BaseValueSource.Default)
            {
                targetObject.ClearValue(taretProperty);
            }
            else
            {
                targetObject.SetValue(taretProperty, sourceObject.GetValue(sourceProperty));
            }
        }
    }
}
