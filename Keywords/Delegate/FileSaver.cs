namespace Keywords.Delegate;

public class FileSaver
{
    public event EventHandler<FileSavedEventArgs> FileSaved;

    public void SaveFile(string fileName)
    {
        FileSaved?.Invoke(this, new FileSavedEventArgs() { FileName = fileName });
    }
}
