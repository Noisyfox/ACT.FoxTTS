using ACT.FoxCommon.localization;
using ACT.FoxTTS.engine.baidu;
using ACT.FoxTTS.engine.baipiao;
using ACT.FoxTTS.engine.edge;
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
        public static readonly TTSEngineDef EngineEdge = new TTSEngineDef("ttsEngineEdge");
        public static readonly TTSEngineDef EngineBaidu = new TTSEngineDef("ttsEngineBaidu");

        public static readonly TTSEngineDef[] Engines =
        {
            EngineEdge,
            EngineBaidu,
            new TTSEngineDef("ttsEngineSAPI5"),
            new TTSEngineDef("ttsEngineBaipiao"),
        };

        public static ITTSEngine CreateEngine(string engine)
        {
            switch (engine)
            {
                // case "ttsEngineCafe":
                    // return new CafeTTSEngine();
                case "ttsEngineSAPI5":
                    return new SAPI5Engine();
                case "ttsEngineBaipiao":
                    return new BaipiaoEngine();
                case "ttsEngineBaidu":
                    return new BaiduTTSEngine();
                case "ttsEngineEdge":
                default:
                    return new EdgeTTSEngine();
            }
        }
    }
}
