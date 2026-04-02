namespace Keywords.Override;

public class Square : Shape
{
    private readonly int _side;

    public Square(int n)
    {
        _side = n;
    }

    public override int GetArea() => _side * _side;
}
