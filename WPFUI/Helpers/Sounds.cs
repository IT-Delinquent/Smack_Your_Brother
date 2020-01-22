using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Resources;
using System.IO;
using System.Reflection;

namespace WPFUI.Helpers
{
    /// <summary>
    /// Contains methods for outputting sound
    /// </summary>
    public static class Sounds
    {
        /// <summary>
        /// Background music for the application
        /// </summary>
        private static readonly MediaPlayer _backgroundMusic = new MediaPlayer();

        /// <summary>
        /// The name for the background music temp file
        /// </summary>
        public static readonly string BackgroundMusicFileName = "SmackYourBrotherBackgroundMusicTemp.wav";

        /// <summary>
        /// The name for the background music resource
        /// </summary>
        public static readonly string BackgroundMusicResourceName = "WPFUI.Assets.Sounds.backgroundmusic.wav";

        /// <summary>
        /// Smack one sound effect
        /// </summary>
        private static readonly SoundPlayer _smackSoundOne = new SoundPlayer(WPFUI.Properties.Resources.punch1);

        /// <summary>
        /// Smack two sound effect
        /// </summary>
        private static readonly SoundPlayer _smackSoundTwo = new SoundPlayer(WPFUI.Properties.Resources.punch2);

        /// <summary>
        /// Random number for getting a smack sound effect
        /// </summary>
        private static readonly Random randomNumber = new Random();

        /// <summary>
        /// Starts the background music
        /// </summary>
        public static void StartBackgroundMusic()
        {

            _backgroundMusic.Open(new Uri( Path.Combine(Path.GetTempPath(), BackgroundMusicFileName)));
            _backgroundMusic.MediaEnded += new EventHandler(BackgroundMusic_Ended);
            _backgroundMusic.Play();
        }

        /// <summary>
        /// Used to continuously reset the background music once it's ended
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void BackgroundMusic_Ended(object sender, EventArgs e)
        {
            _backgroundMusic.Position = TimeSpan.Zero;
            _backgroundMusic.Play();
        }

        /// <summary>
        /// Stop the background music and disposes of the object
        /// </summary>
        public static void StopBackgroundMusic()
        {
            _backgroundMusic.Stop();
            _backgroundMusic.Close();
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