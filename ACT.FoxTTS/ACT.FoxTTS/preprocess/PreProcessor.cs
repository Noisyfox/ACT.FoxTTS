using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace ACT.FoxTTS.preprocess
{
    public interface ITextProcessor
    {
        string Process(string input);
    }

    public class PreProcessor : IPluginComponent, ITextProcessor
    {
        private FoxTTSPlugin _plugin;
        private MainController _controller;

        private List<Rule> _pendingRules = new List<Rule>();
        private bool _dirty = true;

        private Context _currentContext = null;

        public void AttachToAct(FoxTTSPlugin plugin)
        {
            _plugin = plugin;
            _controller = plugin.Controller;

            _controller.PreProcessorSettingsChanged += _controller_PreProcessorSettingsChanged;
        }

        public void PostAttachToAct(FoxTTSPlugin plugin)
        {
        }

        private void _controller_PreProcessorSettingsChanged(bool fromView, PreProcessorSettings settings)
        {
            lock (this)
            {
                _dirty = true;
                _pendingRules = settings.Rules;
            }
        }

        private Context GetContext()
        {
            lock (this)
            {
                if (_dirty)
                {
                    _currentContext = new Context(_pendingRules);
                    _dirty = false;
                }

                return _currentContext;
            }
        }

        public string Process(string input)
        {
            return GetContext().Process(input);
        }

        private class Context: ITextProcessor
        {
            private class PlainReplacementProcessor: ITextProcessor
            {
                private readonly string _find;
                private readonly string _replacement;

                public PlainReplacementProcessor(string find, string replacement)
                {
                    _find = find;
                    _replacement = replacement;
                }

                public string Process(string input)
                {
                    return input.Replace(_find, _replacement);
                }
            }

            private class RegexReplacementProcessor : ITextProcessor
            {
                private readonly Regex _regex;
                private readonly string _replacement;
                public RegexReplacementProcessor(string pattern, string replacement)
                {
                    _regex = new Regex(pattern);
                    _replacement = replacement;
                }

                public string Process(string input)
                {
                    return _regex.Replace(input, _replacement);
                }
            }

            private readonly List<ITextProcessor> _compiledRules = new List<ITextProcessor>();

            public Context(List<Rule> rules)
            {
                foreach (var r in rules)
                {
                    if (r.Enabled)
                    {
                        if (r.UseRegex)
                        {
                            _compiledRules.Add(new RegexReplacementProcessor(r.SourcePattern, r.Replacement));
                        }
                        else
                        {
                            _compiledRules.Add(new PlainReplacementProcessor(r.SourcePattern, r.Replacement));
                        }
                    }
                }
            }

            public string Process(string input)
            {
                return _compiledRules.Aggregate(input, (current, p) => p.Process(current));
            }
        }
    }
}
