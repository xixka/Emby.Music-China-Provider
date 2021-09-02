using System;
using System.IO;
using MediaBrowser.Common.Configuration;
using MediaBrowser.Model.IO;
using MediaBrowser.Model.Logging;

namespace MusicProvider
{
    public class ImageHelper
    {
        public static void SaveImageInfo(IApplicationPaths appPaths, ILogger logger, IFileSystem fileSystem, string musicId, string url)
        {
            if (appPaths == null)
            {
                throw new ArgumentNullException("appPaths");
            }
            if (string.IsNullOrEmpty(musicId))
            {
                throw new ArgumentNullException("musicId");
            }
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentNullException("url");
            }

            var cachePath = Path.Combine(appPaths.CachePath, "Music-China", musicId, "image.txt");
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    fileSystem.DeleteFile(cachePath);
                }
                else
                {
                    fileSystem.CreateDirectory(fileSystem.GetDirectoryName(cachePath));
                    fileSystem.WriteAllText(cachePath, url );
                }
            }
            catch (IOException ex)
            {
                // Don't fail if this is unable to write
                logger.ErrorException("Error saving to {0}", ex, cachePath);
            }
        }
    }
}