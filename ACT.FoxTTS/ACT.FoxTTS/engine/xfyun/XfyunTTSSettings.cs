using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.xfyun
{
    public class XfyunTTSSettings
    {
        [XmlElement]
        public string AppId = "";

        [XmlElement]
        public string ApiKey = "";

        [XmlElement]
        public string ApiSecret = "";

        [XmlElement]
        public int Speed = 5;

        [XmlElement]
        public int Volume = 5;

        [XmlElement]
        public int Pitch = 5;

        [XmlElement]
        public string Voice = "";

        public override string ToString()
        {
            return //$"{nameof(AppId)}: {AppId}," +
                   //$"{nameof(ApiKey)}: {ApiKey}," +
                   //$"{nameof(ApiSecret)}: {ApiSecret}," +
                   $"{nameof(Speed)}: {Speed}," +
                   $"{nameof(Volume)}: {Volume}," +
                   $"{nameof(Pitch)}: {Pitch}," +
                   $"{nameof(Voice)}: {Voice}"
                   ;
        }
    }
}
