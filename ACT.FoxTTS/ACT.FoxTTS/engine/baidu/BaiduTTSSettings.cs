﻿using System.Xml.Serialization;

namespace ACT.FoxTTS.engine.baidu
{
    public class BaiduTTSSettings
    {
        [XmlElement]
        public string ApiKey = "";

        [XmlElement]
        public string SecretKey = "";

        [XmlElement]
        public int Speed = 5;

        [XmlElement]
        public int Pitch = 5;

        [XmlElement]
        public int Volume = 5;

        [XmlElement]
        public int Person = 0;

        [XmlElement]
        public bool UseHttps = false;

        [XmlIgnore]
        public bool WasUsingFreeKey = false;

        public void RemoveFreeKey()
        {
            if (ApiKey == "ALLgqCqouZ9GmIiFgafuyCsG")
            {
                ApiKey = "";
                SecretKey = "";
                WasUsingFreeKey = true;
            }
        }
    }
}
