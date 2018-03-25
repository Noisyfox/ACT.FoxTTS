using ACT.FoxCommon.core;

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

        public delegate void OnYukkuriEnabledChangedDelegate(bool fromView, bool enabled);

        public event OnYukkuriEnabledChangedDelegate YukkuriEnabledChanged;

        public void NotifyYukkuriEnabledChanged(bool fromView, bool enabled)
        {
            YukkuriEnabledChanged?.Invoke(fromView, enabled);
        }

        public delegate void OnYukkuriPlaybackEnabledChangedDelegate(bool fromView, bool enabled);

        public event OnYukkuriEnabledChangedDelegate YukkuriPlaybackEnabledChanged;

        public void NotifyYukkuriPlaybackEnabledChanged(bool fromView, bool enabled)
        {
            YukkuriPlaybackEnabledChanged?.Invoke(fromView, enabled);
        }
    }
}
