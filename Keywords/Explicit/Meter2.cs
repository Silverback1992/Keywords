namespace Keywords.Explicit;

public class Meter2
{
    public double Value { get; set; }

    public Meter2(double value)
    {
        Value = value;
    }

    public static explicit operator double(Meter2 meter)
    {
        return meter.Value;
    }
}
