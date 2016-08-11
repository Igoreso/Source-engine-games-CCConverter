namespace CCTools
{
    using System.Collections.Generic;

    public class CcConverterResult
    {
        public string GeneratedFilePath { get; internal set; }

        public ICollection<string> BrokenLines { get; internal set; }
    }
}