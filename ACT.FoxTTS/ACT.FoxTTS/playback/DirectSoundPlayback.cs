using System;
using System.Collections.Generic;
using System.Linq;
using NAudio.Wave;

namespace ACT.FoxTTS.playback
{
    public class DirectSoundPlayback : NAudioPlayerBase
    {

        public override string Name => SoundPlayerWrapper.PlayerDirectSound;

        protected override IWavePlayer CreateWavePlayer(string deviceId)
        {
            return deviceId == null ? new DirectSoundOut() : new DirectSoundOut(Guid.Parse(deviceId));
        }

        public override List<Device> ListDevices()
        {
            return DirectSoundOut.Devices.Select(it => new Device
            {
                ID = it.Guid.ToString(),
                Name = it.Description,
            }).ToList();
        }
    }
}
