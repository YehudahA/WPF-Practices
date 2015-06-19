﻿﻿using System;
using System.Windows;
using WpfPracticesLib.Mvvm;

namespace WpfPracticesLib.Interactivity
{
    public class DialogHostService : IDialogHostService
    {
        #region IDialogHostService

        public bool? RaiseDialog<T>(T viewModel) where T : IDialogViewModel
        {
            return Invoke(viewModel);
        }

        #endregion // IDialogHostService

        #region private

        private bool? Invoke(IDialogViewModel viewModel)
        {
            Window wrapperWindow = GetWindow(viewModel);
            wrapperWindow.SizeToContent = SizeToContent.WidthAndHeight;

            // We invoke the callback when the interaction's window is closed.
            EventHandler handler =
                (sender, e) =>
                {
                    wrapperWindow.Content = null;
                    wrapperWindow.Close();
                };

            viewModel.RequestClose += handler;
            wrapperWindow.ShowDialog();
            viewModel.RequestClose -= handler;

            return viewModel.DialogResult;
        }

        /// <summary>
        /// Returns the window to display as part of the trigger action.
        /// </summary>
        /// <param name="viewModel">The notification to be set as a DataContext in the window.</param>
        /// <returns></returns>
        private static Window GetWindow(IDialogViewModel viewModel)
        {
            Window wrapperWindow = new Window
            {
                Title = viewModel.Title,
                ShowInTaskbar = false,
                WindowStartupLocation = WindowStartupLocation.CenterOwner,
                WindowState = WindowState.Normal,
                SizeToContent = SizeToContent.WidthAndHeight
            };

            Window mainWindow = System.Windows.Application.Current.MainWindow;

            if (mainWindow != null)
            {
                wrapperWindow.Owner = mainWindow;
                wrapperWindow.Icon = mainWindow.Icon;
            }

            FrameworkElement view = ViewLocator.GetViewByViewModel(viewModel);
            wrapperWindow.Content = view;

            return wrapperWindow;
        }

        #endregion // private
    }
}
