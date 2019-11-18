using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using WPFUI.EventModels;
using WPFUI.Helpers;

namespace WPFUI.ViewModels
{
    public class ShellViewModel : Conductor<Screen>, IHandle<LoadEvent>, IHandle<LoadGameEvent>
    {
        /// <summary>
        /// Holds the value of the event aggregator
        /// </summary>
        private readonly IEventAggregator _events;

        /// <summary>
        /// Holds the value of the window manager
        /// </summary>
        private static IWindowManager _window;

        /// <summary>
        /// Holds the instance of the PopupViewModel
        /// </summary>
        private static PopupViewModel _popup;

        /// <summary>
        /// Holds the instance of the StatsPopupViewModel
        /// </summary>
        private static StatsPopupViewModel _statsPopup;

        /// <summary>
        /// Used to return the window manager
        /// </summary>
        /// <returns>The IWindowManager</returns>
        public static IWindowManager GetWindowManager()
        {
            return _window;
        }

        /// <summary>
        /// Used to return the PopupViewModel
        /// </summary>
        /// <returns>The PopupViewModel</returns>
        public static PopupViewModel GetPopup()
        {
            return _popup;
        }

        /// <summary>
        /// Used to return the StatsPopupViewModel
        /// </summary>
        /// <returns></returns>
        public static StatsPopupViewModel GetStatsPopup()
        {
            return _statsPopup;
        }

        /// <summary>
        /// The main block of the ShellViewModel
        /// </summary>
        /// <param name="events">The event handler for the application</param>
        /// <param name="window">The window manager</param>
        /// <param name="popup">The popup viewmodel</param>
        /// <param name="statsPopup">The stats popup viewmodel</param>
        public ShellViewModel(IEventAggregator events,IWindowManager window, PopupViewModel popup, StatsPopupViewModel statsPopup)
        {
            _window = window;
            _popup = popup;
            _statsPopup = statsPopup;

            _events = events;
            _events.Subscribe(this);

            _events.PublishOnUIThread(new LoadEvent());

            //Start the music continuously 
            Sounds.StartBackgroundMusic();
        }

        /// <summary>
        /// The handler that creates a new loaded view
        /// </summary>
        /// <param name="message">Not used</param>
        public void Handle(LoadEvent message)
        {
            ActivateItem(new LoadViewModel(_events));
        }

        /// <summary>
        /// The handler that creates a new game view
        /// </summary>
        /// <param name="message">Not used</param>
        public void Handle(LoadGameEvent message)
        {
            ActivateItem(new GameViewModel(_events));
        }

        /// <summary>
        /// When the application is exited, dispose of background music object
        /// </summary>
        public void OnClose()
        {
            Sounds.StopBackgroundMusic();
        }
    }
}