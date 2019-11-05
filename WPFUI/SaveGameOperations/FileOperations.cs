﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WPFUI.Helpers;

namespace WPFUI.SaveGameOperations
{
    /// <summary>
    /// Contains methods and properties for saving game data to disk
    /// </summary>
    public class FileOperations
    {
        /// <summary>
        /// Holds the default name for the game save
        /// </summary>
        private static string _defaultSaveName = "SmackYourBrotherSave.txt";

        /// <summary>
        /// Privately holds the save location
        /// </summary>
        private static string _saveLocation;

        /// <summary>
        /// Public get/set for the save location
        /// </summary>
        public static string SaveLocation
        {
            get { return _saveLocation; }
            set 
            { 
                _saveLocation = value; 
            }
        }

        /// <summary>
        /// Used to get a new save location and populate SaveLocation
        /// </summary>
        /// <returns></returns>
        public static void NewSaveLocation()
        {
            SaveFileDialog saveDialog = new SaveFileDialog();
            saveDialog.FileName = _defaultSaveName;
            
            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                if (saveDialog.FileName != "")
                {
                    //Update the save location
                    SaveLocation = Path.GetFullPath(saveDialog.FileName);
                }
            }
            else
            {
                //Use the default location
                SaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _defaultSaveName);
            }

            saveDialog.Dispose();
        }

        /// <summary>
        /// Used to write the data to the file
        /// </summary>
        /// <param name="json"></param>
        public static void SaveData(string json)
        {
            if (string.IsNullOrEmpty(SaveLocation))
            {
                NewSaveLocation();
            }
            File.WriteAllText(SaveLocation, json);

            //Display popup
            PopupHelper.ShowPopup("SAVED!", $"Your game has been saved to: {SaveLocation}");
        }
    }
}