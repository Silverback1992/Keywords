using Keywords.Abstract;
using Keywords.Delegate;
using System.Runtime.CompilerServices;

Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine("║     START: Abstract      ║");
Console.WriteLine("╚══════════════════════════════╝");

//can't create an instance of an abstract class
//var alett = new Dog();

var borderCollie = new BorderCollie();
borderCollie.Sit();
borderCollie.Bark();

Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine("║      END: Abstract       ║");
Console.WriteLine("╚══════════════════════════════╝");

Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine("║     START: as      ║");
Console.WriteLine("╚══════════════════════════════╝");

//int x = (int)"asd";

Console.WriteLine("╔══════════════════════════════╗");
Console.WriteLine("║      END: as       ║");
Console.WriteLine("╚══════════════════════════════╝");

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
//checked
//{
//    int z = x + 1;
//}

//expression form - still throws overflow exception
//int z = checked(x + 1);

//overflow exception in case of constant
//int z = int.MaxValue + 1;

int z = unchecked(x + 1);
Console.WriteLine(z);

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: checked-unchecked  ║
╚══════════════════════════════╝
"""
);

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: default           ║
╚══════════════════════════════╝
"""
);

//use default as the default operator or literal to produce the default value of a type
int a = default;
Console.WriteLine(a);

string ex = default!;
Console.WriteLine(ex);

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: default            ║
╚══════════════════════════════╝
"""
);

Console.WriteLine(
"""
╔══════════════════════════════╗
║     START: delegate          ║
╚══════════════════════════════╝
"""
);

MathOperation op = Add;
Console.WriteLine(op(3,4));
op = Multiply;
Console.WriteLine(op(3,4));

Console.WriteLine(Calculate(3, 4, Add));
Console.WriteLine(Calculate(3, 4, Multiply));

MathOperation op2 = (a, b) => a + b;
Console.WriteLine(op2(3, 4));

var myList = new List<int> { 1, 2, 3, 4, 5 };
myList.Where(x => x > 3); //x => x > 3 is compiled into a delegate

Func<int, int, int> add = (a, b) => a + b;  //Func is a built-in delegate type
Action<string> print = message => Console.WriteLine(message); //Action is a built-in delegate type
print("Hello World!");

Action sayHello = () => Console.WriteLine("Hello!");
Func<int> getNumber = () => 42;

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
    int copy = i;
    myActions2.Add(() => Console.WriteLine(copy)); //captures the loop variable i
}

foreach (var action in myActions2)
{
    action(); //all actions will print 5 because they capture the same variable i
}

Predicate<int> isEven = x => x % 2 == 0; //Predicate is a built-in delegate type that returns a bool
Console.WriteLine(isEven(4));

var button = new Button();
button.Clicked += OnButtonClicked;

button.Click();

Console.WriteLine(
"""
╔══════════════════════════════╗
║      END: delegate           ║
╚══════════════════════════════╝
"""
);

void OnButtonClicked(object sender, EventArgs e)
{
    Console.WriteLine("Button was clicked!");
}
static int Add(int x, int y) => x + y;
static int Multiply(int x, int y) => x * y;
static int Calculate(int x, int y, MathOperation operation) => operation(x, y);

delegate int MathOperation(int x, int y); //could use ref out but not with built in delegates
//Func<int, int, int> MathOperation
