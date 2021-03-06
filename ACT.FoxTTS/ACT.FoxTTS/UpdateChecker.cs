﻿using System.Text.RegularExpressions;
using ACT.FoxCommon.update;

namespace ACT.FoxTTS
{
    public class UpdateChecker : UpdateCheckerBase<MainController, FoxTTSPlugin>
    {
        public const string ReleasePage = "https://github.com/Noisyfox/ACT.FoxTTS/releases";

        protected override string UpdateUrl { get; } = "https://api.github.com/repos/Noisyfox/ACT.FoxTTS/releases";

        private const string NameMatcher =
            @"^ACT\.FoxTTS(?:-|\.)(?<version>\d+(?:\.\d+)*)(?:|-Release)\.7z$";

        protected override string ParseVersion(string fileName)
        {
            var match = Regex.Match(fileName, NameMatcher);
            if (match.Success)
            {
                return match.Groups["version"].Value;
            }

            return null;
        }
    }
}
