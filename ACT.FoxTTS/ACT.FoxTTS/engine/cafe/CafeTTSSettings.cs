using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.cafe
{
    public class CafeTTSSettings
    {
        [XmlElement]
        public string Voice = "";

        [XmlElement]
        public int Rate = 0;

        public override string ToString() =>
            $"{nameof(this.Voice)}:{this.Voice}," +
            $"{nameof(this.Rate)}:{this.Rate}";
    }
}
