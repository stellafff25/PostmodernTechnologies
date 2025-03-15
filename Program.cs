using System;

namespace WordCounter
{
    class Program
    {
        static int Main()
        {
            try
            {
                Console.Write("Enter text: ");
                string text = Console.ReadLine();

                Console.Write("Enter the word to search: ");
                string word = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(word))
                {
                    Console.Error.WriteLine("Error: Please provide both text and a word to search for.");
                    return 1;
                }

                int count = WordCounter.CountWordOccurrences(text, word);
                Console.WriteLine($"Number of occurrences: {count}");
                return 0;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }
    }
}
