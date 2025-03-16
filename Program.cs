using System;

namespace WordCounter
{
    public class Program
    {
        public static int Main(TextReader input, TextWriter output, TextWriter errorOutput)
        {
            try
            {
                output.Write("Enter text: ");
                string text = input.ReadLine();

                output.Write("Enter the word to search: ");
                string word = input.ReadLine();

                if (string.IsNullOrWhiteSpace(text) || string.IsNullOrWhiteSpace(word))
                {
                    errorOutput.WriteLine("Error: Please provide both text and a word to search for.");
                    return 1;
                }

                int count = WordCounter.CountWordOccurrences(text, word);
                output.WriteLine($"Number of occurrences: {count}");
                return 0;
            }
            catch (Exception ex)
            {
                errorOutput.WriteLine($"Error: {ex.Message}");
                return 1;
            }
        }

        public static void Main()
        {
            int exitCode = Main(Console.In, Console.Out, Console.Error);
            Environment.Exit(exitCode);
        }
    }
}
