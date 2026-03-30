namespace Keywords.Lock;

public static class Worker
{
    public static void DoWork(int id, object x)
    {
        Console.WriteLine($"Thread {id} waiting");

        lock (x)
        {
            Console.WriteLine($"Thread {id} has entered the critical section");
            Thread.Sleep(2000); // Simulate work
            Console.WriteLine($"Thread {id} is leaving the critical section");
        }
    }
}
