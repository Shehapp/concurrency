using System;
using System.Threading;

namespace MultiThreadSort
{
    /// <summary>
    /// Summary description for Semaphore.
    /// </summary>
    public class Semaphore
    {
        int count;
        public Semaphore()
        {
            count = 0;
        }
        public Semaphore(int InitialVal)
        {
            count = InitialVal;
        }
        public void Wait()
        {
            lock (this)
            {
                count--;
                if (count < 0)
                    Monitor.Wait(this, Timeout.Infinite);
            }
        }
        public void Signal()
        {
            lock (this)
            {
                count++;
                if (count <= 0)
                    Monitor.Pulse(this);
            }
        }

        public override string ToString()
        {
            return count.ToString();
        }
    }
}
