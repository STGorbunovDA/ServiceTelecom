using System.Threading;

namespace ServiceTelecom.Infrastructure
{
    internal class InstanceChecker
    {
        static readonly Mutex mutex = new Mutex(false, "ServiceTelecom");
        public static bool TakeMemory()
        {
            return mutex.WaitOne();
        }
    }
}
