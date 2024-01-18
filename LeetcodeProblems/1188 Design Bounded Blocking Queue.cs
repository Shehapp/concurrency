//https://leetcode.com/problems/design-bounded-blocking-queue/description/


import java.util.* ;
import java.util.concurrent.Semaphore;
import java.io.*;
public class BoundedBlockingQueue {
    private Semaphore se1;
    private Semaphore se2;
    private Semaphore ok;
    // add Queue data structure
    private Queue<Integer> q = new LinkedList();

    public BoundedBlockingQueue(int capacity)
    {
        se1 = new Semaphore(capacity);
        se2 = new Semaphore(0);
        ok = new Semaphore(1);
    }

    public void enqueue(int element) throws InterruptedException {
        se1.acquire();
        ok.acquire();
        q.add(element);
        ok.release();
        se2.release();
    }

    public int dequeue() throws InterruptedException {
        int ans;
        se2.acquire();
        ok.acquire();
        ans = q.remove();
        ok.release();
        se1.release();
        return ans;
    }

    public int size()
    {
        return q.size();
    }
}
