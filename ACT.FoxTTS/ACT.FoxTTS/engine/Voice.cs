namespace ACT.FoxTTS.engine
{
    internal class Voice
    {
        public string Value { get; }

        public string DisplayName { get; }

        public Voice(string value, string displayName)
        {
            Value = value;
            DisplayName = displayName;
        }

        public override string ToString()
        {
            return $"{nameof(Value)}: {Value}, {nameof(DisplayName)}: {DisplayName}";
        }
    }
}