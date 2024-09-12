using NUnit.Framework;
using System.Linq;
using System;
using System.Collections.Generic;

namespace WordFinder.UnitTest
{
    public class UnitTests
    {
        private Application.WordFinder game;
        [SetUp]
        public void Setup()
        {
            string[] grid = { "sbsdhsdyqbutshay", "sujkswinjdgadgav", "kthisdiabsgavagt", "bajdcagdadbhashh", "udswwyniajwinafi", "tahidadbaduadkys", "jodnbutcsgtdsgas" };
            game = new Application.WordFinder(grid);
            
        }

        [Test]
        public void NoWordsFound()
        {
            var words = new[] { "car", "bike", "bus"};
            var result = game.Find(words);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void WordsFound()
        {
            var words = new[] { "this", "but", "then", "win" };
            var result = game.Find(words);
            Assert.AreEqual(3, result.Count());
        }

        [Test]
        public void EmptyGrid()
        {
            Assert.Throws<ArgumentException>(() =>
            {
                var game = new Application.WordFinder(new List<string>());
            });
        }

        [Test]
        public void WrongMatrixRowSize()
        {
            string[] matrix = new string[70];

            Assert.Throws<ArgumentException>(() =>
            {
                var game = new Application.WordFinder(matrix);
            });
        }

        [Test]
        public void WrongMatrixlengthSize()
        {
            string[] matrix = new string[50];
            matrix[0] = "ashdjghasjgasdjkhadjkshjadshjasdhjasdhjadshjaskdhasdjhasjdhasdjhasdhjk";

            Assert.Throws<ArgumentException>(() =>
            {
                var game = new Application.WordFinder(matrix);
            });
        }


        [Test]
        public void WrongMatrixDifferentLength()
        {
            var matrix = new List<string>();
            matrix.Add("ashdjghasjgasdjkhadjk");
            matrix.Add("asjdasjdk");

            Assert.Throws<ArgumentException>(() =>
            {
                var game = new Application.WordFinder(matrix);
            });
        }
    }
}