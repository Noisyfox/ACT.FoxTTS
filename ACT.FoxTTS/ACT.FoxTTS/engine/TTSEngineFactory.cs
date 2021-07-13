using ACT.FoxCommon.localization;
using ACT.FoxTTS.engine.baidu;
using ACT.FoxTTS.engine.baipiao;
using ACT.FoxTTS.engine.cafe;
using ACT.FoxTTS.engine.sapi5;

namespace ACT.FoxTTS.engine
{
    class TTSEngineDef
    {
        public string Name { get; }
        public string DisplayName => LocalizationBase.GetString(Name) ?? Name;

        public TTSEngineDef(string name)
        {
            Name = name;
        }
    }

    class TTSEngineFactory
    {
        public static readonly TTSEngineDef EngineCafe = new TTSEngineDef("ttsEngineCafe");
        public static readonly TTSEngineDef EngineBaidu = new TTSEngineDef("ttsEngineBaidu");

        public static readonly TTSEngineDef[] Engines =
        {
            EngineCafe,
            EngineBaidu,
            new TTSEngineDef("ttsEngineSAPI5"),
            new TTSEngineDef("ttsEngineBaipiao"),
        };

        public static ITTSEngine CreateEngine(string engine)
        {
            switch (engine)
            {
                case "ttsEngineCafe":
                    return new CafeTTSEngine();
                case "ttsEngineSAPI5":
                    return new SAPI5Engine();
                case "ttsEngineBaipiao":
                    return new BaipiaoEngine();
                case "ttsEngineBaidu":
                default:
                    return new BaiduTTSEngine();
            }
        }
    }
}
