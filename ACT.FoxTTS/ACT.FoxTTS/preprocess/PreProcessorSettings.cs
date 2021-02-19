using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACT.FoxTTS.preprocess
{
    public class PreProcessorSettings
    {
        public List<Rule> Rules = new List<Rule>();
    }

    public class Rule
    {
        public bool Enabled;
        public string SourcePattern;
        public string Replacement;
        public bool UseRegex;
    }
}
