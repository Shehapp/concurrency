//https://leetcode.com/problems/print-in-order/description/

using System.Threading ;

public class Foo {
        Semaphore s1 = new Semaphore(0);
        Semaphore s2 = new Semaphore(0);

    public Foo() {

    }

    public void First(Action printFirst) {
        
        // printFirst() outputs "first". Do not change or remove this line.
        printFirst();
        s1.Signal();
    }

    public void Second(Action printSecond) {
        s1.Wait();
        // printSecond() outputs "second". Do not change or remove this line.
        printSecond();
        s2.Signal();
    }

    public void Third(Action printThird) {
        s2.Wait();
        // printThird() outputs "third". Do not change or remove this line.
        printThird();
    }

    
}
class Semaphore
	{
		int count ;
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