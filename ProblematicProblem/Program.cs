using System;
using System.Collections.Generic;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static bool YesOrNo(string input)
        {
            switch (input.ToLower())
            {
                case "yes" or "y":
                    return true;
                case "no" or "n":
                    return false;
                default:
                    Console.WriteLine("I'm not sure what you said, so I'm going to take it as a no and move on.");
                    return false;
            }
        }
        static List<string> activities = new List<string>() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };

        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? yes/no: ");
            bool cont = YesOrNo(Console.ReadLine());
            if (cont)
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                bool isInt = int.TryParse(Console.ReadLine(), out int userAge); ;
                while (!isInt)
                {
                    Console.WriteLine("I'm sorry, I don't understand. Please try again:");
                    isInt = int.TryParse(Console.ReadLine(), out userAge);
                }
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Yes/No: ");
                bool seeList = YesOrNo(Console.ReadLine());
                if (!seeList)
                {
                    Console.WriteLine();
                    Console.WriteLine("We like a bit of mystery, I see!");
                }
                else
                {
                    Console.WriteLine("Here is the list of activities:");
                    foreach (string activity in activities)
                    {
                        Console.WriteLine($"- {activity}");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? yes/no: ");
                    bool addToList = YesOrNo(Console.ReadLine());
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        Console.WriteLine("OK, here is the updated list:");
                        foreach (string activity in activities)
                        {
                            Console.WriteLine($"- {activity}");
                            Thread.Sleep(500);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? yes/no: ");
                        addToList = YesOrNo(Console.ReadLine());
                        Console.WriteLine();
                    }
                }
                Console.Write("OK, press any key to receive your random activity.");
                Console.ReadLine();

                while (cont)
                {
                    Console.WriteLine();
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 5; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.WriteLine();

                    Random rng = new Random();
                    int randomNumber = rng.Next(activities.Count);
                    string randomActivity = activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! We generated {randomActivity} but it looks like you are too young.");
                        if (activities.Count > 0)
                        {
                            Console.WriteLine("Let's pick something else.");
                            activities.Remove(activities[randomNumber]);
                            randomNumber = rng.Next(activities.Count);
                            randomActivity = activities[randomNumber];
                        }
                        else Console.WriteLine("I'm sorry, it looks like we're all out of ideas!");
                    }
                    else
                    {
                        Console.WriteLine($"{userName}, your random activity is: {randomActivity}!");
                        Console.Write("Would you like to generate another activity instead? (yes/no): ");
                        cont = YesOrNo(Console.ReadLine());
                        if (cont)
                        {
                            if (activities.Count == 0)
                            {
                                Console.WriteLine("I'm sorry, it looks like we're all out of ideas!");
                            }
                            else
                            {
                                activities.Remove(activities[randomNumber]);
                                randomNumber = rng.Next(activities.Count);
                                randomActivity = activities[randomNumber];
                            }
                        }
                        else
                        {
                            Console.WriteLine();
                            Console.WriteLine($"Bye {userName}! Enjoy the {randomActivity}!");
                        }
                    }
                }
            }
            else Console.WriteLine("OK, have a boring day!");
        }
    }
}