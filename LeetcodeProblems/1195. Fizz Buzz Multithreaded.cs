//https://leetcode.com/problems/fizz-buzz-multithreaded/description/

using System.Threading ;

public class FizzBuzz {
    private int n;
    int cur=1;
    Semaphore s1;
    Semaphore s2;
    Semaphore s3;
    Semaphore s4;

    int three;
    int five;
    int three5;

    
    public FizzBuzz(int n) {
        this.n = n;
        three5=n/15;
        three=n/3 - three5;
        five=n/5 - three5;
        s1 = new Semaphore (0);
        s2 = new Semaphore (0);
        s3 = new Semaphore (0);
        s4 = new Semaphore (1);
    }

    // printFizz() outputs "fizz".
    public void Fizz(Action printFizz) {
                for(int i=0;i<three;i++){

        s1.Wait();
        printFizz();
        cur++;
        if(cur%15==0)
          s3.Signal();
        else if(cur%3==0)
          s1.Signal();
        else if(cur%5==0)
          s2.Signal();
        else 
         s4.Signal();
                }
    }

    // printBuzzz() outputs "buzz".
    public void Buzz(Action printBuzz) {
                for(int i=0;i<five;i++){

        s2.Wait();
        printBuzz();
        cur++;
        if(cur%15==0)
          s3.Signal();
        else if(cur%3==0)
          s1.Signal();
        else if(cur%5==0)
          s2.Signal();
        else 
         s4.Signal();
                }
    }

    // printFizzBuzz() outputs "fizzbuzz".
    public void Fizzbuzz(Action printFizzBuzz) {
                for(int i=0;i<three5;i++){

        s3.Wait();
        printFizzBuzz();
        cur++;
        if(cur%15==0)
          s3.Signal();
        else if(cur%3==0)
          s1.Signal();
        else if(cur%5==0)
          s2.Signal();
        else 
         s4.Signal();
    }
    }

    // printNumber(x) outputs "x", where x is an integer.
    public void Number(Action<int> printNumber) {
        for(int i=0;i<n-(three+five+three5);i++){
        s4.Wait();
        printNumber(cur);
        cur++;
        if(cur%15==0)
          s3.Signal();
        else if(cur%3==0)
          s1.Signal();
        else if(cur%5==0)
          s2.Signal();
        else 
         s4.Signal();
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