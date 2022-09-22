namespace Cleverence
{
    public static class Server
    {
        private static int _count;
        private static ReaderWriterLockSlim _lock = new ();

        public static int GetCount()
        {
            _lock.EnterReadLock();
            try
            {
                return _count;
            }
            finally
            {
                Console.WriteLine($"Get count [{_count}] in thread [{Thread.CurrentThread.GetHashCode()}] TIME: [{DateTime.Now:mm:ss:ffffff}]");
                _lock.ExitReadLock();
            }
        }

        public static void AddToCount(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                _count += value;
            }
            finally
            {
                Console.WriteLine($"Add to Count: [{_count}] in thread [{Thread.CurrentThread.GetHashCode()}] TIME: [{DateTime.Now:mm:ss:ffffff}]");
                _lock.ExitWriteLock();
            }
        }

        public static void ResetCountToZero()
        {
            _count = 0;
        }
    }
}