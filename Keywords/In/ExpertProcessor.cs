namespace Keywords.In;

public class ExpertProcessor : IReceiver<Expert>
{
    public void Process(Expert item)
    {
        Console.WriteLine($"Processing expert named {item.Name}");
    }
}
