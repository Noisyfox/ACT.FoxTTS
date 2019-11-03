using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACT.FoxTTS.engine;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS
{
    static class Utils
    {
        public static string CacheDirectory =>
            Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "FoxTTS\\cache");

        private static readonly char[] InvalidChars = Path.GetInvalidFileNameChars();

        /// <summary>
        /// キャッシュファイル用の衝突しない名前を生成する
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="ttsType"></param>
        /// <param name="tts"></param>
        /// <param name="parameter"></param>
        /// <returns>
        /// キャッシュファイル名</returns>
        public static string GetCacheFileName(
            this ITTSEngine engine,
            string tts,
            string ext,
            string parameter)
        {
            var hashTTS = tts.GetHashCode().ToString("X4");
            var hashParam = parameter.GetHashCode().ToString("X4");
            var cacheName = $"{engine.Name}.{tts.Truncate(50)}.{hashTTS}{hashParam}.{ext}";

            // ファイル名に使用できない文字を除去する
            cacheName = string.Concat(cacheName.Where(c => !InvalidChars.Contains(c)));

            var fileName = Path.Combine(
                CacheDirectory,
                cacheName);

            if (!Directory.Exists(Path.GetDirectoryName(fileName)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(fileName));
            }

            return fileName;
        }

        public static string GetString<K, V>(this Dictionary<K, V> d)
        {
            var sb = new StringBuilder();
            foreach (var pair in d)
            {
                sb.Append($"{pair.Key}={pair.Value},");
            }

            return sb.ToString();
        }

        /// <summary>
        /// Limit the length of the string.
        /// If string is truncated, then a 'HORIZONTAL ELLIPSIS(…)' will be added at the end of the string.
        /// </summary>
        public static string Truncate(this string s, int maxLength)
        {
            if (s.Length <= maxLength)
            {
                return s;
            }

            return s.Substring(0, maxLength - 1) + '\u2026';
        }
    }
}
