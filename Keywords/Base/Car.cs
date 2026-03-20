namespace Keywords.Base;

public class Car : Vehicle
{
    public int DoorCount { get; set; }

    public Car(string brand, int doors) : base(brand) //we must call the base class constructor
    {
        DoorCount = doors;
        Console.WriteLine($"Car initialized with {DoorCount} doors.");
    }
}
