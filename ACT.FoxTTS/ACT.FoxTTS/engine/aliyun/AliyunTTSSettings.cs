using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.aliyun
{
    public class AliyunTTSSettings
    {
        [XmlElement]
        public string AccessKeyId = "";

        [XmlElement]
        public string AccessKeySecret = "";

        [XmlElement]
        public string AppId = "";

        [XmlElement]
        public int Speed = 0;

        [XmlElement]
        public int Pitch = 0;

        [XmlElement]
        public int Volume = 50;

        [XmlElement]
        public string Voice = "";

        [XmlElement]
        public string CustomizedVoice = "";

        [XmlElement]
        public string EmotionCategory = "";

        [XmlElement]
        public int EmotionIntensity = 0;

        [XmlElement]
        public string Effect = "";

        public override string ToString()
        {
            return $"{nameof(Speed)}: {Speed}, {nameof(Pitch)}: {Pitch}, {nameof(Volume)}: {Volume}, {nameof(Voice)}: {Voice}, {nameof(CustomizedVoice)}: {CustomizedVoice}, {nameof(EmotionCategory)}: {EmotionCategory}, {nameof(EmotionIntensity)}: {EmotionIntensity}, {nameof(Effect)}: {Effect}";
        }
    }
}
