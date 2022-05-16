using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using ACT.FoxCommon.core;
using ACT.FoxCommon.logging;
using Advanced_Combat_Tracker;
using ImpromptuInterface;
using ImpromptuInterface.Build;

namespace ACT.FoxTTS
{
    public class TTSInjector : BaseThreading<FoxTTSPlugin>, IPluginComponent
    {

        internal FoxTTSPlugin _plugin;

        private readonly YukkuriInjector yukkuriInjector;
        private readonly ActInjector actInjector;

        public TTSInjector()
        {
            yukkuriInjector = new YukkuriInjector(this);
            actInjector = new ActInjector(this);
        }

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
            yukkuriInjector.UnInject();
            actInjector.UnInject();
        }

        protected override void DoWork(FoxTTSPlugin context)
        {
            bool firstRun = true;
            PluginIntegration currentIntegration = PluginIntegration.Auto;
            bool currentInjected = false;

            while (!WorkingThreadStopping)
            {
                bool longWait = true;
                try
                {
                    if (ActGlobals.oFormActMain.Visible)
                    {
                        PluginIntegration targetIntegration = context.Settings.PluginIntegration;
                        bool successfullyInjected = false;
                        switch (targetIntegration)
                        {
                            case PluginIntegration.Auto:
                                successfullyInjected = true;
                                if (YukkuriInjector.isYukkuriEnabled())
                                {
                                    actInjector.UnInject();
                                    yukkuriInjector.Inject();
                                    targetIntegration = PluginIntegration.Yukkuri;
                                }
                                else
                                {
                                    yukkuriInjector.UnInject();
                                    actInjector.Inject();
                                    targetIntegration = PluginIntegration.Act;
                                    longWait = false;
                                }
                                break;
                            case PluginIntegration.Act:
                                yukkuriInjector.UnInject();
                                actInjector.Inject();
                                successfullyInjected = true;
                                longWait = false;
                                break;
                            case PluginIntegration.Yukkuri:
                                actInjector.UnInject();
                                if (YukkuriInjector.isYukkuriEnabled())
                                {
                                    successfullyInjected = true;
                                    yukkuriInjector.Inject();
                                }
                                else
                                {
                                    yukkuriInjector.UnInject();
                                    longWait = false;
                                }
                                break;
                        }

                        if (currentIntegration != targetIntegration || currentInjected != successfullyInjected || firstRun)
                        {
                            currentIntegration = targetIntegration;
                            currentInjected = successfullyInjected;
                            firstRun = false;

                            switch (targetIntegration)
                            {
                                case PluginIntegration.Act:
                                    Logger.Info($"ACT integration: {successfullyInjected}");
                                    break;
                                case PluginIntegration.Yukkuri:
                                    Logger.Info($"Yukkuri integration: {successfullyInjected}");
                                    break;
                            }
                        }
                    }
                }
                catch (Exception e)
                {
                    Logger.Error("Failed to inject TTS integration", e);
                }

                SafeSleep(longWait ? 5000 : 1000);
            }
        }

        internal new void WakeUp()
        {
            base.WakeUp();
        }

        public void PlayTTSYukkuri(string waveFile, dynamic playDevice, bool isSync, float? volume)
        {
            yukkuriInjector.PlayTTSYukkuri(waveFile, playDevice, isSync, volume);
        }
    }

    #region ACT TTS Integration

    class ActInjector
    {
        private readonly TTSInjector injector;

        private FormActMain.PlayTtsDelegate originalTTSMethod;

        public ActInjector(TTSInjector injector)
        {
            this.injector = injector;
        }

        public void Inject()
        {
            if (ActGlobals.oFormActMain.PlayTtsMethod != Speak)
            {
                originalTTSMethod = (FormActMain.PlayTtsDelegate)ActGlobals.oFormActMain.PlayTtsMethod.Clone();
                ActGlobals.oFormActMain.PlayTtsMethod = Speak;
            }
        }


        public void UnInject()
        {
            if (originalTTSMethod != null)
            {
                ActGlobals.oFormActMain.PlayTtsMethod = originalTTSMethod;
                originalTTSMethod = null;
            }
        }

        public void Speak(string message)
        {
            Task.Run(() =>
            {
                injector._plugin.Speak(message);
            });
        }

    }

    #endregion

    #region Yukurri Integration

    class YukkuriInjector
    {
        private static readonly HashSet<string> YUKKURI_INIT_SUCCESS = new HashSet<string>(new[]
        {
            "Plugin Started".ToUpper(),
            "插件加载成功.".ToUpper(),
        });

        private readonly TTSInjector injector;
        private YukkuriContext _yukkuriContext;
        private dynamic _originalYukkuriInstance = null;

        public static bool isYukkuriEnabled()
        {
            bool yukkuriCurrentEnabled = false;
            foreach (var item in ActGlobals.oFormActMain.ActPlugins)
            {
                if (item.pluginFile.Name.ToUpper() == "ACT.TTSYukkuri.dll".ToUpper() &&
                    YUKKURI_INIT_SUCCESS.Contains(item.lblPluginStatus.Text.ToUpper()))
                {
                    yukkuriCurrentEnabled = true;
                    break;
                }
            }

            return yukkuriCurrentEnabled;
        }

        public YukkuriInjector(TTSInjector injector)
        {
            this.injector = injector;
        }

        public void Inject()
        {
            var context = _yukkuriContext;

            var ass = AppDomain.CurrentDomain.GetAssemblies()
                .SingleOrDefault(assembly => assembly.GetName().Name == "ACT.TTSYukkuri.Core");
            if (context == null || context.YukkuriAssembly != ass)
            {
                context = new YukkuriContext(injector._plugin, ass);
                _yukkuriContext = context;
                _originalYukkuriInstance = null;
            }

            lock (context.SpeechControllerLockObject)
            {
                var instance = context.SpeechControllerInstanceObject;
                if (instance == null || !(instance is IActLikeProxyInitialize))
                {
                    _originalYukkuriInstance = instance;
                    var myInterface = Impromptu.DynamicActLike(this, context.ISpeechControllerType);
                    _yukkuriContext.SpeechControllerInstanceObject = myInterface;
                    Logger.Info("TTSYukkuri injected!");
                }
            }
        }

        public void UnInject()
        {
            try
            {

                var c = _yukkuriContext;
                if (c != null)
                {
                    lock (c.SpeechControllerLockObject)
                    {
                        c.SpeechControllerInstanceObject = _originalYukkuriInstance;
                    }
                }
            }
            catch (Exception e)
            {
                Logger.Error("Failed to uninject YukkuriInjector", e);
            }

            _yukkuriContext = null;
            _originalYukkuriInstance = null;
        }

        void Initialize()
        {
            Logger.Info("Initialize in YukkuriInjector");
        }

        void Free()
        {
            _originalYukkuriInstance?.Free();
            _originalYukkuriInstance = null;

            Logger.Info("Free in YukkuriInjector");
            injector.WakeUp();
        }

        // ACT.Hojoring 7.8.7+
        void Speak(string text, dynamic playDevice, dynamic voicePalette, bool isSync, float? volume)
        {
            injector._plugin.Speak(text);
        }

        // ACT.Hojoring 5.26.6+
        void Speak(string text, dynamic playDevice, bool isSync, float? volume)
        {
            injector._plugin.Speak(text);
        }

        void Speak(string text, dynamic playDevice, bool isSync)
        {
            injector._plugin.Speak(text);
        }

        void Speak(string text, dynamic playDevice)
        {
            injector._plugin.Speak(text);
        }

        // Old Yukkuri version < 3.4
        void Speak(string text)
        {
            injector._plugin.Speak(text);
        }

        public void PlayTTSYukkuri(string waveFile, dynamic playDevice, bool isSync, float? volume)
        {
            _yukkuriContext?.Play(waveFile, playDevice, isSync, volume);
        }

        private class YukkuriContext
        {
            public Assembly YukkuriAssembly { get; }

            public object SpeechControllerLockObject { get; }
            public Type ISpeechControllerType { get; }
            private readonly FieldInfo _speechControllerInstanceFieldInfo;
            private readonly MethodInfo _soundPlayerWrapperPlayMethodInfo;
            private readonly FoxTTSPlugin _plugin;

            public dynamic SpeechControllerInstanceObject
            {
                get => _speechControllerInstanceFieldInfo.GetValue(null);
                set => _speechControllerInstanceFieldInfo.SetValue(null, value);
            }

            public YukkuriContext(FoxTTSPlugin plugin, Assembly yukkuriAssembly)
            {
                _plugin = plugin;
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

            public void Play(string waveFile, dynamic playDevice, bool isSync, float? volume)
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
                    case 4:
                        // ACT.Hojoring 5.26.6+
                        _soundPlayerWrapperPlayMethodInfo.Invoke(null, new object[] { waveFile, playDevice, isSync, volume });
                        break;
                    default:
                        Logger.Error($"Unsupported ACT.Hojoring version! ACT.TTSYukkuri.SoundPlayerWrapper.Play() has unexpected parameter count {paramCount}.");
                        break;
                }
            }
        }
    }

    #endregion
}
