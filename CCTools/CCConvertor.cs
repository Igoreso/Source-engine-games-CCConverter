namespace CCTools
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using System.Text.RegularExpressions;

    internal class TextPair
    {
        public string EnglishText;
        public string LocalizedText;

        public TextPair(string englishText)
        {
            this.EnglishText = englishText;
            this.LocalizedText = null;
        }
    }

    public class CCConverterResult
    {
        public string GeneratedFilePath { get; internal set; }
    }

    public class CCConverter
    {
        public string PathToOldEnglishFile { get; set; }

        public string PathToOldLocalizedFile { get; set; }

        public string PathToNewEnglishFile { get; set; }

        public string OutputDirectory { get; set; }

        // UCS-2 Little Endian
        private static Encoding CCEncoding = Encoding.Unicode;

        // regex itself:
        // "([A-Za-z0-9\.\/' _-]+)"\s+"(.+)"
        // you need to escape all quotes and all slashes for it to be used in C# code.
        // use tools like https://www.debuggex.com/ to understand what's going on.
        // basically it finds pairs such as
        // "sounds/etc/sound_1.wav"     "any text, even with quotes"
        // when you do Match(), result's Groups is the following:
        // Groups[0] is whole match, i.e. pair;
        // Groups[1] is sound key;
        // Groups[2] is text
        private static Regex CCPairRegex = new Regex("\"([A-Za-z0-9\\.\\/' _-]+)\"\\s+\"(.+)\"");

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

        public CCConverterResult Generate()
        {
            if (!this.Validate())
            {
                throw new Exception("Not all paths are valid.");
            }
            
            var oldEnglishLines = File.ReadAllLines(PathToOldEnglishFile, CCEncoding);
            var oldLocalizedLines = File.ReadAllLines(PathToOldLocalizedFile, CCEncoding);

            // key is sound name, value is pair of:
            // english text from old file + localized text from old localized file
            var keyToTextPairDict = new Dictionary<string, TextPair>(oldEnglishLines.Length);

            // store english pairs
            foreach (var line in oldEnglishLines)
            {
                var match = CCPairRegex.Match(line);
                if (match.Groups.Count == 3)
                {
                    var key = match.Groups[1].Value;
                    var englishText = match.Groups[2].Value;
                    
                    // duplicate key! nothing I can do, that's the problem in the file.
                    // example: in old CCs there were 3 lines for grd01_postlobbygoodbye01.wav.
                    if (keyToTextPairDict.ContainsKey(key))
                    {
                        continue;
                    }

                    keyToTextPairDict.Add(key, new TextPair(englishText));
                }
            }

            // find appropriate localized text
            foreach (var line in oldLocalizedLines)
            {
                var match = CCPairRegex.Match(line);
                if (match.Groups.Count == 3)
                {                   
                    var key = match.Groups[1].Value;

                    // localized files are supposed to have the same lines as original.
                    // if there is new line in localized file - something is wrong.
                    // example: in old CCs there were 3 lines for grd01_postlobbygoodbye01.wav.
                    // you have to fix it manually - it cannot be determined easily from C# code.
                    if (!keyToTextPairDict.ContainsKey(key))
                    {
                        continue;
                    }

                    var pair = keyToTextPairDict[key];
                    pair.LocalizedText = match.Groups[2].Value;
                }
            }

            // key is english text from old file, value is localized text from old localized file
            var localizationDict = new Dictionary<string, string>(keyToTextPairDict.Values.Count);

            foreach (var pair in keyToTextPairDict.Values)
            {
                var key = pair.EnglishText;
                var value = pair.LocalizedText;

                // some text lines may repeat. I cannot easily determite from C# code if 
                // someone localized those lines differently (for the sake of better localization),
                // so I suppose localized versions are same.
                if (localizationDict.ContainsKey(key))
                {
                    continue;
                }

                localizationDict.Add(key, value);
            }

            var newEnglishLines = File.ReadAllLines(PathToNewEnglishFile, CCEncoding);
            var newLocalizedLines = new List<string>();
            
            // generate new localized lines
            foreach (var line in newEnglishLines)
            {
                var newLine = line;

                var match = CCPairRegex.Match(line);
                if (match.Groups.Count == 3)
                {
                    var englishText = match.Groups[2].Value;

                    if (localizationDict.ContainsKey(englishText))
                    {
                        var localizedText = localizationDict[englishText];                        
                        if (localizedText != null)
                        {
                            newLine = line.Replace(englishText, localizedText);
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
                    newLine = newLine ?? line + " // ***";
                }

                newLocalizedLines.Add(newLine);
            }
                        
            var outputPath = this.GetGeneratedFilePath();
            File.WriteAllLines(outputPath, newLocalizedLines, CCEncoding);

            var result = new CCConverterResult { GeneratedFilePath = outputPath };
            return result;
        }

        private string GetGeneratedFilePath()
        {
            var ext = Path.GetExtension(PathToNewEnglishFile);
            var name = "generated_" + DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm-ss-ffff") + ext;
            var outputPath = Path.Combine(OutputDirectory, name);
            return outputPath;
        }
    }
}
