namespace LongestWordTest
{
    using System.IO;
    using System.Linq;
    using LongestWord;
    using System.Collections.Generic;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class LexiconTest
    {
        private Lexicon lexicon;

        [TestInitialize]
        public void InitializeLexicon()
        {
            IEnumerable<string> wordsLexicon = File.ReadLines("./Data/ListeMots.txt");
            lexicon = new Lexicon(wordsLexicon);
        }

        [TestMethod]
        public void WhenInitializedThenLexiconFilled()
        {
            Assert.IsNotNull(lexicon);
        }

        [TestMethod]
        public void WhenSatabFindFourResults()
        {
            var result = lexicon.GetLongestWord("SATAB");
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void WhenSatabzFindFourResults()
        {
            var result = lexicon.GetLongestWord("SATABZ");
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [TestMethod]
        public void WhenTocaabsFindThreeResults()
        {
            var result = lexicon.GetLongestWord("TOCAABS").ToList();
            Assert.IsTrue(result.Count() == 3, "");
            Assert.IsTrue(result.Any(m => m == "TABASCO"), "TABASCO n'a pas été trouvé");
            Assert.IsTrue(result.Any(m => m == "CABOTAS"), "CABOTAS n'a pas été trouvé");
            Assert.IsTrue(result.Any(m => m == "ABACOST"), "ABACOST n'a pas été trouvé");
        }

        [TestMethod]
        public void WhenAHashFindTwoResults()
        {
            var result = lexicon.GetLongestWord("TU#U");
            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public void WhenTwoHashFindHundredAndEightyEightResults()
        {
            var result = lexicon.GetLongestWord("T#I#STE");
            Assert.IsNotNull(result);
            Assert.AreEqual(139, result.Count());
        }


    }
}
