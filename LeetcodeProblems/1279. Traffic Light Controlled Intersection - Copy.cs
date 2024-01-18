//https://leetcode.com/problems/traffic-light-controlled-intersection/description/


import java.util.* ;
import java.util.concurrent.Semaphore;

public class main {
    public static void main() {

    }
}
class TrafficLight {
    int cur=1;
    public TrafficLight() {
        // Constructor - no initialization needed as we start with road 1 by default
    }

    // Synchronized method to allow cars to arrive at the intersection without race conditions
    public synchronized void carArrived(
            int carId,        // ID of the car arriving at the intersection
            int roadId,       // ID of the road the car is on. Can be 1 (road A) or 2 (road B)
            int direction,    // Direction of the car, not used in the current context
            Runnable turnGreen,   // Runnable to turn light to green on the car's current road
            Runnable crossCar     // Runnable to allow the car to cross the intersection
    ) {
        // synchronized block to allow only one car to enter the intersection at a time ok
        if(cur!=roadId) {
            cur=roadId;
            turnGreen.run();
        }
        crossCar.run();
    }
}