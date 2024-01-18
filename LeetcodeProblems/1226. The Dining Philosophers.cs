//https://leetcode.com/problems/the-dining-philosophers/description/

import java.util.concurrent.*; 

class DiningPhilosophers {
    Semaphore sem; 
    Semaphore []fork; 


    public DiningPhilosophers() {
        sem = new Semaphore(4); // deadlock
        fork = new Semaphore[5];
        for(int i=0 ; i<5;i++)
          fork[i]=new Semaphore(1);
    }

    // call the run() method of any runnable to execute its code
    public void wantsToEat(int philosopher,
                           Runnable pickLeftFork,
                           Runnable pickRightFork,
                           Runnable eat,
                           Runnable putLeftFork,
                           Runnable putRightFork) throws InterruptedException {
                               
                               sem.acquire();
                               fork[philosopher].acquire();
                               fork[(philosopher+1)%5].acquire();   
                               pickRightFork.run();
                               pickLeftFork.run();
                               eat.run();
                               putLeftFork.run();
                               putRightFork.run();
                               fork[philosopher].release();
                               fork[(philosopher+1)%5].release();
                               
                               sem.release();

    }
}