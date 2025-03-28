using Xunit;
using System.IO;

namespace WordCounter.Tests
{
    public class WordCounterTests
    {
        [Fact]
        public void CountWordOccurrences_SingleOccurrence_ReturnsOne()
        {
            int result = WordCounter.CountWordOccurrences("hello world", "hello");
            Assert.Equal(1, result);
        }

        [Fact]
        public void CountWordOccurrences_MultipleOccurrences_ReturnsCorrectCount()
        {
            int result = WordCounter.CountWordOccurrences("hello world hello", "hello");
            Assert.Equal(2, result);
        }

        [Fact]
        public void CountWordOccurrences_NoOccurrences_ReturnsZero()
        {
            int result = WordCounter.CountWordOccurrences("hello world", "test");
            Assert.Equal(0, result);
        }

        [Fact]
        public void CountWordOccurrences_CaseInsensitive_ReturnsCorrectCount()
        {
            int result = WordCounter.CountWordOccurrences("Hello world hello", "hello");
            Assert.Equal(2, result);
        }

        [Fact]
        public void Main_SuccessfulExecution_ReturnsExitCodeZero()
        {
            var input = new StringReader("hello world\nhello\n");
            var output = new StringWriter();
            var errorOutput = new StringWriter();

            int exitCode = Program.Main(input, output, errorOutput);

            Assert.Equal(0, exitCode);
            Assert.Contains("Number of occurrences: 1", output.ToString());
            Assert.Empty(errorOutput.ToString());
        }

        [Fact]
        public void Main_EmptyInput_ReturnsExitCodeOne()
        {
            var input = new StringReader("\n\n");
            var output = new StringWriter();
            var errorOutput = new StringWriter();

            int exitCode = Program.Main(input, output, errorOutput);

            Assert.Equal(1, exitCode);
            Assert.Contains("Error: Please provide both text and a word to search for.", errorOutput.ToString());
        }

        [Fact]
        public void Main_ValidInput_GoesToStdout()
        {
            var input = new StringReader("hello world hello\nhello\n");
            var output = new StringWriter();
            var errorOutput = new StringWriter();

            int exitCode = Program.Main(input, output, errorOutput);

            Assert.Equal(0, exitCode);
            Assert.Contains("Number of occurrences: 2", output.ToString());
            Assert.Empty(errorOutput.ToString());
        }

        [Fact]
        public void Main_ErrorMessage_GoesToStderr()
        {
            var input = new StringReader("\n\n");
            var output = new StringWriter();
            var errorOutput = new StringWriter();

            int exitCode = Program.Main(input, output, errorOutput);

            Assert.Equal(1, exitCode);
            Assert.Contains("Error:", errorOutput.ToString());
        }

        [Fact]
        public void Main_ReadsInputFromStdin()
        {
            var input = new StringReader("hello world hello\nhello\n");
            var output = new StringWriter();
            var errorOutput = new StringWriter();

            int exitCode = Program.Main(input, output, errorOutput);

            Assert.Equal(0, exitCode);
            Assert.Contains("Number of occurrences: 2", output.ToString());
        }
    }
}
