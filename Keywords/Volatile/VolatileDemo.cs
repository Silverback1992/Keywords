namespace Keywords.Volatile;

public class VolatileDemo
{
    // STEP 1: Try running this WITHOUT 'volatile' first.
    // In Release mode, this program will likely run FOREVER.
    private bool _stop = false;

    public void Run()
    {
        Console.WriteLine("Thread A: Starting loop...");

        Thread threadA = new Thread(() =>
        {
            int count = 0;
            while (!_stop) // The "Check"
            {
                count++;
                // If we put a Console.WriteLine here, the demo won't work.
                // Why? Because WriteLine is slow and forces a memory sync!
            }
            Console.WriteLine("Thread A: Loop stopped!");
        });

        threadA.Start();

        // Let Thread A run for 1 second
        Thread.Sleep(1000);

        Console.WriteLine("Thread B: Setting _stop = true");
        _stop = true;

        threadA.Join(); // Wait for Thread A to finish
        Console.WriteLine("Main: Finished.");
    }
}