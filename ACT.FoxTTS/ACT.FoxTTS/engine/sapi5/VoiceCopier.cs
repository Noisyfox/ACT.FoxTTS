using System.Collections.Generic;
using Microsoft.Win32;

namespace ACT.FoxTTS.engine.sapi5
{

    /// <summary>
    /// Allow using UWP only TTS voices for all applications.
    ///
    /// inspired by https://gist.github.com/hiepxanh/8b6ad80f6d620cd3eaaaa5c1d2c660b2
    /// </summary>
    public static class VoiceCopier
    {
        private static List<KeyValuePair<string, string>> regKeys = new List<KeyValuePair<string, string>>(new []
        {
            new KeyValuePair<string, string>(@"software\Microsoft\Speech_OneCore\Voices\Tokens", @"software\Microsoft\Speech\Voices\Tokens"),
            new KeyValuePair<string, string>(@"software\WOW6432Node\Microsoft\Speech_OneCore\Voices\Tokens", @"software\WOW6432Node\Microsoft\Speech\Voices\Tokens"),
        });

        public static HashSet<string> CopyVoice()
        {
            var voices = new HashSet<string>();

            foreach (var kv in regKeys)
            {
                var src = kv.Key;
                var dst = kv.Value;

                var srcKey = Registry.LocalMachine.OpenSubKey(src);
                var dstKey = Registry.LocalMachine.OpenSubKey(dst, true);
                if (srcKey != null && dstKey != null)
                {
                    var v = CopyVoice(srcKey, dstKey);
                    voices.UnionWith(v);
                }
            }

            return voices;
        }

        private static HashSet<string> CopyVoice(RegistryKey sourceParentKey, RegistryKey destParentKey)
        {
            var voices = new HashSet<string>();

            foreach (var voiceId in sourceParentKey.GetSubKeyNames())
            {
                var name = CopyVoice(sourceParentKey, destParentKey, voiceId);
                voices.Add(name);
            }

            return voices;
        }

        private static string CopyVoice(RegistryKey sourceParentKey, RegistryKey destParentKey, string voiceId)
        {
            var src = sourceParentKey.OpenSubKey(voiceId);
            var dest = destParentKey.CreateSubKey(voiceId);

            RecurseCopyKey(src, dest);

            // Fix Kangkang
            if (voiceId.ToLower().Contains("kangkang"))
            {
                if (dest.GetValue("VoicePath") is string oldVal && oldVal.ToLower().EndsWith("yaoyao"))
                {
                    var newVal = oldVal.Substring(0, oldVal.Length - 6) + "Kangkang";
                    dest.SetValue("VoicePath", newVal, dest.GetValueKind("VoicePath"));
                }
            }

            // Return the name of the voice
            return dest.GetValue("") as string;
        }

        private static void RecurseCopyKey(RegistryKey sourceKey, RegistryKey destinationKey)
        {
            //copy all the values
            foreach (var valueName in sourceKey.GetValueNames())
            {
                var objValue = sourceKey.GetValue(valueName);
                var valKind = sourceKey.GetValueKind(valueName);
                destinationKey.SetValue(valueName, objValue, valKind);
            }

            //For Each subKey 
            //Create a new subKey in destinationKey 
            //Call myself 
            foreach (var sourceSubKeyName in sourceKey.GetSubKeyNames())
            {
                var sourceSubKey = sourceKey.OpenSubKey(sourceSubKeyName);
                var destSubKey = destinationKey.CreateSubKey(sourceSubKeyName);
                RecurseCopyKey(sourceSubKey, destSubKey);
            }
        }
    }
}
