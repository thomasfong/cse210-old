using System;
using System.Collections.Generic;
using System.IO;

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set;}
    public string Date { get; set;}
}

class Journal
{
    private List<Entry> entries;
    public Journal()
    {
        entries = new List<Entry>();
    }

    public void AddEntry(string prompt, string response, string date )
    {
        Entry entry = new Entry
        {
            Prompt = prompt,
            Response = response,
            Date = date
        };
        entries.Add(entry);
    }

    public void DisplayEntries()
    {
        foreach (Entry entry in entries)
        {
            Console.WriteLine($"Date: {entry.Date}");
            Console.WriteLine($"Prompt: {entry.Prompt}");
            Console.WriteLine($"Response: {entry.Response}");
            Console.WriteLine();
        }
    }


    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in entries)
            {
                writer.WriteLine($"{entry.Date}|{entry.Prompt}|{entry.Response}");
            }

        }
    }

    public void LoadFromFile(string filename)
    {
        entries.Clear();

        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while((line = reader.ReadLine()) !=null)
            {
                string[] parts = line.Split('|');
                if (parts.Length ==3)
                {
                    Entry entry = new Entry
                    {
                        Date = parts[0],
                        Prompt = parts[1],
                        Response = parts[2]
                    };
                    entries.Add(entry);
                }
            }
        }
    }

class Program
{
    static void Main()
    {
        Journal journal = new Journal();

        while (true)
        {
            Console.WriteLine("Welcome to the Journal Program!");
            Console.Write("Please select one of the folling choices: ");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Load");
            Console.WriteLine("4. Save");
            Console.WriteLine("5. Quit");
            Console.WriteLine("What would you like to do?");

            string choice =Console.ReadLine();
            Console.WriteLine();

            switch (choice)
            {
                case "1":
                    string prompt = GetRandomPrompt();
                    Console.WriteLine($"Prompt: {prompt}");
                    Console.Write("Response: ");
                    string response = Console.ReadLine();
                    string date = DateTime.Now.ToString("yyyy-mm-dd");
                    journal.AddEntry(prompt, response, date);
                    Console.WriteLine("Entry added!");
                    Console.WriteLine();
                    break;

                case "2":
                    journal.DisplayEntries();
                    break;

                case "3":
                    Console.Write("Enter the filename to load: ");
                    string loadFilename = Console.ReadLine();
                    journal.LoadFromFile(loadFilename);
                    Console.WriteLine("Journal load from file!");
                    Console.WriteLine();
                    break;

                case "4":
                    Console.Write("Enter the filename to save: ");
                    string saveFilename = Console.ReadLine();
                    journal.SaveToFile(saveFilename);
                    Console.WriteLine("Journal saved to file!");
                    Console.WriteLine();
                    break;
               
                case "5":
                Console.WriteLine("Exiting program......");
                return;

            default:
                Console.WriteLine("Invalid choice. Try again.");
                Console.WriteLine();
                break;
            }
        }
    }
    static string GetRandomPrompt()
    {
        List<string>prompts = new List<string>
        {
            "Who was the most interesting person I interacted: with today?",
            "What was the best part of my day?",
            "How did  I see the hand of the Lord in my Life today",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"};
            Random random = new Random();
            int index = random.Next(prompts.Count);
            return prompts[index];
    }
}

