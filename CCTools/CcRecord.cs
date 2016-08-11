using System;

namespace CCTools
{
    using System.Text.RegularExpressions;

    public struct CcRecord
    {
        // regex itself:
        // "([A-Za-z0-9\.\/' _-]+)"\s+"(.+)"
        // you need to escape all quotes and all slashes for it to be used in C# code.
        // use tools like https://www.debuggex.com/ to understand what's going on.
        // basically it finds pairs such as
        // "sounds/etc/sound_1.wav"     "any text, even with escaped quotes \"\" inside"
        // when you do Match(), result's Groups is the following:
        // Groups[0] is whole match, i.e. pair;
        // Groups[1] is sound key;
        // Groups[2] is text
        private static readonly Regex CcPairRegex = new Regex("\"([A-Za-z0-9\\.\\/' _-]+)\"\\s+\"(.+)\"");
        private const int ValueGroupIndex = 2;

        private readonly string _originalLine;
        private readonly Match _regexMatch;

        public CcRecord(string line)
        {
            _originalLine = line;
            _regexMatch = CcPairRegex.Match(line);
        }

        public string ReplaceValueWith(string newValue)
        {
            if (!IsValid)
            {
                throw new InvalidOperationException("Line is not valid CC record");
            }

            var valuePosition = _regexMatch.Groups[ValueGroupIndex].Index;

            var partBeforeValue = _originalLine.Substring(0, valuePosition);
            var partAfterValue = _originalLine.Substring(valuePosition);

            partAfterValue = partAfterValue.Replace(Value, newValue);

            var newLine = partBeforeValue + partAfterValue;
            return newLine;
        }

        public bool IsValid
        {
            get { return _regexMatch.Groups.Count == 3; }
        }

        public string Key
        {
            get { return _regexMatch.Groups[1].Value; }
        }

        public string Value
        {
            get { return _regexMatch.Groups[ValueGroupIndex].Value; }
        }
    }
}