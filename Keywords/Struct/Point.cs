namespace Keywords.Struct;

public struct Point
{
    public int X { get; set; }
    public void Move(int newX) => X = newX;
}
