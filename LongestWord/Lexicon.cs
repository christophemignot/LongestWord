namespace LongestWord
{
    using System;
    using System.Collections.Generic;

    public class Lexicon
    {
        private readonly LexiconItems items;

        public Lexicon(IEnumerable<string> words)
        {
            items = new LexiconItems();
            //Fill inner structure to easily find result
            foreach (var word in words)
            {
                char[] letters = word.ToCharArray();
                Array.Sort(letters);
                LexiconItems currentItem = items;
                foreach (char letter in letters)
                {
                    if (!currentItem.LongerWords.ContainsKey(letter))
                    {
                        currentItem.LongerWords.Add(letter, new LexiconItems());
                    }
                    currentItem = currentItem.LongerWords[letter];
                }
                currentItem.Words.Add(word);
            }
        }

        public IEnumerable<string> GetLongestWord(string letters)
        {
            return GetLongestWord(letters.ToCharArray());
        }

        public IEnumerable<string> GetLongestWord(char[] letters)
        {
            Array.Sort(letters);
            LexiconItems currentItem = items;
            foreach (char letter in letters)
            {
                if (!currentItem.LongerWords.ContainsKey(letter))
                {
                    return currentItem.Words;
                }
                currentItem = currentItem.LongerWords[letter];
            }
            return currentItem.Words;
        }

    }
}
