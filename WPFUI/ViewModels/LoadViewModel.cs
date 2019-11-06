using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.EventModels;
using WPFUI.SaveGameOperations;

namespace WPFUI.ViewModels
{
    /// <summary>
    /// Includes logic for the loading screen
    /// </summary>
    public class LoadViewModel : Screen
    {
        /// <summary>
        /// Private variable to hold the events
        /// </summary>
        private IEventAggregator _events;

        /// <summary>
        /// Event when the LoadViewModel is loaded
        /// </summary>
        /// <param name="events">The events</param>
        public LoadViewModel(IEventAggregator events)
        {
            //Updates the events private variables
            _events = events;
        }

        /// <summary>
        /// The event for when the NewGame button is pressed
        /// </summary>
        public void NewGame()
        {
            //Clear the saved location
            FileOperations.SaveLocation = "";
            //Launches the LoadGameEvent
            _events.PublishOnUIThread(new LoadGameEvent());
        }

        /// <summary>
        /// The event for when the LoadGame button is pressed
        /// </summary>
        public void LoadGame()
        {
            //Clear the saved location 
            FileOperations.SaveLocation = "";
            FileOperations.SelectSaveLocation();

            //If the SaveLocation still doesn't have a value
            //Don't do anything
            if (FileOperations.SaveLocation != "Cancelled")
            {
                _events.BeginPublishOnUIThread(new LoadGameEvent());
            }
        }
    }
}