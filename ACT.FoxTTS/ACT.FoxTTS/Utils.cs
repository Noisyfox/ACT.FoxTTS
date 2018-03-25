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

        private static readonly char[] InvalidCars = Path.GetInvalidFileNameChars();

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
            var cacheName = $"{engine.Name}.{tts}.{hashTTS}{hashParam}.{ext}";

            // ファイル名に使用できない文字を除去する
            cacheName = string.Concat(cacheName.Where(c => !InvalidCars.Contains(c)));

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
    }
}
