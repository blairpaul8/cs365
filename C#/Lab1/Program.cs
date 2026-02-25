class Program {
  static int Main() {
    //Console.Write("> ");
    
    // Read in user input and error check
    string input = Console.ReadLine()!;
    if (input == null) {
      Console.WriteLine("Error reading line.");
      return 1;
    }

    string[] tokens = input.Split(' ');
    int a;
    int b;
    
    //convert arg 1 and 2 to an int 
    try {
      a = Int32.Parse(tokens[1]);
      b = Int32.Parse(tokens[2]);
    } 
    catch (FormatException) {
      Console.WriteLine("Error reading line.");
      return 1;
    }
    int res = 0;

    switch(tokens[0]) {
      case "*":
        res = a * b;
        Console.WriteLine(res);
        break;
      case "+":
        res = a + b;
        Console.WriteLine(res);
        break;
      case "/":
        res = a / b;
        Console.WriteLine(res);
        break;
      case "%":
        res = a % b;
        Console.WriteLine(res);
        break;
      case "-":
        res = a - b;
        Console.WriteLine(res);
        break;
      default:
        Console.WriteLine("Invalid operator " + tokens[0] + ".");
        break;
    }
    
    return 0;
  }
}
