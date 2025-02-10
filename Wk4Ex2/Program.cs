using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wk4Ex2
{
    class GradeCalculator
    {
        static void Main()
        {
            try
            {
                Console.WriteLine("Student Final Grade Calculator");

                // Get number of assignments
                int assignmentCount = GetAssignmentCount();

                // Get user input for each category
                double assignmentsGrade = GetGrade("assignment", assignmentCount);
                double midtermGrade = GetGrade("midterm exam", 1);
                double finalExamGrade = GetGrade("final exam", 1);

                // Calculate final grade
                double finalGrade = CalculateFinalGrade(assignmentsGrade, midtermGrade, finalExamGrade);

                // Display final grade
                Console.WriteLine($"\nFinal Grade: {finalGrade:F2}%");
                Console.WriteLine(DetermineLetterGrade(finalGrade));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }

        // Method to get the number of assignments
        static int GetAssignmentCount()
        {
            while (true)
            {
                try
                {
                    Console.Write("Enter the number of assignments: ");
                    int count = int.Parse(Console.ReadLine());

                    if (count > 0)
                        return count;
                    else
                        Console.WriteLine("Error: Please enter a positive integer.");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: Invalid input! Please enter a valid integer.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                }
            }
        }

        // Method to get and validate user input for grades
        static double GetGrade(string category, int count)
        {
            double totalScore = 0;

            for (int i = 1; i <= count; i++)
            {
                while (true)
                {
                    try
                    {
                        Console.Write($"Enter score for {category} {i} (0-100): ");
                        double score = double.Parse(Console.ReadLine());

                        if (score >= 0 && score <= 100)
                        {
                            totalScore += score;
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Error: Score must be between 0 and 100.");
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Error: Invalid input! Please enter a valid number.");
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Unexpected error: {ex.Message}");
                    }
                }
            }

            return totalScore / count; // Return the average score for the category
        }

        // Method to calculate the final grade based on weighted average
        static double CalculateFinalGrade(double assignments, double midterm, double finalExam)
        {
            return (assignments * 0.4) + (midterm * 0.3) + (finalExam * 0.3);
        }

        // Method to determine the letter grade
        static string DetermineLetterGrade(double finalGrade)
        {
            if (finalGrade >= 90) return "Letter Grade: A (Excellent Work!)";
            if (finalGrade >= 80) return "Letter Grade: B (Good Job!)";
            if (finalGrade >= 70) return "Letter Grade: C (Satisfactory)";
            if (finalGrade >= 60) return "Letter Grade: D (Needs Improvement)";
            return "Letter Grade: F (Fail)";
        }
    }

}
