using System;
using System.Linq;
using System.Reflection;
using ACT.FoxCommon.core;
using ImpromptuInterface;
using ImpromptuInterface.Build;

namespace ACT.FoxTTS
{
    class TTSInjector : BaseThreading<FoxTTSPlugin>, IPluginComponent
    {
        private FoxTTSPlugin _plugin;

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
            try
            {
                var ass = AppDomain.CurrentDomain.GetAssemblies()
                    .SingleOrDefault(assembly => assembly.GetName().Name == "ACT.TTSYukkuri.Core");
                var s = ass.GetType("ACT.TTSYukkuri.SpeechController");
                var instanceField = s.GetField("instance", BindingFlags.Static | BindingFlags.NonPublic);
                var lockObjectField = s.GetField("lockObject", BindingFlags.Static | BindingFlags.NonPublic);
                var lockObject = lockObjectField.GetValue(null);
                lock (lockObject)
                {
                    instanceField.SetValue(null, _originalInstance);
                }
            }
            catch (Exception e)
            {
                _plugin.Controller.NotifyLogMessageAppend(false, e.ToString());
            }
        }

        protected override void DoWork(FoxTTSPlugin context)
        {
            while (!WorkingThreadStopping)
            {
                bool longWait = true;
                try
                {
                    var ass = AppDomain.CurrentDomain.GetAssemblies()
                        .SingleOrDefault(assembly => assembly.GetName().Name == "ACT.TTSYukkuri.Core");
                    if (ass == null)
                    {
                        longWait = false;
                    }
                    else
                    {
                        var intType = ass.GetType("ACT.TTSYukkuri.ISpeechController");

                        var s = ass.GetType("ACT.TTSYukkuri.SpeechController");
                        var instanceField = s.GetField("instance", BindingFlags.Static | BindingFlags.NonPublic);
                        var lockObjectField = s.GetField("lockObject", BindingFlags.Static | BindingFlags.NonPublic);
                        var lockObject = lockObjectField.GetValue(null);
                        lock (lockObject)
                        {
                            dynamic instance = instanceField.GetValue(null);
                            if (instance == null || !(instance is IActLikeProxyInitialize))
                            {
                                _originalInstance = instance;
                                var myInterface = Impromptu.DynamicActLike(this, new[] {intType});
                                instanceField.SetValue(null, myInterface);
                                context.Controller.NotifyLogMessageAppend(false, "TTSYukkuri injected!");
                            }
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

        void Speak(string text, dynamic playDevice)
        {
            _plugin.Controller.NotifyLogMessageAppend(false, $"Speak {text}");
        }
    }
}
