namespace LongestWord
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net.Sockets;

    public class Lexicon
    {
        private readonly LexiconItems items;

        private char[] avaliableLetters =
        {'A',
    'B',
    'C',
    'D',
    'E',
    'F',
    'G',
    'H',
    'I',
    'J',
    'K',
    'L',
    'M',
    'N',
    'O',
    'P',
    'Q',
    'R',
    'S',
    'T',
    'U',
    'V',
    'W',
    'X',
    'Y',
    'Z'};

    public Lexicon(IEnumerable<string> words)
        {
            items = new LexiconItems();
            //Fill inner structure to easily find result
            foreach (var word in words)
            {
                AddWord(word);
            }
        }

        private void AddWord(string word)
        {
            char[] letters = word.ToCharArray();
            Array.Sort(letters);
            LexiconItems currentItem = items;
            int lettersCount = letters.Length;
            for (int index = 0; index < lettersCount; index++)
            {
                if (!currentItem.LongerWords.ContainsKey(letters[index]))
                {
                    currentItem.LongerWords.Add(letters[index], new LexiconItems());
                }
                currentItem = currentItem.LongerWords[letters[index]];
            }
            currentItem.Words.Add(word);
        }

        public IEnumerable<string> GetLongestWord(string letters)
        {
            if (!letters.Contains("#"))
            {
                return GetLongestWord(letters.ToCharArray());
            }
            return GetLongestWordWithHash(letters);
        }

        private IEnumerable<string> GetLongestWordWithHash(string letters)
        {
            var result = new List<string>();
            foreach (var avaliableLetter in avaliableLetters)
            {
                char[] allLetters = letters.ToCharArray();
                allLetters[letters.IndexOf('#')] = avaliableLetter;
                if (allLetters.Contains('#'))
                {
                    result.AddRange(GetLongestWordWithHash(new string(allLetters)));
                }
                else
                {
                    result.AddRange(GetLongestWord(allLetters));
                }
            }
            var maxLength = result.Max(s => s.Length);
            return result
                .Where(chaine => chaine.Length == maxLength)
                .Distinct()
                .ToList();
            
        }

        private IEnumerable<string> GetLongestWord(char[] letters)
        {
            Array.Sort(letters);
            LexiconItems currentItem = items;
            int lettersCount = letters.Length;
            for (int index = 0; index < lettersCount; index++)
            {
                if (!currentItem.LongerWords.ContainsKey(letters[index]))
                {
                    return currentItem.Words;
                }
                currentItem = currentItem.LongerWords[letters[index]];
            }
            return currentItem.Words;
        }

    }
}
