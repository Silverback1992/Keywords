namespace Keywords.Implicit;

public class Meter
{
    public double Value { get; set; }

    public Meter(double value)
    {
        Value = value;
    }

    //Custom implicit conversion from double to Meter
    public static implicit operator Meter(double value)
    {
        return new Meter(value);
    }
}
