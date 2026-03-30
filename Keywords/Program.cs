using Keywords.Abstract;
using Keywords.Base;
using Keywords.Delegate;
using Keywords.Explicit;
using Keywords.Extern;
using Keywords.In;
using Keywords.Interface;
using Keywords.Lock;
using Keywords.New;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

#region Abstract

Console.WriteLine("""
╔══════════════════════════════╗
║      START: Abstract         ║
╚══════════════════════════════╝
""");

// Note: You cannot create an instance of an abstract class
// var alert = new Dog(); 

var blink = new BorderCollie();
blink.Sit();
blink.Bark();
blink.Name = "Blink";

Console.WriteLine(blink.Name);

Console.WriteLine("""
╔══════════════════════════════╗
║       END: Abstract          ║
╚══════════════════════════════╝
""");

#endregion

#region As

Console.WriteLine("""
╔══════════════════════════════╗
║        START: as             ║
╚══════════════════════════════╝
""");

object obj1 = "hello";
// Successful cast: str1 will be "hello"
string? str1 = obj1 as string;
Console.WriteLine(str1);

object obj2 = 123;
// Unsuccessful cast: str2 will be null because obj2 is an int
string? str2 = obj2 as string;
Console.WriteLine(str2);

Console.WriteLine("""
╔══════════════════════════════╗
║         END: as              ║
╚══════════════════════════════╝
""");

#endregion

#region Base

Console.WriteLine("""
╔══════════════════════════════╗
║       START: base            ║
╚══════════════════════════════╝
""");

var peti = new EnergyDrinkLover();
peti.DrinkEnergyDrink();

// The base constructor is called first, then the derived constructor
var myCar = new Car("Toyota", 4);

Console.WriteLine("""
╔══════════════════════════════╗
║        END: base             ║
╚══════════════════════════════╝
""");

#endregion

#region Break

Console.WriteLine("""
╔══════════════════════════════╗
║       START: break           ║
╚══════════════════════════════╝
""");

for (int i = 0; i < 5; i++)
{
    if (i == 2)
    {
        Console.WriteLine("Breaking from loop...");
        break;
    }
}

Console.WriteLine("""
╔══════════════════════════════╗
║        END: break            ║
╚══════════════════════════════╝
""");

#endregion

#region Try-Catch-Finally

Console.WriteLine("""
╔══════════════════════════════╗
║   START: try-catch-finally   ║
╚══════════════════════════════╝
""");

// Use 'try' to wrap code that may throw an exception
try
{
    // Implementation here
}
// Use 'catch' to handle exceptions. Multiple blocks can exist for different types.
catch (Exception)
{
    throw;
}
// 'finally' is optional; it always executes regardless of an exception
finally
{
    // Cleanup code
}

Console.WriteLine("""
╔══════════════════════════════╗
║    END: try-catch-finally    ║
╚══════════════════════════════╝
""");

#endregion

#region Checked-Unchecked

Console.WriteLine("""
╔══════════════════════════════╗
║   START: checked-unchecked   ║
╚══════════════════════════════╝
""");

int x = int.MaxValue;
int y = x + 1; // Default behavior: overflows silently to int.MinValue
Console.WriteLine(y);

// This will throw an exception because of explicit overflow checking
try
{
    checked
    {
        int overflowEx = x + 1;
    }
}
catch (OverflowException)
{
    Console.WriteLine("Caught the overflow exception!");
}

try
{
    // Expression form of checked
    int overflowEx2 = checked(x + 1);
}
catch (OverflowException)
{
    Console.WriteLine("Caught the expression-based overflow exception!");
}

// Note: Constant overflows (e.g., int z = int.MaxValue + 1) are caught by the compiler at compile time.

Console.WriteLine("""
╔══════════════════════════════╗
║    END: checked-unchecked    ║
╚══════════════════════════════╝
""");

#endregion

#region Continue

Console.WriteLine("""
╔══════════════════════════════╗
║       START: continue        ║
╚══════════════════════════════╝
""");

for (int i = 0; i < 5; i++)
{
    if (i == 2)
    {
        Console.WriteLine($"Skipping {i}");
        continue;
    }

    Console.WriteLine($"i is {i}");
}

Console.WriteLine("""
╔══════════════════════════════╗
║        END: continue         ║
╚══════════════════════════════╝
""");

#endregion

#region Default

Console.WriteLine("""
╔══════════════════════════════╗
║       START: default         ║
╚══════════════════════════════╝
""");

// Produces the default value of a type (0 for int, null for reference types)
int a = default;
Console.WriteLine(a);

Console.WriteLine("""
╔══════════════════════════════╗
║        END: default          ║
╚══════════════════════════════╝
""");

#endregion

#region Delegate & Event

Console.WriteLine("""
╔══════════════════════════════╗
║       START: delegate        ║
╚══════════════════════════════╝
""");

var mathOp = new MathOperation();

// Assigning a method to a delegate property (signature must match)
mathOp.Operator = Calculations.Add;
Console.WriteLine(mathOp.Calculate(3, 4));

// Passing a method directly as an argument
Console.WriteLine(mathOp.Calculate(3, 4, Calculations.Multiply));

// Assigning a lambda expression
mathOp.Operator = (a, b) => a - b;
Console.WriteLine(mathOp.Calculate(3, 4));

// LINQ: The lambda x => x > 3 is compiled into a delegate
var myList = new List<int> { 1, 2, 3, 4, 5 };
var filtered = myList.Where(x => x > 3);

// Built-in Delegate Types:
// Func: T1, T2... to TResult
Func<int, int, int> add = (a, b) => a + b;
// Action: T1, T2... returns void
Action<string> print = Console.WriteLine;
print("Hello World!");

// Parameterless lambdas
Action sayHello = () => Console.WriteLine("Hello!");
Func<int> getNumber = () => 42;

// --- Closures ---
// Capturing variables from an enclosing scope
int multiplier = 2;
Func<int, int> multiplyByMultiplier = x => x * multiplier;
multiplier = 10; // This change affects the delegate behavior
Console.WriteLine(multiplyByMultiplier(5)); // Prints 50

// Closure Issue: Capturing the loop variable
var myActions = new List<Action>();
for (int i = 0; i < 5; i++)
{
    myActions.Add(() => Console.WriteLine(i));
}
foreach (var action in myActions)
{
    action(); // Prints '5' five times because they all capture the same 'i'
}

// Closure Solution: Local copy
var myActions2 = new List<Action>();
for (int i = 0; i < 5; i++)
{
    int copy = i;
    myActions2.Add(() => Console.WriteLine(copy));
}
foreach (var action in myActions2)
{
    action(); // Prints 0, 1, 2, 3, 4
}

// Predicate: Returns a bool
Predicate<int> isEven = x => x % 2 == 0;
Console.WriteLine(isEven(4));

// --- Events ---
// Events allow publishers to notify subscribers using the += operator
var button = new Button();
button.Clicked += ButtonInteractions.OnButtonClicked;
button.Click();

// Custom EventArgs example
var fileSaver = new FileSaver();
fileSaver.FileSaved += FileInteractions.OnFileSaved;
fileSaver.SaveFile("myfile.txt");

// Comparison delegate
var myNumbers = new List<int> { 5, 2, 9, 1 };
myNumbers.Sort((val1, val2) => val1.CompareTo(val2));

// Converter delegate: (TInput) => TOutput
var myNumbers2 = new List<string> { "1", "2", "3" };
var parsed = myNumbers2.ConvertAll(int.Parse);

// --- Expression Trees ---
// Data structures representing code, used in LINQ to SQL/Entity Framework
Expression<Func<int, bool>> f = x => x > 5;

Console.WriteLine("""
╔══════════════════════════════╗
║        END: delegate         ║
╚══════════════════════════════╝
""");

#endregion

#region Do-While

Console.WriteLine("""
╔══════════════════════════════╗
║          START: do           ║
╚══════════════════════════════╝
""");

do
{
    Console.WriteLine("This executes at least once, even if the condition is false.");
} while (false);

Console.WriteLine("""
╔══════════════════════════════╗
║           END: do            ║
╚══════════════════════════════╝
""");

#endregion

#region Explicit & Implicit

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: explicit + implicit   ║
╚═══════════════════════════════╝
""");

// Implicit: Safe and obvious conversion handled automatically by the compiler
int num = 42;
double d = num;

// Custom implicit conversion (Meter class)
Keywords.Implicit.Meter m = 5.0;

// Explicit: Used when data might be lost or the conversion is dangerous.
// Programmer must write a cast.
double myX = 5.7;
int myY = (int)myX; // Truncates fractional part to 5

// Custom explicit conversion (Meter2 class)
Meter2 m2 = new Meter2(10.0);
double d2 = (double)m2;

Console.WriteLine("""
╔══════════════════════════════╗
║   END: explicit + implicit   ║
╚══════════════════════════════╝
""");

#endregion

#region Extern

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: extern                ║
╚═══════════════════════════════╝
""");

// extern: linking C# code to something implemented elsewhere
// Example: a native C/C++ library, runtime-provided code, another assembly
NativeMethods.MessageBox(IntPtr.Zero, "Hello from extern!", "Extern Example", 0);

Console.WriteLine("""
╔══════════════════════════════╗
║   END: extern                ║
╚══════════════════════════════╝
""");

#endregion

#region Fixed

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: fixed                 ║
╚═══════════════════════════════╝
""");

// fixed: temporarily pins a variable in memory to prevent the garbage collector from moving it.
// One thing the GC does is move objects around in memory to optimize performance.
unsafe
{
    int[] numbers = { 1, 2, 3, 4, 5 };

    fixed (int* p = numbers)
    {
        Console.WriteLine(*p);
        Console.WriteLine(*(p + 1));
    }
}

Console.WriteLine("""
╔══════════════════════════════╗
║   END: fixed                 ║
╚══════════════════════════════╝
""");

#endregion

#region Goto

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: goto                  ║
╚═══════════════════════════════╝
""");

Console.WriteLine("Start");
goto Skip;
Console.WriteLine("This line will never run");
Skip:
Console.WriteLine("End");

Console.WriteLine("""
╔══════════════════════════════╗
║   END: goto                  ║
╚══════════════════════════════╝
""");

#endregion

#region In

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: in                    ║
╚═══════════════════════════════╝
""");

// in is used in foreach loops
var myCollection = new List<int>() { 1, 2, 3 };
foreach (var item in myCollection)
{

}

// in can be used as a parameter modifier which you use to pass an argument to a method by reference
// rather than value
// Normall the value is copied (or reference is copied for reference types)
// value type -> two independent values
// reference type -> two references to the same object
NumberPrinter.PrintNum(5);

// With in: now the parameter is passed by reference but cannot be modified inside the method
int someNumber = 10;
NumberPrinter.PrintNum(in someNumber);

// Why this exists? -> For performance with largue structs
// Without in -> a big struct would be copied when passed to the method, which can be expensive
// With in -> the method receives a reference to the original struct, avoiding the copy

// in can be used as a generic type parameter (variance)
// Normally, generic type parameters are invariant, meaning you cannot use a more derived type than specified
// If a method expects an Action<Dog> you can't give it Action<Animal> even if Dog is a subclass of Animal
IReceiver<Expert> expertReceiver = new ExpertProcessor();
// This is allowed because of 'in' variance: (without 'in', this would be a compile-time error)
IReceiver<Electrician> electricianReceiver = expertReceiver;
Electrician electrician = new Electrician { Name = "John" };
electricianReceiver.Process(electrician);

// in in LINQ
var people = new List<string> { "Alice", "Bob", "Charlie" };
var filteredPeople = from person in people
                     where person.StartsWith('A')
                     select person;

Console.WriteLine("""
╔══════════════════════════════╗
║   END: in                    ║
╚══════════════════════════════╝
""");

#endregion

#region Interface

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: interface             ║
╚═══════════════════════════════╝
""");

var myPs = new PlayStation();
// myPs.Reset(); // This would be ambiguous because both interfaces have a Reset method
((ISmartDevice)myPs).Reset(); // Calls ISmartDevice.Reset
((IGameConsole)myPs).Reset(); // Calls IGameConsole.Reset

// Interface segregation and fat interfaces: the strategy is small, focused interfaces rather than large, general-purpose ones. This promotes better design and maintainability.
// X Instead of IMachine { Print(); Scan(); Fax(); }
// O IPrinter { Print(); } IScanner { Scan(); } IFax { Fax(); }

Console.WriteLine("""
╔══════════════════════════════╗
║   END: interface             ║
╚══════════════════════════════╝
""");

#endregion

#region Is

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: is                    ║
╚═══════════════════════════════╝
""");

// is: checks if something matches a type or pattern
// 1. Type checking
object myObj = "hello";

if (myObj is string s)
{
    Console.WriteLine("It's a string!");
}

// 2. Type check + variable declaration
// Can check and create a typed variable in one step
object myObj2 = 123;

if (myObj2 is int myInt)
{
    Console.WriteLine($"It's an int: {myInt}");
}

// 3. Pattern matching with 'is'
int myPatternExample = 10;

if (myPatternExample is > 5 and < 15)
{
    Console.WriteLine("myPatternExample is between 5 and 15");
}

// Equivalent classic code would be: if (myPatternExample > 5 && myPatternExample < 15)

// 4. 'is' can also be used for null checks
string? nullableString = null;

if (nullableString is null)
{
    Console.WriteLine("The string is null");
}

Console.WriteLine("""
╔══════════════════════════════╗
║   END: is                    ║
╚══════════════════════════════╝
""");

#endregion

#region new

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: new                   ║
╚═══════════════════════════════╝
""");

//VIP DONT DEMO IT YET

var mauCat = new EgyptianMau();
mauCat.TellOpinionOnBongos();
Cat othercat = mauCat;
othercat.TellOpinionOnBongos();

var aegeanCat = new Aegean();
aegeanCat.TellOpinionOnBongos();
Cat othercat2 = aegeanCat;
othercat2.TellOpinionOnBongos();

Console.WriteLine("""
╔══════════════════════════════╗
║   END: new                   ║
╚══════════════════════════════╝
""");

#endregion

#region null

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: null                  ║
╚═══════════════════════════════╝
""");

// the null keyword is a literal that represents a null reference, one that doesn't refer to any object.
// It can be assigned to any reference type or nullable value type.

//A nullable value type T? represents all the values of the underlying value type T plus an additional null value.
bool? isRaining = null; // Nullable bool can be true, false, or null

Console.WriteLine("""
╔══════════════════════════════╗
║   END: null                  ║
╚══════════════════════════════╝
""");

#endregion



#region lock

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: lock                  ║
╚═══════════════════════════════╝
""");

object lockObj = new object();

for (int i = 0; i <= 3; i++)
{
    int threadId = i; // Capture loop variable correctly
    new Thread(() => Worker.DoWork(threadId, lockObj)).Start();
}

Console.WriteLine("""
╔══════════════════════════════╗
║   END: lock                  ║
╚══════════════════════════════╝
""");

#endregion