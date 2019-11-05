using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WPFUI.ViewModels;

namespace WPFUI.Helpers
{
    /// <summary>
    /// Various methods and properties that allow popups to be display when using the application
    /// </summary>
    public class PopupHelper : Screen
    {
        /// <summary>
        /// Holds the passed in window manager object
        /// </summary>
        private static IWindowManager _window;

        /// <summary>
        /// Holds the passed in PopupViewModel object
        /// </summary>
        private static PopupViewModel _popup;

        /// <summary>
        /// Used to setup the settings for the showdialog popup
        /// </summary>
        /// <returns>The settings for the popup</returns>
        private static dynamic GetSettings()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            settings.ResizeMode = ResizeMode.NoResize;
            settings.WindowStyle = WindowStyle.None;
            return settings;
        }

        /// <summary>
        /// Displays a popup using the header and message input
        /// </summary>
        /// <param name="header">The header of the popup</param>
        /// <param name="message">The message of the popup</param>
        public static void ShowPopup(string header, string message)
        {
            _window = ShellViewModel.GetWindowManager();
            _popup = ShellViewModel.GetPopup();

            _popup.UpdatePopup(header, message);
            _window.ShowDialog(_popup, null, GetSettings());
        }
    }
}