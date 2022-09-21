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
                _lock.ExitReadLock();
            }
        }

        public static void AddCount(int value)
        {
            _lock.EnterWriteLock();
            try
            {
                _count += value;
            }
            finally
            {
                _lock.ExitReadLock();
            }
        }
    }
}