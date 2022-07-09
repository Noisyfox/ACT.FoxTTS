using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.cafepro
{
    public class CafeProTTSSettings
    {
        [XmlElement]
        public int Speed = 100;

        [XmlElement]
        public int Pitch = 100;

        [XmlElement]
        public int Volume = 50;

        [XmlElement]
        public string Voice = "";

        [XmlElement]
        public string Style = "";

        [XmlElement]
        public int StyleDegree = 100;

        [XmlElement]
        public string Role = "";

        public override string ToString()
        {
            return $"{nameof(Speed)}: {Speed}, {nameof(Pitch)}: {Pitch}, {nameof(Volume)}: {Volume}, {nameof(Voice)}: {Voice}, {nameof(Style)}: {Style}, {nameof(StyleDegree)}: {StyleDegree}, {nameof(Role)}: {Role}";
        }
    }
}
