namespace Keywords.Ref;

public static class ArrayHandler
{
    public static ref int GetElement(int[] arr, int index)
    {
        return ref arr[index];
    }
}
