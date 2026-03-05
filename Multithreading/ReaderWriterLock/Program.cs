public class GlobalConfigurationCache
{
    public Dictionary<int, string> cache = new Dictionary<int, string>();
    private ReaderWriterLockSlim cacheLock = new ReaderWriterLockSlim();
    public void AddToCache(int key, string value)
    {
        bool lockTaken = false;
        try
        {
            cacheLock.EnterWriteLock();
            lockTaken = true;
            cache[key] = value;
        }
        finally
        {
            if(lockTaken)
            cacheLock.ExitWriteLock();
        }
    }

    public string? GetFromCache(int key)
    {
        bool lockTaken = false;
        try
        {
            cacheLock.EnterReadLock();
            lockTaken = true;
            return cache.TryGetValue(key, out value) ? value : null;
        }
        finally
        {
            if(lockTaken)
                cacheLock.ExitReadLock();
        }
    }
}