namespace Keywords.Ref;

public static class CountryHandler
{
    public static void Change(ref Country c)
    {
        c = new Country { Name = "Germany" };
    }

    public static void Change(Country c)
    {
        c = new Country { Name = "Germany" };
    }
}
