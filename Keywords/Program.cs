using Keywords.Abstract;
using Keywords.Base;
using Keywords.Delegate;
using System.Linq.Expressions;

#region abstract

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: Abstract          ║
╚══════════════════════════════╝
"""
);

//can't create an instance of an abstract class
//var alett = new Dog();

var blink = new BorderCollie();
blink.Sit();
blink.Bark();
blink.Name = "Blink";

Console.WriteLine(blink.Name);

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: Abstract           ║
╚══════════════════════════════╝
"""
);

#endregion

#region as

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: as                ║
╚══════════════════════════════╝

"""
);

object obj1 = "hello";
string? str1 = obj1 as string; //successful cast, str1 will be "hello"
Console.WriteLine(str1);

object obj2 = 123;
string? str2 = obj2 as string; //unsuccessful cast, str2 will be null
Console.WriteLine(str2);

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: as                 ║
╚══════════════════════════════╝

"""
);

#endregion

#region base

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: base              ║
╚══════════════════════════════╝
"""
);

var peti = new EnergyDrinkLover();
peti.DrinkEnergyDrink();

var myCar = new Car("Toyota", 4); //the base constructor will be called first, then the derived constructor

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: base               ║
╚══════════════════════════════╝
"""
);

#endregion

#region break

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: break             ║
╚══════════════════════════════╝
"""
);

for (int i = 0; i < 5; i++)
{
    if (i == 2)
    {
        Console.WriteLine("breaking from loop");
        break;
    }
}

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: break              ║
╚══════════════════════════════╝
"""
);

#endregion

#region try-catch-finally

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: try-catch-finally ║
╚══════════════════════════════╝
"""
);

try //use the try block to wrap code that may throw an exception
{

}
catch (Exception) //use the catch block to handle exceptions thrown in the try block, you can have multiple catch blocks for different exception types
{

    throw;
}
finally //finally block is optional, but if present it will always be executed regardless of whether an exception was thrown or caught
{
}

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: try-catch-finally  ║
╚══════════════════════════════╝
"""
);

#endregion

#region checked-unchecked

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: checked-unchecked ║
╚══════════════════════════════╝
"""
);

int x = int.MaxValue;
int y = x + 1;
Console.WriteLine(y);

//this will throw an exception because of overflow
try
{
    checked
    {
        int overflowEx = x + 1;
    }
}
catch (OverflowException ex)
{
    Console.WriteLine("Caught the overflow exception!");
}

try
{
    checked
    {
        int overflowEx2 = checked(x + 1); //expression form of checked, still throws overflow exception
    }
}
catch (OverflowException ex)
{
    Console.WriteLine("Caught the overflow exception!");
}

//overflow exception in case of constant - complier warns about overflow at compile time
//int z = int.MaxValue + 1;

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: checked-unchecked  ║
╚══════════════════════════════╝
"""
);

#endregion

#region continue

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: continue          ║
╚══════════════════════════════╝
"""
);

for (int i = 0; i < 5; i++)
{
    if (i == 2)
    {
        Console.WriteLine($"Skipping {i}");
        continue;
    }

    Console.WriteLine($"i is {i}");
}

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: continue           ║
╚══════════════════════════════╝
"""
);

#endregion

#region default

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: default           ║
╚══════════════════════════════╝
"""
);

//use default as the default operator or literal to produce the default value of a type
int a = default;
Console.WriteLine(a); //0

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: default            ║
╚══════════════════════════════╝
"""
);

#endregion

#region delegate

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: delegate          ║
╚══════════════════════════════╝
"""
);

var mathOp = new MathOperation();
mathOp.Operator = Calculations.Add; //we can assign a method to the delegate property, the method must match the signature of the delegate type (int, int) => int
Console.WriteLine(mathOp.Calculate(3, 4));

Console.WriteLine(mathOp.Calculate(3, 4, Calculations.Multiply)); //we can also pass a method as an argument to the Calculate method, this will use the method passed as an argument instead of the one assigned to the Operator property

mathOp.Operator = (a, b) => a - b; //we can also assign a lambda expression to the delegate property, the lambda expression must also match the signature of the delegate type
Console.WriteLine(mathOp.Calculate(3, 4));

var myList = new List<int> { 1, 2, 3, 4, 5 };
myList.Where(x => x > 3); //x => x > 3 is compiled into a delegate

Func<int, int, int> add = (a, b) => a + b;  //Func is a built-in delegate type - T1, T2, ... Tn, TResult
Action<string> print = message => Console.WriteLine(message); //Action is a built-in delegate type - T1, T2, ... Tn, void
print("Hello World!");

//parameterless lambda expressions can be assigned to Action delegate type or Func delegate type
Action sayHello = () => Console.WriteLine("Hello!");
Func<int> getNumber = () => 42;

//Closures - when a lambda expression captures variables from its enclosing scope, it creates a closure that allows the lambda to access and modify those variables even after the scope has ended
int multiplier = 2;
Func<int, int> multiplyByMultiplier = x => x * multiplier; //captures the multiplier variable
multiplier = 10; //changing the value of multiplier will affect the behavior of the delegate
Console.WriteLine(multiplyByMultiplier(5));

var myActions = new List<Action>();

for (int i = 0; i < 5; i++)
{
    myActions.Add(() => Console.WriteLine(i)); //captures the loop variable i
}

foreach (var action in myActions)
{
    action(); //all actions will print 5 because they capture the same variable i
}

var myActions2 = new List<Action>();

for (int i = 0; i < 5; i++)
{
    int copy = i; //create a copy of the loop variable for each iteration, now each lambda captures a different variable
    myActions2.Add(() => Console.WriteLine(copy));
}

foreach (var action in myActions2)
{
    action(); // now the actions will print 0, 1, 2, 3, 4 because they capture different variables
}

Predicate<int> isEven = x => x % 2 == 0; //Predicate is a built-in delegate type that returns a bool
Console.WriteLine(isEven(4));

//Events are based on delegates, they allow a class to notify other classes when something happens.
//The class that raises the event is called the publisher, and the classes that subscribe to the event are called subscribers.
//The publisher defines an event using a delegate type, and subscribers can attach their event handler methods to the event using the += operator.
var button = new Button();
button.Clicked += ButtonInteractions.OnButtonClicked;

button.Click();

//EventHandler<TEventArgs> is a built-in delegate type for events, it has the signature (object sender, TEventArgs e) => void
//Can create custom event args by inheriting from EventArgs and adding properties to it, then use the custom event args type as the generic parameter for EventHandler<TEventArgs>
var fileSaver = new FileSaver();
fileSaver.FileSaved += FileInteractions.OnFileSaved;

fileSaver.SaveFile("myfile.txt");

var myNumbers = new List<int> { 5, 2, 9, 1 };
myNumbers.Sort((a, b) => a.CompareTo(b)); //the Sort method can take a Comparison<T> delegate as an argument, which has the signature (T x, T y) => int

//Converter<TInput, TOutput> is a built-in delegate type that represents a method that converts an object from one type to another, it has the signature (TInput input) => TOutput
var myNumbers2 = new List<string> { "1", "2", "3" };
var parsed = myNumbers2.ConvertAll(int.Parse);

//Expression trees - when you create a lambda expression, it can be compiled into a delegate or an expression tree.
//An expression tree is a data structure that represents the code of the lambda expression as a tree of expressions, which can be analyzed and modified at runtime.
//This is used in scenarios like LINQ to SQL, where the expression tree is translated into SQL queries.
Expression<Func<int, bool>> f = x => x > 5;
//this code does not create executable code directly

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: delegate           ║
╚══════════════════════════════╝
"""
);

#endregion

#region do

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: do                ║
╚══════════════════════════════╝
"""
);

do
{
    Console.WriteLine("This will always execute at least once, even if the condition is false.");
} while (false);

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: do                 ║
╚══════════════════════════════╝
"""
);

#endregion

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: stackalloc        ║
╚══════════════════════════════╝
"""
);

//unsafe
//{
//    int* p = stackalloc int[3];
//    p[100] = 5; // compiles fine, crashes or corrupts memory
//}

//Span<int> span = stackalloc int[3];

//span[100] = 5; // ❌ runtime exception (safe)

unsafe
{
    int* p;

    {
        int asd = 5;
        p = &asd;
    }

    int other = 999; // may reuse same stack slot

    //Thread.Sleep(20000); // give time for other code to run and potentially reuse the same stack slot

    Console.WriteLine(*p);
}




Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: stackalloc         ║
╚══════════════════════════════╝
"""
);


