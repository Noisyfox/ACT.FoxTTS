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
    }
}
