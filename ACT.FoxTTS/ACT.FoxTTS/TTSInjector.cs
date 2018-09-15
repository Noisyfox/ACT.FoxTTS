using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ACT.FoxCommon.core;
using Advanced_Combat_Tracker;
using ImpromptuInterface;
using ImpromptuInterface.Build;

namespace ACT.FoxTTS
{
    public class TTSInjector : BaseThreading<FoxTTSPlugin>, IPluginComponent
    {
        private static readonly HashSet<string> YUKKURI_INIT_SUCCESS = new HashSet<string>(new[]
        {
            "Plugin Started".ToUpper(),
            "插件加载成功.".ToUpper(),
        });

        private FoxTTSPlugin _plugin;
        private YukkuriContext _yukkuriContext;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        public void Stop()
        {
            StopWorkingThread();

            // Restore
            UnInjectYukkuri();
        }

        protected override void DoWork(FoxTTSPlugin context)
        {
            bool firstRun = true;
            bool yukkuriEnabled = false;

            while (!WorkingThreadStopping)
            {
                bool longWait = true;
                try
                {
                    bool currentEnabled = false;
                    if (ActGlobals.oFormActMain.Visible)
                    {
                        foreach (var item in ActGlobals.oFormActMain.ActPlugins)
                        {
                            if (item.pluginFile.Name.ToUpper() == "ACT.TTSYukkuri.dll".ToUpper() &&
                                YUKKURI_INIT_SUCCESS.Contains(item.lblPluginStatus.Text.ToUpper()))
                            {
                                currentEnabled = true;
                                break;
                            }
                        }

                        if (currentEnabled)
                        {
                            var ass = AppDomain.CurrentDomain.GetAssemblies()
                                .SingleOrDefault(assembly => assembly.GetName().Name == "ACT.TTSYukkuri.Core");
                            if (_yukkuriContext == null || _yukkuriContext.YukkuriAssembly != ass)
                            {
                                _yukkuriContext = new YukkuriContext(ass);
                                _originalInstance = null;
                            }
                        }
                        else
                        {
                            UnInjectYukkuri();

                            longWait = false;
                            _yukkuriContext = null;
                            _originalInstance = null;
                        }

                        if (yukkuriEnabled != currentEnabled || firstRun)
                        {
                            yukkuriEnabled = currentEnabled;
                            firstRun = false;

                            context.Controller.NotifyYukkuriEnabledChanged(false, yukkuriEnabled);
                            context.Controller.NotifyLogMessageAppend(false, $"yukkuriEnabled = {yukkuriEnabled}");
                        }

                        if (yukkuriEnabled)
                        {
                            InjectYukkuri();
                        }
                    }
                }
                catch (Exception e)
                {
                    context.Controller.NotifyLogMessageAppend(false, e.ToString());
                }

                SafeSleep(longWait ? 1000 : 100);
            }
        }

        private dynamic _originalInstance = null;

        private void InjectYukkuri()
        {
            var c = _yukkuriContext;
            if (c != null)
            {
                lock (c.SpeechControllerLockObject)
                {
                    var instance = c.SpeechControllerInstanceObject;
                    if (instance == null || !(instance is IActLikeProxyInitialize))
                    {
                        _originalInstance = instance;
                        var myInterface = Impromptu.DynamicActLike(this, c.ISpeechControllerType);
                        _yukkuriContext.SpeechControllerInstanceObject = myInterface;
                        _plugin.Controller.NotifyLogMessageAppend(false, "TTSYukkuri injected!");
                    }
                }
            }
        }

        private void UnInjectYukkuri()
        {
            try
            {

                var c = _yukkuriContext;
                if (c != null)
                {
                    lock (c.SpeechControllerLockObject)
                    {
                        c.SpeechControllerInstanceObject = _originalInstance;
                    }
                }
            }
            catch (Exception e)
            {
                _plugin.Controller.NotifyLogMessageAppend(false, e.ToString());
            }

            _originalInstance = null;
        }

        void Initialize()
        {
            _plugin.Controller.NotifyLogMessageAppend(false, "Initialize");
        }

        void Free()
        {
            _originalInstance?.Free();
            _originalInstance = null;

            _plugin.Controller.NotifyLogMessageAppend(false, "Free");
            WakeUp();
        }

        void Speak(string text, dynamic playDevice, bool isSync)
        {
            _plugin.Controller.NotifyLogMessageAppend(false, $"Speak {text}");
            _plugin.Speak(text, playDevice, isSync);
        }

        void Speak(string text, dynamic playDevice)
        {
            _plugin.Controller.NotifyLogMessageAppend(false, $"Speak {text}");
            _plugin.Speak(text, playDevice);
        }

        // Old Yukkuri version < 3.4
        void Speak(string text)
        {
            _plugin.Controller.NotifyLogMessageAppend(false, $"Speak {text}");
            _plugin.Speak(text, 0);
        }

        public void PlayTTSYukkuri(string waveFile, dynamic playDevice, bool isSync = false)
        {
            _yukkuriContext?.Play(waveFile, playDevice, isSync);
        }

        private class YukkuriContext
        {
            public Assembly YukkuriAssembly { get; }

            public object SpeechControllerLockObject { get; }
            public Type ISpeechControllerType { get; }
            private readonly FieldInfo _speechControllerInstanceFieldInfo;
            private readonly MethodInfo _soundPlayerWrapperPlayMethodInfo;

            public dynamic SpeechControllerInstanceObject
            {
                get => _speechControllerInstanceFieldInfo.GetValue(null);
                set => _speechControllerInstanceFieldInfo.SetValue(null, value);
            }

            public YukkuriContext(Assembly yukkuriAssembly)
            {
                YukkuriAssembly = yukkuriAssembly;

                ISpeechControllerType = yukkuriAssembly.GetType("ACT.TTSYukkuri.ISpeechController");

                var s = yukkuriAssembly.GetType("ACT.TTSYukkuri.SpeechController");
                _speechControllerInstanceFieldInfo =
                    s.GetField("instance", BindingFlags.Static | BindingFlags.NonPublic);
                var lockObjectField = s.GetField("lockObject", BindingFlags.Static | BindingFlags.NonPublic);

                SpeechControllerLockObject = lockObjectField.GetValue(null);

                s = yukkuriAssembly.GetType("ACT.TTSYukkuri.SoundPlayerWrapper");
                _soundPlayerWrapperPlayMethodInfo = s.GetMethod("Play");
            }

            public void Play(string waveFile, dynamic playDevice, bool isSync)
            {
                var paramCount = _soundPlayerWrapperPlayMethodInfo.GetParameters().Length;
                switch (paramCount)
                {
                    case 1:
                        // Old Yukkuri version < 3.4
                        _soundPlayerWrapperPlayMethodInfo.Invoke(null, new object[] { waveFile });
                        break;
                    case 2:
                        _soundPlayerWrapperPlayMethodInfo.Invoke(null, new object[] { waveFile, playDevice });
                        break;
                    case 3:
                        _soundPlayerWrapperPlayMethodInfo.Invoke(null, new object[] { waveFile, playDevice, isSync });
                        break;
                }
            }
        }
    }
}
