namespace Keywords.Delegate;

public static class FileInteractions
{
    public static void OnFileSaved(object sender, FileSavedEventArgs e)
    {
        Console.WriteLine($"File '{e.FileName}' was saved successfully!");
    }
}
