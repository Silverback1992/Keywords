namespace Keywords.Delegate;

public class Button
{
    public event EventHandler? Clicked;

    public void Click()
    {
        Clicked?.Invoke(this, EventArgs.Empty);
    }
}
