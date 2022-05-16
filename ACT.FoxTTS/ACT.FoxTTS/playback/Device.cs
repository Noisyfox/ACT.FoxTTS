namespace ACT.FoxTTS.playback
{
    public class Device
    {
        public string Name { get; set; }

        public string ID { get; set; }

        public override string ToString() => Name;
    }
}
