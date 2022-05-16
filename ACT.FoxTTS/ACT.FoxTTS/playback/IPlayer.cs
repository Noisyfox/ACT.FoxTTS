using System.Collections.Generic;

namespace ACT.FoxTTS.playback
{
    public interface IPlayer : IPluginComponent
    {
        string Name { get; }

        bool SupportVolumeControl { get; }

        void Stop();

        void Play(string file, int volume, string deviceId);

        /// <summary>
        /// Null means this player does not support specifying device.
        /// Empty list means no available device
        /// </summary>
        List<Device> ListDevices();
    }
}
