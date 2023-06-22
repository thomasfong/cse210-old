using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your first name? ");
        string FristName = Console.ReadLine();

        Console.Write("What is your last name? ");
        string LastName = Console.ReadLine();

        Console.WriteLine($"Your name is {LastName}, {FristName} {LastName}.");

        
    }
}