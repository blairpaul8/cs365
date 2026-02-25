using System;
using System.Threading.Tasks;

public class Example {

  public static void Main()  {
    int value = 0;
    const int NUM = 1_000_000;
    object MyLock;
    Parallel.For(0, NUM, i => 
    {
      lock(MyLock)
      {
        value += 1;
      }
    });

    Console.WriteLine($"value: {value}");
  }
}
