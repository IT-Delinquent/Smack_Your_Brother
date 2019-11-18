using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Resources;

namespace WPFUI.Helpers
{
    /// <summary>
    /// Contains methods for outputting sound
    /// </summary>
    public class Sounds
    {
        /// <summary>
        /// Background music for the application
        /// </summary>
        private static SoundPlayer _backgroundMusic = new SoundPlayer(WPFUI.Properties.Resources.backgroundmusic);

        /// <summary>
        /// Smack one sound effect
        /// </summary>
        private static SoundPlayer _smackSoundOne = new SoundPlayer(WPFUI.Properties.Resources.punch1);

        /// <summary>
        /// Smack two sound effect
        /// </summary>
        private static SoundPlayer _smackSoundTwo = new SoundPlayer(WPFUI.Properties.Resources.punch2);

        /// <summary>
        /// Random number for getting a smack sound effect
        /// </summary>
        private static Random randomNumber = new Random();

        /// <summary>
        /// Starts the background music
        /// </summary>
        public static void StartBackgroundMusic()
        {
            _backgroundMusic.PlayLooping();
        }

        /// <summary>
        /// Stop the background music and disposes of the object
        /// </summary>
        public static void StopBackgroundMusic()
        {
            _backgroundMusic.Stop();
            _backgroundMusic.Dispose();
        }

        /// <summary>
        /// Play a random smack sound
        /// </summary>
        public static void PlayRandomSmack()
        {
            if (randomNumber.NextDouble() < 0.5)
            {
                _smackSoundOne.Play();
            }
            else
            {
                _smackSoundTwo.Play();
            }
        }
    }
}