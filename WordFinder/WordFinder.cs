namespace WordFinder.Application
{
    public class WordFinder : IWordFinder
    {
        private char[,] grid;

        public WordFinder(IEnumerable<string> matrix)
        {
            if(matrix.Count() == 0)
            {
                throw new ArgumentException("Error: Your grid is empty. Please enter a valid grid.");
            }

            if(matrix.Count() > 64 || matrix.Any(x => x.Length > 64))
            {
                throw new ArgumentException("Error: The matrix size exceed the 64 characters allowed.");
            }

            grid = new char[matrix.Count(), matrix.ElementAt(0).Length];

            for (int r = 0; r < matrix.Count(); r++)
            {
                if(r > 0 && matrix.ElementAt(r-1).Length != matrix.ElementAt(r).Length)
                {
                    throw new ArgumentException("Error: All lines must contain the same number of characters.");
                }

                char[] charArray = matrix.ElementAt(r).ToCharArray();
                for (int c = 0; c < charArray.Length; c++)
                {
                    grid[r, c] = charArray[c];
                }
            }

            Console.WriteLine("Characters grid file processed.");
        }


        public IEnumerable<string> Find(IEnumerable<string> wordstream)
        {
            if (wordstream.Count() == 0)
            {
                throw new ArgumentException("Error: No words found. Please enter at least one word.");
            }

            int rows = grid.GetLength(0);
            int columns = grid.GetLength(1);
            var words = new List<string>();

            foreach (var word in wordstream)
            {
                int wordLength = word.Length;

                // Search horizontally
                for (int r = 0; r < rows; r++)
                {
                    for (int c = 0; c <= columns - wordLength; c++)
                    {
                        if (HorizontalSearch(r, c, word))
                        {
                            words.Add(word);
                        }
                    }
                }

                // Search vertically
                for (int c = 0; c < columns; c++)
                {
                    for (int r = 0; r <= rows - wordLength; r++)
                    {
                        if (VerticalSearch(r, c, word))
                        {
                            words.Add(word);
                        }
                    }
                }
            }

            var result = words.GroupBy(x => x)
                        .OrderByDescending(x => x.Count())
                        .Select(x => x.Key).Take(10).ToList();

            Console.WriteLine("Word Finder finished.");

            return result;
        }

        private bool HorizontalSearch(int row, int col, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (grid[row, col + i] != word[i])
                {
                    return false;
                }
            }
            return true;
        }

        private bool VerticalSearch(int row, int col, string word)
        {
            for (int i = 0; i < word.Length; i++)
            {
                if (grid[row + i, col] != word[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
}
