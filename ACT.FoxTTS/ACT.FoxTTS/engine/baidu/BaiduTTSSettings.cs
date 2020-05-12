using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.baidu
{
    public class BaiduTTSSettings
    {
        [XmlElement]
        public string ApiKey = "ALLgqCqouZ9GmIiFgafuyCsG";

        [XmlElement]
        public string SecretKey = "079d11c1b742b0031adc5872661fab81";

        [XmlElement]
        public int Speed = 5;

        [XmlElement]
        public int Pitch = 5;

        [XmlElement]
        public int Volume = 5;

        [XmlElement]
        public int Person = 0;

        [XmlElement]
        public bool UseHttps = false;
    }
}
