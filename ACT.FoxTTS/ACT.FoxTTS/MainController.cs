using ACT.FoxCommon.core;
using ACT.FoxTTS.preprocess;

namespace ACT.FoxTTS
{
    public class MainController : MainControllerBase
    {

        public delegate void OnLanguageChangedDelegate(bool fromView, string lang);

        public event OnLanguageChangedDelegate LanguageChanged;

        public void NotifyLanguageChanged(bool fromView, string lang)
        {
            LanguageChanged?.Invoke(fromView, lang);
        }

        public delegate void OnTTSEngineChangedDelegate(bool fromView, string engine);

        public event OnTTSEngineChangedDelegate TTSEngineChanged;

        public void NotifyTTSEngineChanged(bool fromView, string engine)
        {
            TTSEngineChanged?.Invoke(fromView, engine);
        }

        public delegate void OnPlayerChangedDelegate(bool fromView, string player);

        public event OnPlayerChangedDelegate PlayerChanged;

        public void NotifyPlayerChanged(bool fromView, string player)
        {
            PlayerChanged?.Invoke(fromView, player);
        }

        public delegate void OnPreProcessorSettingsChangedDelegate(bool fromView, PreProcessorSettings settings);

        public event OnPreProcessorSettingsChangedDelegate PreProcessorSettingsChanged;

        public void NotifyPreProcessorSettingsChanged(bool fromView, PreProcessorSettings settings)
        {
            PreProcessorSettingsChanged?.Invoke(fromView, settings);
        }
    }
}
