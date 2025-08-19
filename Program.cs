// Program.cs
using System;
using System.Collections.Generic;
using System.Diagnostics; // Required for Stopwatch

class Program
{
    // Use a list to store a variable number of questions
    static List<Question> quizQuestions = new List<Question>();

    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the Geography Quiz Game!");

        while (true)
        {
            Console.WriteLine("\n--- Main Menu ---");
            Console.WriteLine("1. Create a game (Add/Edit/Delete Questions)");
            Console.WriteLine("2. Play game");
            Console.WriteLine("3. Exit");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateGameMode();
                    break;
                case "2":
                    PlayGameMode();
                    break;
                case "3":
                    Console.WriteLine("Thank you for playing!");
                    return;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    #region Mode 1: Create a Game

    static void CreateGameMode()
    {
        while (true)
        {
            Console.WriteLine("\n--- Create Mode ---");
            Console.WriteLine("1. Add a new question");
            Console.WriteLine("2. Edit an existing question");
            Console.WriteLine("3. Delete an existing question");
            Console.WriteLine("4. View all questions");
            Console.WriteLine("5. Return to Main Menu");
            Console.Write("Choose an option: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    AddQuestion();
                    break;
                case "2":
                    EditQuestion();
                    break;
                case "3":
                    DeleteQuestion();
                    break;
                case "4":
                    ViewAllQuestions();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Invalid option.");
                    break;
            }
        }
    }

    static void AddQuestion()
    {
        Console.WriteLine("\n--- Add New Question ---");
        Console.WriteLine("Select question type:");
        Console.WriteLine("1. Multiple Choice");
        Console.WriteLine("2. Open-Ended");
        Console.WriteLine("3. True/False");
        Console.Write("Enter choice: ");
        string type = Console.ReadLine();

        Console.Write("Enter the question text: ");
        string text = Console.ReadLine();

        switch (type)
        {
            case "1":
                string[] options = new string[4];
                Console.WriteLine("Enter four possible answers:");
                for (int i = 0; i < 4; i++)
                {
                    Console.Write($"Option {i + 1}: ");
                    options[i] = Console.ReadLine();
                }
                Console.Write("Which option is correct? (1-4): ");
                int correctIndex = int.Parse(Console.ReadLine()) - 1;
                quizQuestions.Add(new MultipleChoiceQuestion(text, options, correctIndex));
                break;
            case "2":
                Console.Write("Enter correct answers (separated by a comma, e.g., UK,United Kingdom): ");
                string[] answers = Console.ReadLine().Split(',');
                quizQuestions.Add(new OpenEndedQuestion(text, answers));
                break;
            case "3":
                Console.Write("Is the statement true or false? (true/false): ");
                bool correctAnswer = bool.Parse(Console.ReadLine());
                quizQuestions.Add(new TrueOrFalseQuestion(text, correctAnswer));
                break;
            default:
                Console.WriteLine("Invalid question type.");
                return;
        }
        Console.WriteLine("Question added successfully!");
    }

    static void ViewAllQuestions()
    {
        Console.WriteLine("\n--- All Questions ---");
        if (quizQuestions.Count == 0)
        {
            Console.WriteLine("No questions have been added yet.");
            return;
        }

        for (int i = 0; i < quizQuestions.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {quizQuestions[i].Text}");
        }
    }

    static void DeleteQuestion()
    {
        ViewAllQuestions();
        if (quizQuestions.Count == 0) return;

        Console.Write("Enter the number of the question to delete: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= quizQuestions.Count)
        {
            quizQuestions.RemoveAt(index - 1);
            Console.WriteLine("Question deleted successfully.");
        }
        else
        {
            Console.WriteLine("Invalid question number.");
        }
    }
    
    static void EditQuestion()
    {
        ViewAllQuestions();
        if (quizQuestions.Count == 0) return;

        Console.Write("Enter the number of the question to edit: ");
        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= quizQuestions.Count)
        {
            // For simplicity, we remove the old question and add a new one.
            // A more complex implementation could edit properties in place.
            Console.WriteLine($"Editing question {index}. Please provide the new details.");
            quizQuestions.RemoveAt(index - 1);
            AddQuestion(); // Re-use the add logic
            Console.WriteLine("Question edited successfully.");
        }
        else
        {
            Console.WriteLine("Invalid question number.");
        }
    }


    #endregion

    #region Mode 2: Play Game

    static void PlayGameMode()
    {
        if (quizQuestions.Count == 0)
        {
            Console.WriteLine("\nThere are no questions to play. Please add questions in 'Create a game' mode first.");
            return;
        }

        while (true)
        {
            int score = 0;
            Stopwatch stopwatch = new Stopwatch();
            
            stopwatch.Start();

            for (int i = 0; i < quizQuestions.Count; i++)
            {
                Console.WriteLine($"\nQuestion {i + 1}: {quizQuestions[i].Text}");

                // Display options for multiple choice questions
                if (quizQuestions[i] is MultipleChoiceQuestion mcq)
                {
                    for (int j = 0; j < mcq.Options.Length; j++)
                    {
                        Console.WriteLine($"{j + 1}. {mcq.Options[j]}");
                    }
                    Console.Write("Your answer (1-4): ");
                }
                else if (quizQuestions[i] is TrueOrFalseQuestion)
                {
                    Console.Write("Your answer (true/false): ");
                }
                else // Open-ended
                {
                    Console.Write("Your answer: ");
                }

                string userAnswer = Console.ReadLine();
                if (quizQuestions[i].CheckAnswer(userAnswer))
                {
                    Console.WriteLine("Correct!");
                    score++;
                }
                else
                {
                    Console.WriteLine("Incorrect.");
                }
            }

            stopwatch.Stop();
            TimeSpan timeTaken = stopwatch.Elapsed;

            Console.WriteLine("\n--- Quiz Finished! ---");
            Console.WriteLine($"Your final score: {score} out of {quizQuestions.Count}");
            Console.WriteLine($"Time taken: {timeTaken.Minutes} minutes and {timeTaken.Seconds} seconds.");

            Console.Write("\nWould you like to see the correct answers? (yes/no): ");
            if (Console.ReadLine().ToLower() == "yes")
            {
                DisplayAllCorrectAnswers();
            }

            Console.Write("\nPlay again or return to the main menu? (play/menu): ");
            if (Console.ReadLine().ToLower() != "play")
            {
                break; // Exit the play loop and return to the main menu
            }
        }
    }
    
    static void DisplayAllCorrectAnswers()
    {
        Console.WriteLine("\n--- Correct Answers ---");
        for (int i = 0; i < quizQuestions.Count; i++)
        {
            Console.WriteLine($"Q{i + 1}: {quizQuestions[i].Text}");
            Console.WriteLine($"A: {quizQuestions[i].GetCorrectAnswer()}");
        }
    }

    #endregion
}