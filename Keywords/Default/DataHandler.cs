namespace Keywords.Default;

public class DataHandler : IDataHandler
{
    // The 'default' constraint is ONLY used here to tell the compiler:
    // "I'm overriding the interface's T? and I want it to work for both structs and classes."
    void IDataHandler.Process<T>(T? item) where T : default
    {
        throw new NotImplementedException();
    }
}
