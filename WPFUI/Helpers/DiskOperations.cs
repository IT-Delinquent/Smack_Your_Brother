using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace WPFUI.Helpers
{
    /// <summary>
    /// Contains methods for file system interactions
    /// </summary>
    public class DiskOperations
    {

        /// <summary>
        /// Saves the background music to a temp file
        /// </summary>
        public static void SaveMusicToDisk()
        {
            using (FileStream fileStream = File.Create(Path.GetTempPath() + Sounds.BackgroundMusicFileName))
            {
                Assembly.GetExecutingAssembly().GetManifestResourceStream(Sounds.BackgroundMusicResourceName).CopyTo(fileStream);
            }
        }

        /// <summary>
        /// Removes the temp background music file
        /// </summary>
        public static void DeleteMusicFromDisk()
        {
            File.Delete(Path.Combine(Path.GetTempPath(), Sounds.BackgroundMusicFileName));
        }
    }
}