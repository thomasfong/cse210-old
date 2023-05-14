using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Prep3 World!");
    }
}

//A code tempkate for the category of things known as Person. The 
// responsibility of a Person is to hold and display personal information.
public class Person
{
    // The C# convention is to start menber variables with an underscore_
    public string _givenName = "";
    public string _familyName = "";

    // A special method, called a constructor that is invoked using the 
    // new keyword followed by the class =name and parentheses.
    public Person()
    {     
    }

    // A method that displays the person's full name as used in eastern
    // countries or <family name, given name>.
    public void ShowEasternName()
    {
        Console.WriteLine($"{_familyName}, {_givenName}");
    }

    // A method that displays the person's full name as used in western
    // countries or <given name family name>.
    public void ShowWesternName()
    {
        Console.WriteLine($"{_givenName} {_familyName}");
    }
}


