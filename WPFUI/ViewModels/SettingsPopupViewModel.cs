using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WPFUI.Helpers;

namespace WPFUI.ViewModels
{
    /// <summary>
    /// Logic for the settings popup 
    /// </summary>
    public class SettingsPopupViewModel : Screen
    {
        /// <summary>
        /// Controls whether the purchase sound is played or not
        /// </summary>
        /// <param name="i"></param>
        public static void PurchaseSound(string i)
        {
            if (i == "true")
            {
                Sounds.PlayPurchaseSoundBool = true;
            }
            else
            {
                Sounds.PlayPurchaseSoundBool = false;
            }
        }

        /// <summary>
        /// Controls whether the smack sound is played or not
        /// </summary>
        /// <param name="i"></param>
        public static void SmackSound(string i)
        {
            if (i == "true")
            {
                Sounds.PlaySmackSoundBool = true;
            }
            else
            {
                Sounds.PlaySmackSoundBool = false;
            }
        }

        /// <summary>
        /// Updates the smack toggle button depending on the boolean value
        /// </summary>
        public bool SmackIsChecked { get { return Sounds.PlaySmackSoundBool; } }

        /// <summary>
        /// Updates the purchase toggle button depending on the boolean value
        /// </summary>
        public bool PurchaseIsChecked { get { return Sounds.PlayPurchaseSoundBool; } }

        /// <summary>
        /// The close button for the settings
        /// </summary>
        public void Close()
        {
            TryClose();
        }
    }
}