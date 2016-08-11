namespace CCTools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;

    public class CcConverter
    {
        public string PathToOldEnglishFile { get; set; }

        public string PathToOldLocalizedFile { get; set; }

        public string PathToNewEnglishFile { get; set; }

        public string OutputDirectory { get; set; }

        public string NewLineMarker { get; set; }

        public bool IgnoreCase { get; set; }

        // UCS-2 Little Endian
        private static readonly Encoding CcEncoding = Encoding.Unicode;

        public bool Validate()
        {
            return
                !string.IsNullOrEmpty(PathToOldEnglishFile) &&
                !string.IsNullOrEmpty(PathToOldLocalizedFile) &&
                !string.IsNullOrEmpty(PathToNewEnglishFile) &&
                !string.IsNullOrEmpty(OutputDirectory) &&
                File.Exists(PathToOldEnglishFile) &&
                File.Exists(PathToOldLocalizedFile) &&
                File.Exists(PathToNewEnglishFile) &&
                Directory.Exists(OutputDirectory);
        }

        public CcConverterResult Generate()
        {
            if (!Validate())
            {
                throw new Exception("Not all paths are valid.");
            }

            var newLineMarker =
                string.IsNullOrWhiteSpace(NewLineMarker)
                    ? "// ###"
                    : NewLineMarker;

            // lines that are borken due to a mistake in the old version
            var brokenLines = new List<string>();

            var oldEnglishLines = File.ReadAllLines(PathToOldEnglishFile, CcEncoding);
            var oldLocalizedLines = File.ReadAllLines(PathToOldLocalizedFile, CcEncoding);

            // key is files's key (sound name or smth else),
            // value is pair of:
            // english text from old file + localized text from old localized file
            var keyToTextPairDict = new Dictionary<string, TextPair>(oldEnglishLines.Length);

            // associate keys with values (english lines)
            foreach (var line in oldEnglishLines)
            {
                var ccRecord = new CcRecord(line);
                if (ccRecord.IsValid)
                {
                    var key = ccRecord.Key;
                    var englishText = ccRecord.Value;
                    
                    // duplicate key! nothing I can do, that's the problem in the file.
                    // example: in old CCs there were 3 lines for grd01_postlobbygoodbye01.wav.
                    if (keyToTextPairDict.ContainsKey(key))
                    {
                        continue;
                    }

                    keyToTextPairDict.Add(key, new TextPair(englishText));
                }
            }

            // find appropriate localized text for keys.
            // keys should be exactly same, otherwise someone did a bad job.
            foreach (var line in oldLocalizedLines)
            {
                var ccRecord = new CcRecord(line);
                if (ccRecord.IsValid)
                {
                    var key = ccRecord.Key;

                    // localized files are supposed to have the same lines as original.
                    // if there is new line in localized file - something is wrong.
                    // example: in old CCs there were 3 lines for grd01_postlobbygoodbye01.wav.
                    // you have to fix it manually - it cannot be determined easily from C# code.
                    if (!keyToTextPairDict.ContainsKey(key))
                    {
                        continue;
                    }

                    var pair = keyToTextPairDict[key];
                    pair.LocalizedText = ccRecord.Value;
                }
            }

            // key is english text from old file, value is localized text from old localized file
            var localizationDict = new Dictionary<string, string>(keyToTextPairDict.Values.Count);

            // associate old english lines with old localized lines
            foreach (var pair in keyToTextPairDict.Values)
            {
                var key = pair.EnglishText;
                var value = pair.LocalizedText;

                if (IgnoreCase)
                {
                    key = key.ToLowerInvariant();
                }

                // some text lines may repeat. I cannot easily determite from C# code if 
                // someone localized those lines differently (for the sake of better localization),
                // so I suppose localized versions are same.
                if (localizationDict.ContainsKey(key))
                {
                    continue;
                }

                localizationDict.Add(key, value);
            }

            var newEnglishLines = File.ReadAllLines(PathToNewEnglishFile, CcEncoding);
            var newLocalizedLines = new List<string>();
            
            // generate new localized lines
            foreach (var line in newEnglishLines)
            {
                var newLine = line;

                var ccRecord = new CcRecord(line);
                if (ccRecord.IsValid)
                {
                    var englishText = ccRecord.Value;
                    var key = englishText;

                    if (IgnoreCase)
                    {
                        key = key.ToLowerInvariant();
                    }

                    if (localizationDict.ContainsKey(key))
                    {
                        var localizedText = localizationDict[key];                        
                        if (localizedText != null)
                        {
                            // old method - also replaces in value, which is a bug
                            //newLine = line.Replace(englishText, localizedText);

                            if (ccRecord.Key.Contains(ccRecord.Value))
                            {
                                brokenLines.Add(ccRecord.Key);
                            }

                            newLine = ccRecord.ReplaceValueWith(localizedText);
                        }                        
                        else
                        {
                            // this line WAS in old english file, but was LOST in localized file
                            newLine = null;
                        }                        
                    }
                    else
                    {
                        // this line was NOT in old english file
                        newLine = null;
                    }

                    // append comment to make it easy to find new lines
                    newLine = newLine ?? line + " " + newLineMarker;
                }

                newLocalizedLines.Add(newLine);
            }
                        
            var outputPath = GetGeneratedFilePath();
            File.WriteAllLines(outputPath, newLocalizedLines, CcEncoding);

            var result = new CcConverterResult
            {
                GeneratedFilePath = outputPath,
                BrokenLines = brokenLines
            };

            return result;
        }

        private string GetGeneratedFilePath()
        {
            var fileName = Path.GetFileName(PathToOldLocalizedFile);
            var ext = Path.GetExtension(PathToOldLocalizedFile);
            var name = string.Format("{0}_generated_{1}{2}", fileName, DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-ffff"), ext);
            var outputPath = Path.Combine(OutputDirectory, name);
            return outputPath;
        }
    }
}
