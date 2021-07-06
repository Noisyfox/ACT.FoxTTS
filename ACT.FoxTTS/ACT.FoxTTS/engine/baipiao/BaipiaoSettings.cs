using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.baipiao
{
    public class BaipiaoSettings
    {
        [XmlElement]
        public int Speed = 4;

        [XmlElement]
        public bool Accept = false;


        public override string ToString() =>
            $"{nameof(this.Speed)}:{this.Speed}";
    }
}
