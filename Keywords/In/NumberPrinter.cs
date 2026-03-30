namespace Keywords.In;

public static class NumberPrinter
{
    public static void PrintNum(int x)
    {
        Console.WriteLine(x);
    }

    public static void PrintNum(in int x)
    {
        Console.WriteLine(x);
    }
}
