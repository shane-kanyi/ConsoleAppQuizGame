// Question.cs
public abstract class Question
{
    // Encapsulation: Using properties with private setters for controlled access
    public string Text { get; protected set; }

    // Constructor
    protected Question(string text)
    {
        Text = text;
    }

    // Abstraction: Abstract methods to be implemented by derived classes
    public abstract bool CheckAnswer(string answer);
    public abstract string GetCorrectAnswer();
}