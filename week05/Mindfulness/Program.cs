using System;
using System.Collections.Generic;
using System.Threading;

abstract class MindfulnessActivity
{
    private int _duration;
    private string _name;
    private string _description;

    public void SetActivityInfo(string name, string description)
    {
        _name = name;
        _description = description;
    }

    public void DisplayStartMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine(_description);
        Console.Write("Enter the duration in seconds: ");
        _duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    public void DisplayEndMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        ShowSpinner(2);
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    public void ShowSpinner(int seconds)
    {
        string[] spinner = { "|", "/", "-", "\\" };
        DateTime end = DateTime.Now.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < end)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
    }

    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write($"{i} ");
            Thread.Sleep(1000);
            Console.Write("\b\b");
        }
        Console.WriteLine();
    }

    public int GetDuration()
    {
        return _duration;
    }

    public abstract void Run();
}

class BreathingActivity : MindfulnessActivity
{
    public override void Run()
    {
        SetActivityInfo("Breathing Activity", 
            "This activity will help you relax by guiding you through slow breathing.\nClear your mind and focus on your breathing.");

        DisplayStartMessage();
        int seconds = GetDuration();
        int cycleTime = 6;

        while (seconds > 0)
        {
            Console.Write("Breathe in... ");
            ShowCountdown(3);
            Console.Write("Now breathe out... ");
            ShowCountdown(3);
            seconds -= cycleTime;
        }

        DisplayEndMessage();
    }
}

class ReflectionActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> questions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public override void Run()
    {
        SetActivityInfo("Reflection Activity",
            "This activity will help you reflect on times when you have shown strength and resilience.\nThis will help you recognize the power you have inside yourself.");

        DisplayStartMessage();

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine();
        Console.WriteLine(prompt);
        ShowSpinner(3);

        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());
        while (DateTime.Now < endTime)
        {
            string question = questions[rand.Next(questions.Count)];
            Console.WriteLine();
            Console.WriteLine(question);
            ShowSpinner(5);
        }

        DisplayEndMessage();
    }
}

class ListingActivity : MindfulnessActivity
{
    private List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    public override void Run()
    {
        SetActivityInfo("Listing Activity",
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");

        DisplayStartMessage();

        Random rand = new Random();
        string prompt = prompts[rand.Next(prompts.Count)];
        Console.WriteLine();
        Console.WriteLine(prompt);
        Console.WriteLine("You will have a moment to start thinking...");
        ShowCountdown(5);

        Console.WriteLine("Start listing. Press Enter after each item:");

        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(GetDuration());

        while (DateTime.Now < endTime)
        {
            if (Console.KeyAvailable)
            {
                string input = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                }
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {items.Count} items.");
        DisplayEndMessage();
    }
}

class Program
{
    static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("1. Start Breathing Activity");
            Console.WriteLine("2. Start Reflection Activity");
            Console.WriteLine("3. Start Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select an option: ");

            string choice = Console.ReadLine();

            MindfulnessActivity activity = null;

            switch (choice)
            {
                case "1":
                    activity = new BreathingActivity();
                    break;
                case "2":
                    activity = new ReflectionActivity();
                    break;
                case "3":
                    activity = new ListingActivity();
                    break;
                case "4":
                    running = false;
                    Console.WriteLine("Thank you for using the Mindfulness Program.");
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    Thread.Sleep(1000);
                    continue;
            }

            activity.Run();
        }
    }
}
