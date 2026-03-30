namespace Keywords.Interface;

public class PlayStation : ISmartDevice, IGameConsole
{
    // Explicit interface implementation allows us to provide different implementations for the same method name
    void ISmartDevice.Reset()
    {
        Console.WriteLine("Performing full factory wipe");
    }

    void IGameConsole.Reset()
    {
        Console.WriteLine("Restarting the current game session");
    }
}
