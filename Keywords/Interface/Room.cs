namespace Keywords.Interface;

public class Room
{
    // The Room doesn't care about the specific type of light source, it just knows that it has a light source that can be turned on.
    // This is an example of decoupling the Room class from specific implementations of light sources, allowing for greater flexibility and maintainability.
    // It is also an example of polymorphism, as the Room can work with any object that implements the ILightSource interface, regardless of its specific type.
    private readonly ILightSource _light;

    public Room(ILightSource lightSource)
    {
        _light = lightSource;
    }

    public void SwitchOn()
    {
        _light.TurnOn();
    }
}
