using ACT.FoxCommon.localization;
using ACT.FoxTTS.engine.aliyun;
using ACT.FoxTTS.engine.azure;
using ACT.FoxTTS.engine.baidu;
using ACT.FoxTTS.engine.baipiao;
using ACT.FoxTTS.engine.cafe;
using ACT.FoxTTS.engine.cafepro;
using ACT.FoxTTS.engine.edge;
using ACT.FoxTTS.engine.google_unofficial;
using ACT.FoxTTS.engine.sapi5;
using ACT.FoxTTS.engine.xfyun;
using ACT.FoxTTS.engine.youdao;

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
        private static readonly TTSEngineDef EngineEdge = new TTSEngineDef("ttsEngineEdge");
        private static readonly TTSEngineDef EngineCafe = new TTSEngineDef("ttsEngineCafe");
        public static readonly TTSEngineDef EngineBaidu = new TTSEngineDef("ttsEngineBaidu");
        public static readonly TTSEngineDef Default = EngineCafe;

        public static readonly TTSEngineDef[] Engines =
        {
            EngineCafe,
            new TTSEngineDef("ttsEngineCafePro"),
            EngineBaidu,
            new TTSEngineDef("ttsEngineYoudao"),
            new TTSEngineDef("ttsEngineXfyun"),
            new TTSEngineDef("ttsEngineAliyun"),
            new TTSEngineDef("ttsEngineAzure"),
            new TTSEngineDef("ttsEngineSAPI5"),
            EngineEdge,
            new TTSEngineDef("ttsEngineBaipiao"),
            new TTSEngineDef("ttsEngineGoogleUnofficial"),
        };

        public static ITTSEngine CreateEngine(string engine)
        {
            switch (engine)
            {
                case "ttsEngineSAPI5":
                    return new SAPI5Engine();
                case "ttsEngineBaipiao":
                    return new BaipiaoEngine();
                case "ttsEngineBaidu":
                    return new BaiduTTSEngine();
                case "ttsEngineYoudao":
                    return new YoudaoTTSEngine();
                case "ttsEngineXfyun":
                    return new XfyunTTSEngine();
                case "ttsEngineAzure":
                    return new AzureTTSEngine();
                case "ttsEngineEdge":
                    return new EdgeTTSEngine();
                case "ttsEngineGoogleUnofficial":
                    return new GoogleUnofficialTTSEngine();
                case "ttsEngineCafePro":
                    return new CafeProTTSEngine();
                case "ttsEngineAliyun":
                    return new AliyunTTSEngine();
                case "ttsEngineCafe":
                default:
                    return new CafeTTSEngine();
            }
        }
    }
}
