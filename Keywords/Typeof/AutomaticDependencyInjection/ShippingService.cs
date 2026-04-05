namespace Keywords.Typeof.AutomaticDependencyInjection;

public class ShippingService : IMagicService
{
    public void Run()
    {
        Console.WriteLine("Shipping boxes...");
    }
}
