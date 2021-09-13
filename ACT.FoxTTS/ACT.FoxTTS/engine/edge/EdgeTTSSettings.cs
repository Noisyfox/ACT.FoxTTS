using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.edge
{
    public class EdgeTTSSettings
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
        public bool Accept = false;

        public override string ToString()
        {
            return $"{nameof(Speed)}: {Speed}, {nameof(Pitch)}: {Pitch}, {nameof(Volume)}: {Volume}, {nameof(Voice)}: {Voice}";
        }
    }
}
