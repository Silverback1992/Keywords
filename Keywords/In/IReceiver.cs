namespace Keywords.In;

public interface IReceiver<in T>
{
    void Process(T item);
}
