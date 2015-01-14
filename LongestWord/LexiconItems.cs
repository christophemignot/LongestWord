namespace LongestWord
{
    using System.Collections.Generic;

    public class LexiconItems
    {
        public char Letter;
        public ICollection<string> Words = new List<string>();
        public Dictionary<char, LexiconItems> LongerWords = new Dictionary<char, LexiconItems>();
    }
}
