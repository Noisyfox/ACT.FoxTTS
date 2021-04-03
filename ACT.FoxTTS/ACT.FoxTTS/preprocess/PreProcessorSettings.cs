using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace ACT.FoxTTS.preprocess
{
    public class PreProcessorSettings
    {
        [XmlArray]
        public List<Rule> Rules = new List<Rule>();
    }
    
    public class Rule
    {
        [XmlAttribute]
        public bool Enabled = false;
        [XmlAttribute]
        public string SourcePattern = "";
        [XmlAttribute]
        public string Replacement = "";
        [XmlAttribute]
        public bool UseRegex = false;
    }
}
