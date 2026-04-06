using Keywords.Using;
using Keywords.Volatile;
using static System.Math;

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

// For both sorceress.Move() and character.Move(), the method that gets called is determined by the type of the reference variable, not the actual object.
// Both already known at compile time, so the compiler binds to the method based on the reference type.
var sorceress = new Sorceress();
sorceress.Move();
DiabloCharacter character = sorceress;
character.Move();

// Both mauCat and othercat point to the same object in memory, which is an instance of EgyptianMau.
// The Egyiptian Mau Instance has a VPtr (virtual method table pointer) that points to the overridden TellOpinionOnBongos() method in EgyptianMau.
var mauCat = new EgyptianMau();
mauCat.TellOpinionOnBongos();
Cat othercat = mauCat;
othercat.TellOpinionOnBongos();

// In this case the new keyword in Aegean's TellOpinionOnBongos() hides the base class method instead of overriding it.
var aegeanCat = new Aegean();
aegeanCat.TellOpinionOnBongos();
Cat othercat2 = aegeanCat;
// The reason this will call the base class's method is because of static binding.
// The method to call is determined at compile time based on the type of the reference (Cat), not the actual object (Aegean).
// Since Aegean's method is hidden, not overridden, the compiler will bind to Cat's version of TellOpinionOnBongos() when using a Cat reference.
othercat2.TellOpinionOnBongos();
aegeanCat.TellOpinionOnBongos();

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

#region object

// Object is the ultimate base class for all types in C#. Every type, whether it's a value type (like int) or a reference type (like string), ultimately derives from object.

// A primtive type such as int is logically and syntactically an object.
// This allows it to fulfill 'is-a' relationships and be used in contexts that require an object, such as collections or methods that take object parameters.

// A primitive type such as int is physically and behaviorally a primitive value type, 
// which means it has value semantics (copied on assignment) and is stored on the stack (or inline in containing types) rather than the heap.
// This allows for efficient memory usage and performance.
// It lacks the overhead that every true heap-allocated object has, such as SyncBlockIndex and TypeHandler.

// Boxing: when you assign an int to an object the CLR allocates a small chunk of memory on the Heap
// copies the value of int into it and hands you the reference to that memory. This is called boxing because it "boxes" the value type into an object wrapper.
int myIntValue = 42;
object myObject = myIntValue; // Boxing occurs here

object myOtherObject = 5; // Boxing
int someIntValue = (int)myOtherObject; // Unboxing: the CLR checks that the object is actually a boxed int and then copies the value back to the stack

// We use boxing with legacy collections
ArrayList arrayList = new ArrayList();
arrayList.Add(10); // Boxing
int unboxedValue = (int)arrayList[0]; // Unboxing

// We use boxing with some modern methods that take object parameters
int age = 25;
Console.WriteLine("Age: {0}", age); // The int age is boxed to an object when passed to Console.WriteLine, which expects an object parameter.

#endregion

#region operator

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: operator              ║
╚═══════════════════════════════╝
""");

// Conversion operators: where operator meets implicit/explicit
// Already discussed in the explicit/implicit section with custom conversions

// The operator keyword lets you define how operators like +, -, *, / work for your custom types.
// This is called operator overloading.

// Rules:
// 1. You can only overload existing operators, you cannot create new ones.
// 2. At least one operand must be of the type you're defining the operator for.
// 3. Must be public and static

var v1 = new Vector(1, 2);
var v2 = new Vector(2, 3);
// This will call the overloaded + operator defined in the Vector class
// Compiled to: Vector.operator+(v1, v2) which creates a new Vector with X = 3 and Y = 5
var v3 = v1 + v2;

Console.WriteLine("""
╔══════════════════════════════╗
║   END: operator              ║
╚══════════════════════════════╝
""");

#endregion

#region out

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: out                   ║
╚═══════════════════════════════╝
""");

// The out value will be assigned inside the method, and the caller can use it after the method returns.
// It's a way to return multiple values from a method or to return a value without using the return statement.

// Must be assigned in the method before it returns, otherwise it will be a compile-time error.
// Caller does not need to initialize the variable before passing it to the method, but it must be declared.

// Keyword  Must Initialize Before?  Must Be Assigned In Method?
// ref              ✔                           X
// out              X                           ✔

int myUserId = 2;

if (UserCache.TryGetUsername(myUserId, out User? user))
{
    Console.WriteLine($"User found! Id: {user!.Id} Name: {user!.Name}");
}

Console.WriteLine("""
╔══════════════════════════════╗
║   END: out                   ║
╚══════════════════════════════╝
""");

#endregion

#region override

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: override              ║
╚═══════════════════════════════╝
""");

// Use the override modifier to extend or modify the abstract or virtual implementation of an inherited method, property, indexer, or event.
var sq = new Square(12);
Console.WriteLine($"Area of the square: {sq.GetArea()}");

Console.WriteLine("""
╔══════════════════════════════╗
║   END: override              ║
╚══════════════════════════════╝
""");

#endregion

#region Params

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: params                ║
╚═══════════════════════════════╝
""");

// Params: lets a method accept a variable number of arguments. Accept many arguments -> turn them into an array.
NumberPrintHelper.PrintNumbers(1, 2, 3, 4, 5);

// You can also pass an array directly
NumberPrintHelper.PrintNumbers([10, 20, 30]);

// Rules of params:
// 1. Must be the last parameter in the method signature
// 2. Only one params parameter allowed per method
// 3. Must be an array type (e.g., params int[])

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: params                  ║
╚═══════════════════════════════╝
""");

#endregion

#region Readonly

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: readonly              ║
╚═══════════════════════════════╝
""");

// Readonly field means you can assign it only during declaration or in the constructor of the class.
// And never change what it points to after that.

// Value types: value types store actual data directly
var myReadonly = new ReadonlyTest();
//myReadonly.Value = 20; // Compile-time error: cannot assign to readonly field outside of declaration or constructor

// Reference types: reference types store a reference to the data (object) on the heap
var myReadonly2 = new ReadonlyTest2();
myReadonly2.City.Name = "Los Angeles"; // This is allowed because we're not changing the reference, just modifying the object it points to
//myReadonly2.City = new City(); // Compile-time error: cannot assign a new reference to a readonly field

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: readonly                ║
╚═══════════════════════════════╝
""");

#endregion

#region ref 

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: ref                   ║
╚═══════════════════════════════╝
""");

// Default behavior:
// Value Types
int l = 5;
MyMathOperations.AddOne(l); // This will not change the value of 5 because it's passed by value (a copy is made)
Console.WriteLine(l); // x is copy of l

// With ref:
// With ref: x becomes a managed pointer that points directly to the memory address of b on the stack.
int b = 5;
MyMathOperations.AddOne(ref b);

// Rules:
// 1. Must use ref in both method definition and method call
// 2. Variable must be initialized before passing it as ref (unlike out, which does not require initialization)

// Reference Types
// c becomes a pointer to the pointer of myCountry1, so when we change c to point to a new Country object, myCountry1 also points to that new object.
var myCountry1 = new Country() { Name = "Hungary" };
CountryHandler.Change(ref myCountry1);
Console.WriteLine(myCountry1.Name);

// As a contrast if we didn't use ref, the method would only change the local copy of the reference, and myCountry1 would still point to the original Country object with Name "Hungary".
var myCountry2 = new Country() { Name = "Hungary" };
CountryHandler.Change(myCountry2);
Console.WriteLine(myCountry2.Name);

// Ref return: you can return a reference to a variable from a method, allowing the caller to modify the original variable through that reference.
int[] NumbersX = { 1, 2, 3, 4, 5 };

ref int extractedNumber = ref ArrayHandler.GetElement(NumbersX, 0); // Get a reference to the element at index 2 (which is 3)

extractedNumber = 10; // This will change the original array because extractedNumber is a reference to that element

Console.WriteLine(NumbersX[0]);

// Ref locals: you can declare a local variable as a reference to another variable, allowing you to work with the original variable through that reference.
int q = 20;
ref int refToQ = ref q; // refToQ is now a reference to q
refToQ = 30; // This changes the value of q to 30
Console.WriteLine(q);

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: ref                     ║
╚═══════════════════════════════╝
""");

#endregion

#region sizeof

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: sizeof                ║
╚═══════════════════════════════╝
""");

// sizeof: returns the number of bytes a type occupies in memory.
// In safe mode the compiler only allows sizeof for built-in types, but in unsafe mode you can use it with any struct type.
// sizeof doesn't work with reference types because they are stored on the heap and their size can vary (they have overhead for the object header, sync block, etc.)
Console.WriteLine(sizeof(int));

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: sizeof                  ║
╚═══════════════════════════════╝
""");

#endregion

#region stackalloc

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: stackalloc            ║
╚═══════════════════════════════╝
""");

// stakalloc: allocates memory on the stack instead of the heap.

// Normally, when you create an array in C#, it is allocated on the heap.
int[] heapArray = new int[5];
// This allocated memory on the heap managed by the garbage collector.

// Stack         Heap
// fast          slow
// auto cleaned  GC managed
// small         large
// short-lived   long-lived

// With stackalloc: this allocates memory on the stack, not managed by GC.
Span<int> stackArray = stackalloc int[5]; // This creates a span that points to memory on the stack
// What happens:
// stackalloc int[5] -> allocate 5 integers on stack
// wrap it in Span<int> which is a struct that provides safe access to that memory
// no heap allocation, no GC

// older style: unsafe code with pointers
// What can go wrong with pointers
// 1. Out of bounds access: if you try to access an index outside the allocated range, you can read/write memory that doesn't belong to you, leading to undefined behavior or crashes.
unsafe
{
    int* asd = stackalloc int[5];
    asd[10] = 42; // This is an out-of-bounds access and can cause undefined behavior    
}

// 2. Dangling pointers: if the stack frame is unwound (e.g., the method returns) and you still have a pointer to that memory, it becomes a dangling pointer, which can lead to undefined behavior if accessed.
//DanglingPointer.CreateDanglingPointer(); // long running code as an example to increase the chances of the stack frame being unwound and the memory being reused, which can cause the dangling pointer to point to invalid data.


Console.WriteLine("""
╔═══════════════════════════════╗
║  END: stackalloc              ║
╚═══════════════════════════════╝
""");

#endregion

#region struct

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: struct                ║
╚═══════════════════════════════╝
""");

var myTracker = new Tracker { CurrentPoint = new Point { X = 10 } };
myTracker.CurrentPoint.Move(50);
Console.WriteLine(myTracker.CurrentPoint.X);

var myTracker2 = new Tracker2 { CurrentPoint = new Point2 { X = 10 } };
myTracker2.CurrentPoint.Move(50);
Console.WriteLine(myTracker2.CurrentPoint.X);

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: struct                  ║
╚═══════════════════════════════╝
""");

#endregion

#region typeof

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: typeof                ║
╚═══════════════════════════════╝
""");

// typeof keyword: a compile-time operator used to obtain the System.Type object for a type known at compile time.

// Compile time vs Runtime:
// typeof(ClassName) -> resolved at compile time. It is faster because the compiler knows exactly which type you're referring to and can directly access its metadata. 
// Does not require an instance of the type to get its Type object, so it can be used in static contexts or when you don't have an object instance.
// obj.GetType() -> resolved at runtime. It is slower because it requires an instance of the object and the CLR has to determine the actual type of that instance at runtime, which involves more overhead.

// Useage in attributes: attribues are metadata baked into the assembly at compile time.
// Because of this you cannot use GetType() inside an attribute, you must use typeof.

// Scenarios
// 1. Automatic Depenedency Injection: frameworks like ASP.NET Core use typeof to register services and resolve dependencies based on type information.
// Imagine you are building a web framework. You want to scan a user's project and automatically register 
// every class that implements IService. You can't use obj.GetType() because you don't have an instance of those classes yet,
// but you can use typeof to get the Type objects for those classes and register them in your DI container.
var engine = new MagicEngine();
engine.Start();

// 2. Custom Attribute Processing: if you are building a logging framework and want to check if a class has a custom attribute like [LogSensitivity("High")],
// you can use typeof to get the Type object for the class and then check for the presence of that attribute.
var bankService = new BankService();
ProcessObject.Process(bankService);

// 3. Smart factory / serialization: if you are building a factory that creates objects based on type information,
// you can use typeof to get the Type object and then use reflection to create instances or serialize/deserialize objects.
var loadedCharacter = PlayerLoader.LoadPlayer("Warrior");

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: typeof                  ║
╚═══════════════════════════════╝
""");

#endregion

#region unsafe

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: unsafe                ║
╚═══════════════════════════════╝
""");

// By defaukt C# is a managed language
// The Garbage Collector (GC) moves objects around in memory to keep things tidy and the runtime checks every array index to make sure you don't crash the program.
// When you mark code as unsafe you gain the ability to use pointers.

// What does it actually allow?
// 1. Pointer types (int*, char*, etc.)
// 2. Use the "address-of" operator (&) to get the memory address of a variable
// 3. Use hte pointer indirection operator (*) to get the value at an address
// 4. Perform pointer arithmetic (e.g., p + 1 to move to the next element in an array)

// fixed keyword connection: because the GC likes to move objects around to defragment the heap using a pointer is dangerous.
// If you point to an object and the GC moves it, your pointer now points to garbage
// To prevent this we use the fixed keyword inside an unsafe block to pin the object in place

// Feature          Reference                               vs                                  Pointer
// Management       GC Handles it                                                               Programmer is responsible for it 
// Movement         GC can move object to clean up memory                                       The object must be fixed or it will crash
// Arithmetic       You can't do myClass + 1                                                    You can do pointer arithmetic like p + 1 to move to the next element in an array
// Safety           No blue screen of death                                                     In theory you could accidently overwrite Windoows system memory (modern operating systems use protected memory)

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: unsafe                  ║
╚═══════════════════════════════╝
""");

#endregion

#region using

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: using                 ║
╚═══════════════════════════════╝
""");

// 1. Using directive: namespace importing
// It tells the compiler I want to use tools from this toolbox (namespace) without having to write the full path every time.

// global using: you can put this in one file (e.g., GlobalUsings.cs) and it will be available throughout the entire project, so you don't have to repeat it in every file.
// It cleans up the header clutter

// using static: allows you to import the members of a static class
double root = Sqrt(16); // Instead of Math.Sqrt(16)

// 2. Using statement: resource management
// It is used with objects that implement the IDisposable interface, which have a Dispose() method to release unmanaged resources (e.g., file handles, database connections).

// The problem: the "lazy" garbage collector
// The GC is great at cleaning up memory but its terrible at cleaning up unmanaged resources.
// e.g. database connections, file handles, network sockets, etc. If you forget to close a file or dispose of a database connection, it can lead to resource leaks and other issues.

// The using statement ensures that Dispose() is called automatically when the block of code is exited, even if an exception occurs.
// This is because the compiler generates a try-finally block under the hood where Dispose() is called in the finally block.

string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Using", "test.txt");

using (var stream = new FileStream(filePath, FileMode.Open))
{
    // Do work with the file
} // The file is closed exactly here guranteed

// C# 8.0+
FileProcessor.ProcessFile(filePath); // The file is closed at the end of the method scope, even if an exception occurs.

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: using                   ║
╚═══════════════════════════════╝
""");

#endregion

#region virtual

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: virtual               ║
╚═══════════════════════════════╝
""");

// virtual: the virtual keyword marks a method, property or event as virtual
// This means that it can be overridden in a derived class using the override keyword, allowing for polymorphic behavior.

// virtual property: a property is actually two hidden methods: get_PropertyName() and set_PropertyName(value).
// When you mark a property as virtual, both the getter and setter become virtual methods that can be overridden in derived classes.

// Static dispatch: usually when you call a method the Compiler knows exactly where that code lives in memory and jumps straight there.

// Dynamic dispatch: with virtual methods, the method that gets called is determined at runtime based on the actual type of the object, not the type of the reference variable.

// When you define a class with a virtual method, the compiler creates a hidden structure called the virtual method table (vtable) for that class.
// This vtable contains pointers to the actual code for each virtual method.
// It also adds a hidden pointer (vptr) to each instance of the class that points to the vtable.
// When you call a virtual method, the CLR uses the vptr to look up the correct method implementation in the vtable at runtime, allowing for polymorphic behavior.

// Inheritance and overriding: when a class inherits from another it copies the parent's VTable and then swaps out the addresses for any method it overrides
// Animal VTable: Slot 1: -> Animal.MakeSound() address
// Dog VTable: Slot 1: -> Dog.MakeSound() address (overrides Animal's method)
// Cat VTable: Slot 1: -> Cat.MakeSound() address (overrides Animal's method)
// Because the MakeSound() method is always in Slot 1 for every animal the code doesn't need to know the actual type of the animal to call the correct MakeSound() method,
// it just looks in Slot 1 of the VTable that the vptr points to.

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: virtual                 ║
╚═══════════════════════════════╝
""");

#endregion

#region void

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: void                  ║
╚═══════════════════════════════╝
""");

// Use void as the return type of a method or local function to specify that the method doesn't return a value.
// While a void return type means "this returns nothing" a void* pointer in unsafe code is a pointer that can point to any type of data, but you cannot dereference it directly without first casting it to a specific pointer type (e.g., int*, char*).

// Analogy:
// int*: is a GPS coordinate with a note: this is a house treat it like a 4 byte integer
// void*: is a GPS coordinate with no note: I have no idea what's at this address, it could be anything, you better be careful when you go there

//unsafe
//{
//    int qqq = 10;
//    void* ptr = &qqq;
//    // Error: you cannot dereference a void pointer
//    // The CPU asks: "Do I read 1 byte? 4 bytes? 8 bytes? I have no idea, the pointer doesn't tell me!"
//    int value = *ptr;
//}

// Solution:
unsafe
{
    int qqq = 10;
    void* ptr = &qqq;
    int* value = (int*)ptr; // Cast the void pointer to an int pointer before dereferencing
    Console.WriteLine(*value);
}

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: void                    ║
╚═══════════════════════════════╝
""");

#endregion

#region volatile

Console.WriteLine("""
╔═══════════════════════════════╗
║  START: volatile              ║
╚═══════════════════════════════╝
""");

// 1. The problem: CPU caching
// Modern CPUs are incredibly fast but RAM is relatively slow. To speed things up each CPU core has its own L1/L2 cache

// The hierarchy of speed
// Think of the memory system as like a chef (CPU) working in a kitchen
// L1 Cache (Level 1): this is the chef's hands. It's the fastest memory, but very small (e.g., 32KB). It holds the exact data the CPU is working on this microsecond.
// L2 Cache (Level 2): this is the chef's cutting board. It's slower than the hands but larger (e.g., 256KB). It holds data that the CPU will likely need in the next few cycles.
// L3 Cache (Level 3): this is the refrigerator. It is shared between all CPU cores. It's much larger (several MB) but slower than L1 and L2.
// RAM (Main Memory): this is the grocery store down the street. It has everything but it takes "forever" (relatively speaking) to go get something from there.
// Stack and Heap: we are talking about how your program organizes its "workspace" inside the RAM.

// If a thread is running a loop checking a variable the CPU might decide: "I've checked this variable 10 times and it hasn't changed.
// To save time I'll just keep a copy of it in my local cache and stop looking at the main RAM.

// The bug: if another thread (on a different CPU core) changes that variable in the main RAM, the first thread won't see the change.
// It keeps looking at its own local "stale" copy.

// 2. The solution: volatile keyword
// By marking a field as volatile we disable the optimizations.
// What it does:
// a) freshness: it forces the CPU to read the value from the main memory every time it is accessed.
// b) memory barriers: it prevents the compiler from "reordering" instructions around that variable.
// (Sometimes the compiler moves code around to be more efficient; volatile prevents it from moving a write after it was supposed to happen.

// 3. Volatile vs lock
// volatile: is about visibility - it ensures that if Thread A changes a value Thread B sees that change immediately
// lock: is about atomicity - it ensures that a block of code is executed by only one thread at a time

// Test:
// Try it in debug mode
// Then try it in release mode
// Then try it in release mode with volatile keyword
//var volatileDemo = new VolatileDemo();
//volatileDemo.Run();

Console.WriteLine("""
╔═══════════════════════════════╗
║  END: volatile                ║
╚═══════════════════════════════╝
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