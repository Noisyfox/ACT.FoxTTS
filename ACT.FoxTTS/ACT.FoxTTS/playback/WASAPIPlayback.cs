using System.Collections.Generic;
using System.Linq;
using ACT.FoxTTS.localization;
using NAudio.CoreAudioApi;
using NAudio.Wave;

namespace ACT.FoxTTS.playback
{
    public class WASAPIPlayback : NAudioPlayerBase
    {
        public override string Name => SoundPlayerWrapper.PlayerWASAPI;

        protected override IWavePlayer CreateWavePlayer(string deviceId)
        {
            MMDevice device = null;
            if (deviceId != null)
            {
                using (var deviceEnumerator = new MMDeviceEnumerator())
                {
                    device = deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active)
                        .FirstOrDefault(it => it.ID == deviceId);
                }
            }

            return device == null ? new WasapiOut() : new WasapiOut(device, AudioClientShareMode.Shared, false, 200);
        }

        public override List<Device> ListDevices()
        {
            var devices = new List<Device>
            {
                new Device
                {
                    ID = null,
                    Name = strings.deviceDefault,
                }
            };

            using (var deviceEnumerator = new MMDeviceEnumerator())
            {
                foreach (var device in deviceEnumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active))
                {
                    devices.Add(new Device
                    {
                        ID = device.ID,
                        Name = device.FriendlyName,
                    });
                }
            }

            return devices;
        }
    }
}
