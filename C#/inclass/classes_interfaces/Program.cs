using System;
using System.Collections.Generic;
class Program {
    public static void Main(string[] args) {
        var al = new List<I365>();

        string line;
        while (true) {
            line = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(line)) {
                break;
            }
            string[] sp = line.Split(' ');
            float left = float.Parse(sp[1]);
            float right = float.Parse(sp[2]);
            if (sp[0] == "add") {
                al.Add(new Adder(left, right));
            }
            else if (sp[0] == "sub") {
                al.Add(new Subber(left, right));
            }
            else {
                Console.WriteLine($"Unknown operator {sp[0]}.");
            }
        }
        al.Sort();
        foreach (var v in al) {
            Console.WriteLine(v.Operator());
        }
    }
}

