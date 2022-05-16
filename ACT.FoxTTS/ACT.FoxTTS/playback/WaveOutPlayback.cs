using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.localization;
using NAudio;
using NAudio.Wave;

namespace ACT.FoxTTS.playback
{
    public class WaveOutPlayback : NAudioPlayerBase
    {
        public override string Name => SoundPlayerWrapper.PlayerWaveOut;

        protected override IWavePlayer CreateWavePlayer(string deviceId)
        {
            return deviceId == null ? new WaveOutEvent() : new WaveOutEvent
            {
                DeviceNumber = int.Parse(deviceId)
            };
        }

        public override List<Device> ListDevices()
        {
            var deviceCount = WaveInterop.waveOutGetNumDevs();
            var devices = new List<Device>
            {
                new Device
                {
                    ID = "-1",
                    Name = strings.deviceDefault,
                }
            };
            var capsSize = Marshal.SizeOf<WaveOutCapabilities>();
            for (var i = 0; i < deviceCount; i++)
            {
                var result = WaveInterop.waveOutGetDevCaps((IntPtr) i, out var caps, capsSize);
                if (result == MmResult.NoError)
                {
                    devices.Add(new Device
                    {
                        ID = i.ToString(),
                        Name = caps.ProductName,
                    });
                }
                else
                {
                    Logger.Error($"WaveOutPlayback: Unable to get capabilities for device {i}: {result}, ignored");
                }
            }

            return devices;
        }
    }
}
