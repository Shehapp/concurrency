//https://leetcode.com/problems/building-h2o/description/

using System.Threading ;

public class H2O {
   Semaphore s1;
   Semaphore s2;
   Semaphore a5555;
   int ok=0;
    public H2O() {
        s1 = new Semaphore(0);
        s2 = new Semaphore(1);
        a5555 = new Semaphore(1);
    }

    public void Hydrogen(Action releaseHydrogen) {
		
        // releaseHydrogen() outputs "H". Do not change or remove this line.
 

        s1.Wait();
        a5555.Wait();
		releaseHydrogen();
        if(ok==1){
            ok=0;
            s2.Signal();
        }else{
            ok++;
        }
        a5555.Signal();
    }

    public void Oxygen(Action releaseOxygen) {
        
        // releaseOxygen() outputs "O". Do not change or remove this line.
        s2.Wait();
        releaseOxygen();
        s1.Signal();
        s1.Signal();
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