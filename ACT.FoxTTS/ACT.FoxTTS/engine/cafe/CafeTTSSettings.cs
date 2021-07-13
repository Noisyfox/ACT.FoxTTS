using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.cafe
{
    public class CafeTTSSettings
    {
        [XmlElement]
        public string Voice = "";

        public override string ToString() =>
            $"{nameof(this.Voice)}:{this.Voice}";
    }
}
