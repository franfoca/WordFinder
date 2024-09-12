namespace WordFinder.Application
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("WordFinder Application started.");
                var tryAgain = true;

                while (tryAgain)
                {
                    Console.WriteLine("Please select an option:");
                    Console.WriteLine("1. Use text files to insert characters grid and words stream");
                    Console.WriteLine("2. Insert characters grid and words stream manually");

                    var option = Console.ReadLine();

                    int number;
                    if (Int32.TryParse(option, out number))
                    {
                        if (number == 1)
                        {
                            Console.WriteLine("Insert the full file path of the characters grid: ");
                            var charactersGridPath = Console.ReadLine();

                            if (File.Exists(charactersGridPath))
                            {
                                Console.WriteLine("Characters grid file found. Processing file...");
                                var charactersGridData = File.ReadAllLines(charactersGridPath);
                                var game = new WordFinder(charactersGridData);
                                Console.WriteLine("Insert the full fule path of the words stream: ");
                                var wordsStreamPath = Console.ReadLine();

                                if (File.Exists(wordsStreamPath))
                                {
                                    Console.WriteLine("Words stream file found. Processing file...");
                                    var wordsStreamFileData = File.ReadAllText(wordsStreamPath);
                                    var wordsStream = wordsStreamFileData.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Distinct().ToList();
                                    Console.WriteLine("Words stream file processed.");
                                    var wordsResult = game.Find(wordsStream);
                                
                                    Console.WriteLine("Most repeated words:");
                                    foreach (var word in wordsResult)
                                    {
                                        Console.WriteLine(word);
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Words stream file was not found, try again with a valid path.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Characters grid file was not found, try again with a valid path.");
                            }
                        }
                        else if (number == 2)
                        {
                            var grid = new List<string>();
                            var wordsStream = new List<string>();
                            var continueAdding = true;
                            do
                            {
                                Console.WriteLine("Write the characters of the row. If you wrote all the rows, press ENTER: ");
                                var row = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(row))
                                {
                                    grid.Add(row);
                                }
                                else
                                {
                                    continueAdding = false;
                                }
                            } while (continueAdding);

                            var game = new WordFinder(grid);

                            continueAdding = true;
                            do 
                            { 
                                Console.WriteLine("Write a word to find. If you wrote all the words, press ENTER: ");
                                var word = Console.ReadLine();
                                if (!string.IsNullOrWhiteSpace(word))
                                {
                                    if(!wordsStream.Contains(word))
                                        wordsStream.Add(word);
                                }
                                else
                                {
                                    continueAdding = false;
                                }
                            } while (continueAdding);

                            var wordsResult = game.Find(wordsStream);

                            Console.WriteLine("Most repeated words:");
                            foreach (var word in wordsResult)
                            {
                                Console.WriteLine(word);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Incorrect option, try again with a valid option.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Incorrect option, try again with a valid option.");
                    }
                
                    var incorrectOption = true;
                    do
                    {
                        Console.WriteLine("Do you want to try again (Y/N):");
                        var response = Console.ReadLine();
                        if (response.ToUpper() == "Y")
                            incorrectOption = false;
                        else if (response.ToUpper() == "N")
                        {
                            tryAgain = false;
                            incorrectOption = false;
                        }
                        else
                        {
                            Console.WriteLine("Incorrect Option.");
                        }

                    } while (incorrectOption);

                    Console.Clear();
                }
            }
            catch (ArgumentException argEx)
            {
                Console.WriteLine($"{argEx.Message}. Restart the application and try again.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error trying to process the information. Restart the application and try again.");
            }
        }
    }
}
