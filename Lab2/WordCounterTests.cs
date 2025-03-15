using Xunit;

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
    }
}
