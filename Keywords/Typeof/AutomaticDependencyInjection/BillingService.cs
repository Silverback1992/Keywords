namespace Keywords.Typeof.AutomaticDependencyInjection;

public class BillingService : IMagicService
{
    public void Run()
    {
        Console.WriteLine("Processing payments...");
    }
}
