﻿using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.EventModels;
using WPFUI.Helpers;
using WPFUI.Models;
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
            //Clear the saved location
            FileOperations.SaveLocation = string.Empty;
            //Updates the events private variables
            _events = events;
        }

        /// <summary>
        /// The event for when the NewGame button is pressed
        /// </summary>
        public void NewGame()
        {
            //Launches the LoadGameEvent
            GameViewModel.LoadList = new List<GameSaveClass>() { new GameSaveClass { ID = "DummyFromNewGame", Value = 1.0 } };
            _events.PublishOnUIThread(new LoadGameEvent());
        }

        /// <summary>
        /// The event for when the LoadGame button is pressed
        /// </summary>
        public void LoadGame()
        {
            FileOperations.SelectLoadLocation();

            /*
             At this point the value of SaveLocation could either be a valid path or "Cancelled"
            */

            if (FileOperations.SaveLocation != "Cancelled") 
            {
                string loadResponse = FileOperations.LoadData();
                //Try to load the file 
                if (loadResponse.StartsWith("Failed")) 
                {
                    //Loading the file failed
                    PopupHelper.ShowPopup("FAILED", loadResponse.Replace("Failed", ""));
                }
                else
                {
                    //Try to parse the loadResponse
                    List<GameSaveClass> parseResponse = LoadData.CreateData(loadResponse);

                    if (parseResponse.Count() == 1)
                    {
                        //The parsed data only contains one entry, the load has failed
                        PopupHelper.ShowPopup("FAILED", "File format not recognised");
                    }
                    else
                    {
                        //Load checks have passed, launch the game
                        GameViewModel.LoadList = parseResponse;
                        _events.PublishOnUIThread(new LoadGameEvent());
                        PopupHelper.ShowPopup("LOADED", "Your save file has been loaded");
                    }
                }
            }
        }
    }
}