namespace Keywords.Ref;

public static class MyMathOperations
{
    public static void AddOne(int x)
    {
        x++;
    }

    public static void AddOne(ref int x)
    {
        x++;
    }
}
