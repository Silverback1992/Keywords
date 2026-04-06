namespace Keywords.Using;

public static class FileProcessor
{
    public static void ProcessFile(string filePath)
    {
        using var fileStream = new FileStream(filePath, FileMode.Open);
        // Do work
        // The file is closed automatically at the end of the method scope, even if an exception occurs.
    }
}
