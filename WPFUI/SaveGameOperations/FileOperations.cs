using System;
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
        private static readonly string _defaultSaveName = "SmackYourBrotherSave.txt";

        /// <summary>
        /// Holds the default location for the game save
        /// </summary>
        private static readonly string _defaultSaveLocation = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), _defaultSaveName);

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
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Title = "Save your game",
                FileName = _defaultSaveName,
                InitialDirectory = _defaultSaveLocation
            };

            var dialogResult = saveDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                if (saveDialog.FileName != "")
                {
                    //Update the save location
                    SaveLocation = saveDialog.FileName;
                }
            }
            else if (dialogResult == DialogResult.Cancel)
            {
                //Display popup
                PopupHelper.ShowPopup("NOT SAVED!", $"Your game has not been saved");
                SaveLocation = "Cancelled";
            }
            else
            {
                //Use the default location
                SaveLocation = _defaultSaveLocation;
            }
            saveDialog.Dispose();
        }

        /// <summary>
        /// Used to select a pre-existing save file and populate SaveLocation
        /// </summary>
        public static void SelectSaveLocation()
        {
            OpenFileDialog saveDialog = new OpenFileDialog
            {
                Title = "Select the game save",
                Filter = "TXT Files|*.txt",
                InitialDirectory = _defaultSaveLocation
            };

            var dialogResult = saveDialog.ShowDialog();

            if (dialogResult == DialogResult.OK)
            {
                //Update the save location
                SaveLocation = saveDialog.FileName;
            }else if (dialogResult == DialogResult.Cancel)
            {
                SaveLocation = "Cancelled";
            }
            saveDialog.Dispose();
        }

        /// <summary>
        /// Used to write the data to the file
        /// </summary>
        /// <param name="json"></param>
        public static void SaveData(string json)
        {
            if (SaveLocation != "Cancelled")
            {
                if (string.IsNullOrEmpty(SaveLocation))
                {
                    NewSaveLocation();
                }

                if (SaveLocation != "Cancelled")
                {
                    File.WriteAllText(SaveLocation, json);
                    //Display popup
                    PopupHelper.ShowPopup("SAVED!", $"Your game has been saved to: {SaveLocation}");
                }
            }
            else
            {
                NewSaveLocation();
            }
        }

        /// <summary>
        /// Loads the game data from the file and returns it as a string
        /// </summary>
        /// <returns></returns>
        public static string LoadData()
        {
            if (string.IsNullOrEmpty(SaveLocation))
            {
                SelectSaveLocation();
            }

            return File.ReadAllText(SaveLocation);
        }
    }
}