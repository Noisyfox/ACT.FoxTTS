using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using ACT.FoxCommon.logging;
using ACT.FoxTTS.engine;
using Advanced_Combat_Tracker;

namespace ACT.FoxTTS
{
    public class FileCache
    {
        public static string CacheDirectory =>
            Path.Combine(ActGlobals.oFormActMain.AppDataFolder.FullName, "FoxTTS\\cache");

        private static readonly char[] InvalidChars = Path.GetInvalidFileNameChars();

        public string GetOrCreateFile(
            ITTSEngine engine,
            string tts,
            string ext,
            string parameter,
            Action<string> fileCreator)
        {
            // TODO: per-file lock?
            lock (this)
            {
                var newCacheFile = GetCacheFileNameNew(engine, tts, ext, parameter);
                if (File.Exists(newCacheFile))
                {
                    Logger.Debug("Cache hit.");
                    return newCacheFile;
                }

                var oldCacheFile = GetCacheFileNameOld(engine, tts, ext, parameter);
                if (File.Exists(oldCacheFile))
                {
                    // Rename old cache file to new file name
                    Logger.Debug("Old cache hit. Rename to new cache name.");
                    File.Move(oldCacheFile, newCacheFile);
                    return newCacheFile;
                }

                // Create the file
                if (!Directory.Exists(CacheDirectory))
                {
                    Directory.CreateDirectory(CacheDirectory);
                }
                Logger.Debug("Cache missing, creating...");
                fileCreator(newCacheFile);

                return newCacheFile;
            }
        }

        /// <summary>
        /// Limit the length of the string.
        /// If string is truncated, then a 'HORIZONTAL ELLIPSIS(…)' will be added at the end of the string.
        /// </summary>
        public static string Truncate(string s, int maxLength)
        {
            if (s.Length <= maxLength)
            {
                return s;
            }

            return s.Substring(0, maxLength - 1) + '\u2026';
        }

        /// <summary>
        /// キャッシュファイル用の衝突しない名前を生成する
        /// </summary>
        /// <param name="ctrl"></param>
        /// <param name="ttsType"></param>
        /// <param name="tts"></param>
        /// <param name="parameter"></param>
        /// <returns>
        /// キャッシュファイル名</returns>
        private static string GetCacheFileNameOld(
            ITTSEngine engine,
            string tts,
            string ext,
            string parameter)
        {
            tts = tts.Replace(Environment.NewLine, "+");
            var hashTTS = tts.GetHashCode().ToString("X4");
            var hashParam = parameter.GetHashCode().ToString("X4");
            var cacheName = $"{engine.Name}.{Truncate(tts, 50)}.{hashTTS}{hashParam}.{ext}";

            // ファイル名に使用できない文字を除去する
            cacheName = string.Concat(cacheName.Where(c => !InvalidChars.Contains(c)));

            var fileName = Path.Combine(
                CacheDirectory,
                cacheName);

            return fileName;
        }

        private static string Hash(string stringToHash)
        {
            using (var sha1 = new SHA1Managed())
            {
                var hashBytes = sha1.ComputeHash(Encoding.UTF8.GetBytes(stringToHash));
                return hashBytes.ToBase36String();
            }
        }

        private static string GetCacheFileNameNew(
            ITTSEngine engine,
            string tts,
            string ext,
            string parameter)
        {
            // 10 digits sha-1 hash in base36
            var hash = Hash($"{engine.Name}.{tts}.{parameter}").Substring(0, 10);

            var cacheName = $"{hash}.{ext}";

            var fileName = Path.Combine(
                CacheDirectory,
                cacheName);

            return fileName;
        }
    }
}
