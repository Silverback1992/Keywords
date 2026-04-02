namespace Keywords.Params;

public static class NumberPrintHelper
{
    public static void PrintNumbers(params int[] numbers)
    {
        Console.WriteLine("The numbers are:");

        foreach (var number in numbers)
        {
            Console.WriteLine(number);
        }
    }
}
