//https://leetcode.com/problems/print-foobar-alternately/description/

using System.Threading ;

public class FooBar {
    private int n;
    Semaphore s1;
    Semaphore s2;

    public FooBar(int n) {
        this.n = n;
        s1 = new Semaphore(0);
        s2 = new Semaphore(1);
    }

    public void Foo(Action printFoo) {
        
        for (int i = 0; i < n; i++) {
            
        	// printFoo() outputs "foo". Do not change or remove this line.
           s2.Wait();
           printFoo();
           s1.Signal();

        }
    }

    public void Bar(Action printBar) {
        
        for (int i = 0; i < n; i++) {
            
            // printBar() outputs "bar". Do not change or remove this line.
            s1.Wait();
            printBar();
            s2.Signal();
        }
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