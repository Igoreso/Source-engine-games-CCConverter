namespace CCTools
{
    internal class TextPair
    {
        public string EnglishText { get; private set; }
        public string LocalizedText { get; set; }

        public TextPair(string englishText)
        {
            EnglishText = englishText;
            LocalizedText = null;
        }
    }
}