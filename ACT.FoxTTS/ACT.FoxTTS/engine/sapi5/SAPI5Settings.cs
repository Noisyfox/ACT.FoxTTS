using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.sapi5
{
    public enum Pitches
    {
        Default = 0,
        XLow = 1,
        Low = 2,
        Medium = 3,
        High = 4,
        XHigh = 5,
    }

    public class SAPI5Settings
    {
        [XmlElement]
        public string Voice = null;

        [XmlElement]
        public int Rate = 0;

        [XmlElement]
        public int Volume = 100;

        [XmlElement]
        public Pitches Pitch = Pitches.Default;

        public override string ToString() =>
            $"{nameof(this.Voice)}:{this.Voice}," +
            $"{nameof(this.Rate)}:{this.Rate}," +
            $"{nameof(this.Volume)}:{this.Volume}," +
            $"{nameof(this.Pitch)}:{this.Pitch}";
    }
}
