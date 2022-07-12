namespace ACT.FoxTTS.engine.aliyun
{
    internal class AliyunVoice : Voice
    {
        public string[] Emotions { get; }

        public AliyunVoice(string value, string displayName) : base(value, displayName)
        {
            Emotions = null;
        }

        public AliyunVoice(string value, string displayName, string[] emotions) : base(value, displayName)
        {
            Emotions = emotions;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Emotions)}: {Emotions}";
        }

        public static readonly string EmotionNone = "none";
    }
}
