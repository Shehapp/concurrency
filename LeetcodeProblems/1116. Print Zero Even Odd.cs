//https://leetcode.com/problems/print-zero-even-odd/description/

using System.Threading ;

public class ZeroEvenOdd {
    Semaphore s1;
    Semaphore s2;
    Semaphore s3;
    int n;
    public ZeroEvenOdd(int n)
    {
        this.n = n;
        s1 = new Semaphore(1);
        s2 = new Semaphore(0);
        s3 = new Semaphore(0);


    }
    // printNumber(x) outputs "x", where x is an integer.
    public void Zero(Action<int> printNumber) {
        for (int i = 1; i <= n; i++)
        {
            s1.Wait();
            printNumber(0);
            if (i % 2 == 0)
            {
                s2.Signal();
            }
            else
            {
                s3.Signal();
            }
        }
    }

    public void Even(Action<int> printNumber) {
        for (int i = 2; i <= n; i+=2)
        {
            s2.Wait();
            printNumber(i);
            s1.Signal();
        }
    }

    public void Odd(Action<int> printNumber) {
        for (int i = 1; i <= n; i+=2)
        {
            s3.Wait();
            printNumber(i);
            s1.Signal();
        }
    }
}
class Semaphore
	{
		public int count ;
		public Semaphore()
		{
			count = 0 ;
		}
		public Semaphore(int InitialVal)
		{
			count = InitialVal ;
		}
		public void Wait()
		{
			lock(this)
			{
				count-- ;
				if (count < 0)
					Monitor.Wait(this,Timeout.Infinite) ;
			}
		}
		public void Signal()
		{
			lock(this)
			{
				count++ ;
				if (count <= 0)
					Monitor.Pulse (this) ;
			}
		}
	}