using System.Diagnostics;
using Xunit;
using System.IO;
using System;

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
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.StandardInput.WriteLine("hello world");
            process.StandardInput.WriteLine("hello");
            process.StandardInput.Close();
            process.WaitForExit();

            Assert.Equal(0, process.ExitCode);
        }

        [Fact]
        public void Main_EmptyInput_ReturnsExitCodeOne()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.StandardInput.WriteLine("");
            process.StandardInput.WriteLine("");
            process.StandardInput.Close();
            process.WaitForExit();

            Assert.Equal(1, process.ExitCode);
        }

        [Fact]
        public void Main_ErrorMessage_GoesToStderr()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.StandardInput.WriteLine("");
            process.StandardInput.WriteLine("");
            process.StandardInput.Close();
            string errorOutput = process.StandardError.ReadToEnd();
            process.WaitForExit();

            Assert.Contains("Error:", errorOutput);
        }

        [Fact]
        public void Main_ReadsInputFromStdin()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();

            using (StreamWriter writer = process.StandardInput)
            {
                writer.WriteLine("hello world hello");
                writer.WriteLine("hello");
            }

            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();
            
            Assert.Contains("Number of occurrences: 2", output);
        }

        [Fact]
        public void Main_ValidInput_GoesToStdout()
        {
            var process = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = "run",
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                }
            };

            process.Start();
            process.StandardInput.WriteLine("hello world hello");
            process.StandardInput.WriteLine("hello");
            process.StandardInput.Close();
            string output = process.StandardOutput.ReadToEnd();
            process.WaitForExit();

            Assert.Contains("Number of occurrences: 2", output);
        }
    }
}
