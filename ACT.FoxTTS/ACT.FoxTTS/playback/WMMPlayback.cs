using System;
using System.Runtime.InteropServices;
using System.Text;

namespace ACT.FoxTTS.playback
{
    public class WMMPlayback : IPluginComponent
    {
        private FoxTTSPlugin _plugin;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        /// <summary>
        /// Play the given wave file using WMM.
        /// This method needs to be called from main thread otherwise
        /// a MCIERR_CANNOT_LOAD_DRIVER error will occur.
        /// </summary>
        public void PlaySound(string waveFile)
        {
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

                    _plugin.Controller.NotifyLogMessageAppend(false,
                        $"Unable to send command to WMM: \"{c}\": {message} ({errno})");

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

    }
}
