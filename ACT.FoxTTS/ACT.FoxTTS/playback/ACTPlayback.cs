using System;
using System.Collections.Generic;
using ACT.FoxCommon;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.localization;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS.playback
{
    public class ACTPlayback : IPlayer
    {
        private FoxTTSPlugin _plugin;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public string Name => SoundPlayerWrapper.PlayerACT;

        public bool SupportVolumeControl => true;

        public bool SupportVolumeBoost => false;

        public bool SupportSessionControl => false;

        public void Stop()
        {
        }

        public void Play(string file, int volume, string deviceId)
        {
            ActWmpPlay(file, volume);
        }

        public List<Device> ListDevices() => null;

        /// <summary>
        /// Play sound with ACT's WMP wrapper API
        /// </summary>
        private void ActWmpPlay(string WavFilePath, int VolumePercent)
        {
            try
            {
                ActGlobals.oFormActMain.PlaySoundWmpApi(WavFilePath, VolumePercent);
            }
            catch (Exception e)
            {
                if (e.ToString().Contains("6BF52A52-394A-11D3-B153-00C04F79FAA6"))
                {
                    // WMP unavailable
                    Logger.Error(strings.msgErrorWMPUnavailable);
                    Logger.Debug("Detailed exception:", e);
            
                    ActGlobals.oFormActMain.SafeInvoke(new Action(() =>
                    {
                        // Show notification
                        var ts = new TraySlider
                        {
                            ButtonLayout = TraySlider.ButtonLayoutEnum.OneButton,
                        };
                        ts.ShowTraySlider(strings.msgErrorWMPUnavailable, strings.actPanelTitle);
            
                        // Automatically switch to DirectSound
                        _plugin.SettingsTab.SwitchPlaybackPlayer(SoundPlayerWrapper.PlayerDirectSound);

                        // And retry this request using WASAPI
                        _plugin.SoundPlayer.Play(WavFilePath);
                    }));
                }
                else
                {
                    throw;
                }
            }
        }
    }
}
