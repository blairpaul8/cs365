# C #

- imperative
- procedural
- compiled
- object oriented
- polymorphic
- modular
- strongly typed
- statically typed
- garbage collected

## Naming Conventions

- interfaces start with I
- PascalCase for class names and methods
- camelCase for method parameters and local variables
- PascalCase for constant names both fields and local constants
- Private instance fields start with an underscore and remaining is camelCase

## DotNet (.Net)

- .Net is a framework of many classes that run on the CLR
- CLR - common Language Runtime
  - this is c#'s virtual machine that interprets MSIL (Microsoft Intermediate Language)

- dotnet new - creates a new project
- dotnet build - builds the project
- dotnet run - executes the project

## Arrays

- Allocated on the heap

```
doule[] doubles = new double[50];

int[] my_ints = new int[] {1,2,3,4,5};
```

- note brackets go with the data type

## Auto-Derived Data

- var a = 1234;  // a is an integer due to the literal 1234
- var b = 1.2;   // b is a double due to the literal 1.2

## Formatted Strings

- $"{i, 10}" prints the variable i in a right justified field 10 characters wide
- $"{i, -10}" left justified
- $"{dbl, 6:F2}" right justified 6 wide in fixed point notation with two digits of precision.

## Handling Null

```
string fileName = Console.ReadLine()?.Trim() ?? string.Empty;
```

- ReadLine reads a line of input from the console and returns a string
- ?.Trim() the null conditional operator ?. ensures that the Trim method is only called if ReadLine does not return null avoiding a NullReferenceException.
- ?? string.Empty the null coalescing operator (??) provides a default value if the left hand side is null

- The ? syntax when declaring a variable tells C# to let the value type hold null.

```
double? pi = 3.14;"
```

## File I/O

- Files are controlled through System.IO
- BinaryReader
- BinaryWriter
- File
- Path
- FileInfo
- FileNotFoundException
- FileStream
- StreamReader
- StreamWriter
- TextReader
- TextWriter
- StringReader
- StringWriter

## Exception Handling

- try {}
  - Executes the statements inside that block might throw an exception
- catch {}
  - When an exception is thrown it will execute the code inside the catch block

- throw - throws an exception to a try{} catch{} block

## Loops

- for loop same as other Languages
- Foreach Loop

```
double[] array = new double[] {1.1,2.2,3.3,4.4,5.5};
foreach (var i in array[1..4]) {
  Console.WriteLine($"{i}");
}
```

- will print 1-3 lower bound is inclusive upper bound is exclusive
- Foreach can be used on primitive data types or classes that implement IEnumerable interface.

- Do while loop

```
while (condition) {
// body
}
```

```
do {
//body
} while(condition)
```

## Object oriented classes in C #

- Several Types of classes:
  - abstract - class that cannot be instantiated but can be inherited.
  - sealed - cannot be inherited
  - interface - outline of a class with no actual implementation

- Access Protection
  - internal
  - public
  - protected
  - private

- Classes' methods definitions are written in the class
  - virtual - method, property, or event that can be overridden by
    a derived class
  - NOTE: virtual methods invoke the derived method even when passed the base class.

### Class Example
  
```
class MyClass {
  public MyClass() {
    // constructor here
  }
  public string Name { get; set; } // property that is r/w 
  private int Secret; // variable that is private 
  public readonly int year; // Pubic readonly integer.
}
```

## Class vs Struct

- classes are reference based
- structs are value based

## Factory Pattern

- Chaining multiple method calls together
- requires methods to return a reference of the class.

## Lambda Functions

- syntax (parameters) => {return value;}

## Task Async Pattern (TAP)

- C# async functions calls are done with the keywords async and await
  - These require using Task and Task<> objects from the System.Threading.Tasks

- Barrier a synchronixation point that waits until all threads reach the barrier. Threads can be async before and after the barrier, but all threads will wait until all threads have reached the barrier.
