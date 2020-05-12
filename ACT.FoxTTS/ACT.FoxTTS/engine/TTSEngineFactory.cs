
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACT.FoxCommon.localization;
using ACT.FoxTTS.engine.baidu;
using ACT.FoxTTS.engine.sapi5;
using ACT.FoxTTS.localization;

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
        public static TTSEngineDef[] Engines =
        {
            new TTSEngineDef("ttsEngineSAPI5"),
            new TTSEngineDef("ttsEngineBaidu"),
        };

        public static ITTSEngine CreateEngine(string engine)
        {
            switch (engine)
            {
                case "ttsEngineSAPI5":
                    return new SAPI5Engine();
                case "ttsEngineBaidu":
                default:
                    return new BaiduTTSEngine();
            }
        }
    }
}
