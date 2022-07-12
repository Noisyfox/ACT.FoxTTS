using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Numerics;
using System.Text;
using ACT.FoxCommon.logging;

namespace ACT.FoxTTS
{
    static class Utils
    {
        public static string GetString<K, V>(this Dictionary<K, V> d)
        {
            var sb = new StringBuilder();
            foreach (var pair in d)
            {
                sb.Append($"{pair.Key}={pair.Value},");
            }

            return sb.ToString();
        }

        private const string Alphabet = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";

        public static string ToBase36String(this byte[] toConvert, bool bigEndian = false)
        {
            if (bigEndian) Array.Reverse(toConvert); // !BitConverter.IsLittleEndian might be an alternative
            BigInteger dividend = new BigInteger(toConvert);
            var builder = new StringBuilder();
            while (dividend != 0)
            {
                BigInteger remainder;
                dividend = BigInteger.DivRem(dividend, 36, out remainder);
                builder.Insert(0, Alphabet[Math.Abs(((int)remainder))]);
            }
            return builder.ToString();
        }

        public static void Download(string url, string file)
        {
            var request = WebRequest.Create(url) as HttpWebRequest;
            request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.74 Safari/537.36 Edg/99.0.1150.55";

            using var response = request.GetResponse() as HttpWebResponse;
            if (response.StatusCode != HttpStatusCode.OK)
            {
                Logger.Error($"Unable to complete the request: {response}");
                return;
            }

            response.SaveToBinaryFile(file);
        }

        public static void SaveToBinaryFile(this WebResponse response, string filePath)
        {
            var buffer = new byte[1024];
            using var rs = response.GetResponseStream();
            using var fileStream = new FileStream(
                filePath,
                FileMode.OpenOrCreate,
                FileAccess.Write,
                FileShare.ReadWrite
            );

            while (true)
            {
                var count = rs.Read(buffer, 0, buffer.Length);
                if (count <= 0)
                {
                    break;
                }

                fileStream.Write(buffer, 0, count);
            }
        }

        public static HttpWebResponse GetHttpResponse(this HttpWebRequest request)
        {
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response ?? throw e;
            }

            return response;
        }
    }
}
