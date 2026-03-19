namespace Keywords.Abstract
{
    public abstract class Dog
    {
        public abstract void Bark();
        public virtual void Sit()
        {
            Console.WriteLine("The dog sits.");
        }

    }
}
