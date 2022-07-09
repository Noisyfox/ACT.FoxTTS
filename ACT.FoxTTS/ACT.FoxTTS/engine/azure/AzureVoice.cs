namespace ACT.FoxTTS.engine.azure
{
    internal class AzureVoice: Voice
    {

        public string[] Styles { get; }

        public bool SupportStyleDegree { get; }

        public string[] Roles { get; }

        public AzureVoice(string value, string displayName) : base(value, displayName)
        {
            Styles = null;
            SupportStyleDegree = false;
            Roles = null;
        }

        public AzureVoice(string value, string displayName, string[] styles) : base(value, displayName)
        {
            Styles = styles;
            SupportStyleDegree = false;
            Roles = null;
        }

        public AzureVoice(string value, string displayName, string[] styles, bool supportStyleDegree) : base(value, displayName)
        {
            Styles = styles;
            SupportStyleDegree = supportStyleDegree;
            Roles = null;
        }

        public AzureVoice(string value, string displayName, string[] styles, bool supportStyleDegree, string[] roles) : base(value, displayName)
        {
            Styles = styles;
            SupportStyleDegree = supportStyleDegree;
            Roles = roles;
        }

        public override string ToString()
        {
            return $"{base.ToString()}, {nameof(Styles)}: {Styles}, {nameof(SupportStyleDegree)}: {SupportStyleDegree}, {nameof(Roles)}: {Roles}";
        }

        public static readonly string StyleGeneral = "general";
        public static readonly string RoleDefault = "Default";
    }
}
