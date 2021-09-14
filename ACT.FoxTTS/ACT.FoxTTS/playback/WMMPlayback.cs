using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using ACT.FoxCommon.logging;

namespace ACT.FoxTTS.playback
{
    public class WMMPlayback : IPluginComponent
    {
        private const int MAX_PATH = 127;

        private FoxTTSPlugin _plugin;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        private static string GetDeviceType(string file)
        {
            var ext = Path.GetExtension(file).ToLower();
            switch (ext)
            {
                case ".mp3": return "mpegvideo!";
                case ".wav": return "waveaudio!";
            }

            return "";
        }

        /// <summary>
        /// Play the given wave file using WMM.
        /// This method needs to be called from main thread otherwise
        /// a MCIERR_CANNOT_LOAD_DRIVER error will occur.
        /// </summary>
        public void PlaySound(string waveFile)
        {
            if (waveFile.Length > MAX_PATH)
            {
                // Path too long for WMM, need to shorten
                // Try short path first.
                var shortPath = TryShortenPath(waveFile);
                if (shortPath != null)
                {
                    waveFile = shortPath;
                }
                else
                {
                    // Short path doesn't work, copy to system temp folder with a short file name.
                    var tmp = Path.GetTempFileName();
                    File.Copy(waveFile, tmp, true);
                    Logger.Debug("File path too long for WMM, tmp file used: " + tmp);

                    // Make sure tmp path is also not too long
                    if (tmp.Length > MAX_PATH)
                    {
                        shortPath = TryShortenPath(tmp);
                        if (shortPath != null)
                        {
                            waveFile = GetDeviceType(waveFile) + shortPath;
                        }
                        else
                        {
                            Logger.Warn("Unable to shorten path " + waveFile);
                        }
                    }
                    else
                    {
                        waveFile = GetDeviceType(waveFile) + tmp;
                    }
                }
            }

            SendCmd(new[]
            {
                "close all",
                "open \"" + waveFile + "\" alias foxTTS",
                "play foxTTS",
            });
        }

        private void SendCmd(string[] cmd)
        {
            foreach (var c in cmd)
            {
                var errno = mciSendString(c, null, 0, IntPtr.Zero);
                if (errno != 0)
                {
                    var buffer = new StringBuilder(128);
                    var message = mciGetErrorString(errno, buffer, buffer.Capacity) ? buffer.ToString() : "Unknown";

                    Logger.Error($"Unable to send command to WMM: \"{c}\": {message} ({errno})");

                    return;
                }
            }
        }

        [DllImport("winmm.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern int mciSendString(
            [In] string command,
            [Optional, In, Out] char[] returnBuffer,
            [Optional, In] int returnBufferCount,
            [Optional, In] IntPtr hNotifyWindow
        );

        [DllImport("winmm.dll", SetLastError = true)]
        private static extern bool mciGetErrorString([In] int error, [In, Out] StringBuilder buffer, [In] int bufferCount);

        [DllImport("kernel32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetShortPathNameW", SetLastError = true)]
        private static extern int GetShortPathName(string pathName, StringBuilder shortName, int cbShortName);

        private static string TryShortenPath(string path)
        {
            var buffer = new StringBuilder(MAX_PATH + 1);
            var len = GetShortPathName(path, buffer, buffer.Capacity);
            if (len > 0 && len <= MAX_PATH)
            {
                return buffer.ToString();
            }

            return null;
        }
    }
}
