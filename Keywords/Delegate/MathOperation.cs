namespace Keywords.Delegate;

public class MathOperation
{
    public delegate int Operation(int a, int b);

    public Operation? Operator { get; set; }

    public int Calculate(int a, int b, Operation op)
    {
        return op(a, b);
    }

    public int Calculate(int a, int b)
    {
        return Operator == null ? throw new InvalidOperationException("Operator is not set.") : Operator(a, b);
    }
}
