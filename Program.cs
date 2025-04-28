using System;

class Program
{
    static void Main(string[] args)
    {
        const string mutexName = "MyUniqueAppMutex";

        using var checker = new SingleInstanceChecker(mutexName);

        if (checker.IsSingleInstance)
        {
            Console.WriteLine("This is the only instance running.");
            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
        else
        {
            Console.WriteLine("Another instance is already running. Exiting...");
        }
    }
}
