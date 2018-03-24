using System.Globalization;
using ACT.FoxCommon.localization;

namespace ACT.FoxTTS.localization
{
    public static class Localization
    {
        public static readonly LanguageDef[] SupportedLanguages = {
            LanguageDef.BuildLangFromCulture("zh-CN"),
            LanguageDef.BuildLangFromCulture("en-US"),
        };

        private const string DefaultLanguage = "zh-CN";

        static Localization()
        {
            LocalizationBase.InitLocalization(strings.ResourceManager, SupportedLanguages, DefaultLanguage);
        }


        public static void ConfigLocalization(string code)
        {
            strings.Culture = CultureInfo.GetCultureInfo(code);
            LocalizationBase.ConfigLocalization(code);
        }
    }
}
