namespace LongestWordConsole
{
    using System.Diagnostics;
    using System.IO;
    using LongestWord;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            IEnumerable<string> wordsLexicon = File.ReadLines("./Data/ListeMots.txt");
            var lexicon = new Lexicon(wordsLexicon);
            sw.Stop();
            Console.WriteLine("Dictionnaire chargé en " + sw.ElapsedMilliseconds + "ms"); 
            sw.Reset();
            sw.Start();
            var result = lexicon.GetLongestWord("ZYUU");
            sw.Stop();
            Console.WriteLine(result.Count() + " mots trouvé(s) en " + sw.ElapsedMilliseconds + "ms");
            sw.Reset();
            sw.Start();
            result = lexicon.GetLongestWord("T#I#STE");
            sw.Stop();
            Console.WriteLine(result.Count() + " mots trouvé(s) en " + sw.ElapsedMilliseconds+ "ms");
            Console.ReadLine();
        }
    }
}
