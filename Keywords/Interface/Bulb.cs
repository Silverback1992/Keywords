namespace Keywords.Interface;

public class Bulb : ILightSource
{
    public void TurnOff()
    {
        Console.WriteLine("Bulb off");
    }

    public void TurnOn()
    {
        Console.WriteLine("Bulb is glowing warmly");
    }
}
