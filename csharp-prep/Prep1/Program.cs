using System;

class Program
{
    static void Main(string[] args)
    {
        //Ask the user for their name.
        Console.WriteLine("What is your first name?");
        string frist = Console.ReadLine();

        Console.WriteLine("What is your last name?");
        string last = Console.ReadLine();

        Console.WriteLine($"Your name is {last}, {frist} {last}.");
    }
}