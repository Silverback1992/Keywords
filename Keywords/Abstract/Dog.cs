namespace Keywords.Abstract;

public abstract class Dog : Animal //abstact class can inherit from another class (abstract or not)
{
    public abstract void Bark(); //must be implemented by derived classes
    public virtual void Sit() //abstract class can contain non-abstract methods with implementation
    {
        Console.WriteLine("The dog sits.");
    }

}
