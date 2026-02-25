using System;
using System.IO;
using System.Collections.Generic;

class Cart {
    public static void Main(string[] nothing) {
        Cart cart = new Cart();

        //Console.Write("Enter shopping cart file: ");
        string file = Console.ReadLine() ?? string.Empty;
        //Console.WriteLine("File name: " + file );

        //StreamReader sr = new StreamReader(file);

        foreach (string line in File.ReadLines(file)) {
            string[] tokens = line.Split(' ');
            double price = Double.Parse(tokens[0]);
            string name = "";
            for (int i = 1; i < tokens.Length; i++) {
                name += tokens[i];
                if (i != (tokens.Length - 1)) {
                    name += " ";
                }
            }
        
            
            if (!cart.Empty() && cart.hasItem(name)) {
                cart.updateItem(name, price);
            } else {
                cart.AddItem(name, price);
            }
            
        }

        cart.printList();
    }
    private List<Item> _items;
    public Cart() {
        // Write constructor here
       _items = new List<Item>();
    }

    public bool hasItem(string name) {
        Item? item = _items.Find(i => i.name == name);
        if (item != null) {
            return true;
        }
        return false;
    }

    public void updateItem(string name, double price) {

        Item? item = _items.Find(i => i.name == name);
        if (item != null) {
            item.price += price;
        }
    }

    public void AddItem(string name, double price) {
        Item i = new Item(name, price);
        _items.Add(i);
    }

    public bool Empty() {
        if (_items?.Count == 0) {
            return true;
        }
        return false;
    }

    public void printList() {
        _items.Sort();
        double total = 0;
        for (int i = 0; i < _items.Count; i++) {
            Console.WriteLine($"{_items[i].name,-25}  ${_items[i].price,7:F2}");
            total += _items[i].price;
        }
        Console.WriteLine($"Total = ${total:F2}");
    }


    class Item : IComparable<Item> {
        // Write Item class here
        public string name { get; set; }
        public double price { get; set; }
        public Item(string n, double p) {
            this.name = n;
            this.price = p;
        }

        public int CompareTo(Item? i) {

            if (i == null) {
                return 1;
            }
            if (this.price == i.price) {
                return string.Compare(this.name, i.name);
            }
            else if (this.price < i.price) {
                return 1;
            } 
            else {
                return -1;
            }

        }
    }
}