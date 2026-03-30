namespace Keywords.Interface;

public class LED : ILightSource
{
    public void TurnOff()
    {
        Console.WriteLine("LED off");
    }

    public void TurnOn()
    {
        Console.WriteLine("LED blindingly bright");
    }
}
