namespace Keywords.Default;

public interface IDataHandler
{
    void Process<T>(T? item);
}
