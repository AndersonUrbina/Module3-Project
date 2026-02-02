using System;
using System.Collections.Generic;

namespace GradebookApp
{
    internal static class Program
    {
        public static void Main()
        {
            // Instantiate an instance of Gradebook
            var book = new Gradebook();

            Console.WriteLine("=== Gradebook Utility ===");

            bool running = true;

            // While loop to handle user input continuously until they choose to exit
            while (running)
            {
                Console.WriteLine("\nMenu");
                Console.WriteLine("1. Add Grade");
                Console.WriteLine("2. View Summary");
                Console.WriteLine("3. Clear all Grades");
                Console.WriteLine("4. Exit");
                Console.Write("Choose: ");

                // String choice from user
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddGrades(book);
                        break;
                    case "2":
                        ShowSummary(book);
                        break;
                    case "3":
                        book.Clear();
                        break;
                    case "4":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid Option. Please try again.");
                        break;
                }
            }
        }

        // Method to add grades from user input into the gradebook
        private static void AddGrades(Gradebook book)
        {
            // Get user input (reject empty strings)
            Console.Write("Enter grades separated by space: ");
            string? input = Console.ReadLine();
            if (string.IsNullOrEmpty(input)) return;

            // foreach to create a list from user input
            var grades = new List<double>();
            foreach (var part in input.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            {
                if (double.TryParse(part, out double g))
                    grades.Add(g);
                else
                    Console.WriteLine($"'{part}' is not a valid number");
            }

            // validate and add grades to list
            try
            {
               book.AddGrade(grades);
                Console.WriteLine($"{grades.Count} grade(s) added.");
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        //Method to print a Grade summary
        private static void ShowSummary(Gradebook book)
        {
            Console.WriteLine("\n--- Grade Summary ---");
            Console.WriteLine($"Grades Entered: {book.GetCount()}");
            Console.WriteLine($"Highest Grade: {book.GetHighest():F2}");
            Console.WriteLine($"Lowest Grade: {book.GetLowest():F2}");
            Console.WriteLine($"Average Grade: {book.GetAverage():F2}");
        }
    }
}