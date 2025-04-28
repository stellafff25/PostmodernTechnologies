using System;
using System.Threading;

public interface ISingleInstanceChecker : IDisposable
{
    bool IsSingleInstance { get; }
}

public class SingleInstanceChecker : ISingleInstanceChecker
{
    private readonly Mutex _mutex;
    public bool IsSingleInstance { get; }

    public SingleInstanceChecker(string mutexName)
    {
        if (string.IsNullOrWhiteSpace(mutexName))
            throw new ArgumentException("Mutex name must not be empty.", nameof(mutexName));

        _mutex = new Mutex(true, mutexName, out bool createdNew);
        IsSingleInstance = createdNew;
    }

    public void Dispose()
    {
        if (IsSingleInstance)
        {
            _mutex?.ReleaseMutex();
        }
        _mutex?.Dispose();
    }
}
