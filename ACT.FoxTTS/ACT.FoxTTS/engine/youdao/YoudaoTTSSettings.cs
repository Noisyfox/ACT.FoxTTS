using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.youdao
{
    public class YoudaoTTSSettings
    {
        [XmlElement]
        public string AppId = "";

        [XmlElement]
        public string AppSecret = "";

        [XmlElement]
        public int Speed = 10;

        [XmlElement]
        public int Volume = 10;

        public override string ToString()
        {
            return $"{nameof(AppId)}: {AppId}, {nameof(AppSecret)}: {AppSecret}, {nameof(Speed)}: {Speed}, {nameof(Volume)}: {Volume}";
        }
    }
}
