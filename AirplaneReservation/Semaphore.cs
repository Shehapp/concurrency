using System;
using System.Threading ;

namespace AirplaneReservation
{
	/// <summary>
	/// Summary description for Semaphore.
	/// </summary>
	public class Semaphore
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
}
