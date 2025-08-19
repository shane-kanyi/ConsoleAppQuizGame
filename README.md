
# C# Geography Quiz Game

This is a text-based quiz game on the topic of Geography, developed as a C# Console Application for the COMP1551 module. The application allows users to dynamically create a quiz by adding, editing, and deleting questions. It also features a play mode where users can answer the questions and receive a score based on their performance and the time taken.

The project is built using Object-Oriented principles, including encapsulation, abstraction, and inheritance, to create a flexible and maintainable codebase.

## Features

### Mode 1: Create a Game
- **Add Questions:** Dynamically add new questions to the quiz.
- **Multiple Question Types:** Supports three different types of questions:
  - **Multiple Choice:** A question with four options, only one of which is correct.
  - **Open-Ended:** A question where the user types the answer (supports multiple correct phrasings, like "UK" and "United Kingdom").
  - **True/False:** A statement that the user must identify as true or false.
- **Edit Questions:** Modify the text and answers of existing questions.
- **Delete Questions:** Remove questions from the quiz.
- **View Questions:** Display a list of all current questions in the quiz.

### Mode 2: Play
- **Answer Questions:** Go through the created quiz and answer each question.
- **Scoring:** Receive a final score showing the number of correctly answered questions.
- **Timing:** The game calculates and displays the total time spent answering all questions, in minutes and seconds.
- **Review Answers:** After finishing, users have the option to view the correct answers to all questions.
- **Replayability:** Users can choose to play again or exit to the main menu.

## Technology Stack
- **Language:** C#
- **Framework:** .NET 9
- **Environment:** Console Application

## Prerequisites
To run this project, you will need to have the following installed:
- .NET 8 SDK (or a later version)
- Git (for cloning the repository)

## How to Run the Application

1. **Clone the repository to your local machine:**
	```bash
	git clone https://github.com/your-username/QuizGame.git
	```

2. **Navigate to the project directory:**
	```bash
	cd QuizGame
	```

3. **Run the application using the .NET CLI:**
	```bash
	dotnet run
	```
This command will automatically compile and run the project. The game will start in your console, and you can interact with it by following the on-screen prompts.

## Project Structure

```text
QuizGame/
├── .gitignore                  # Specifies files for Git to ignore
├── Program.cs                  # Main application entry point and game logic
├── Question.cs                 # Abstract base class for all questions
├── MultipleChoiceQuestion.cs   # Derived class for multiple choice questions
├── OpenEndedQuestion.cs        # Derived class for open-ended questions
├── TrueOrFalseQuestion.cs      # Derived class for true/false questions
├── ConsoleAppQuizGame.csproj   # C# project file
└── README.md                   # This file
```