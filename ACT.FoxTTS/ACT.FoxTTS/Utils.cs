using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

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
    }
}
