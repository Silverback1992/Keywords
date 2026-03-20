namespace Keywords.Base;

public class Vehicle
{
    public string Brand { get; set; }

    public Vehicle(string brand)
    {
        Brand = brand;
        Console.WriteLine($"Vehicle initialized with brand: {Brand}");
    }
}
