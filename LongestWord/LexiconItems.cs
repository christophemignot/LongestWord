namespace LongestWord
{
    using System.Collections.Generic;

    public class LexiconItems
    {
        public ICollection<string> Words = new List<string>();
        public IDictionary<char, LexiconItems> LongerWords = new Dictionary<char, LexiconItems>();
    }
}
