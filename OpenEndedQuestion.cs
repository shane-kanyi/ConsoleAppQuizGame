// OpenEndedQuestion.cs
using System.Linq;

public class OpenEndedQuestion : Question
{
    // Allows for multiple correct phrasings (e.g., "UK", "United Kingdom")
    private string[] _correctAnswers;

    public OpenEndedQuestion(string text, string[] correctAnswers) : base(text)
    {
        // Store all potential answers in lower case for case-insensitive comparison
        _correctAnswers = correctAnswers.Select(a => a.ToLower()).ToArray();
    }

    public override bool CheckAnswer(string answer)
    {
        return _correctAnswers.Contains(answer.ToLower());
    }

    public override string GetCorrectAnswer()
    {
        // Return the first answer as the primary correct one
        return _correctAnswers[0];
    }
}