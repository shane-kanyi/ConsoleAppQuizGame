// TrueOrFalseQuestion.cs
public class TrueOrFalseQuestion : Question
{
    private bool _correctAnswer;

    public TrueOrFalseQuestion(string text, bool correctAnswer) : base(text)
    {
        _correctAnswer = correctAnswer;
    }

    public override bool CheckAnswer(string answer)
    {
        string formattedAnswer = answer.ToLower();
        if (formattedAnswer == "true" || formattedAnswer == "t")
        {
            return _correctAnswer == true;
        }
        if (formattedAnswer == "false" || formattedAnswer == "f")
        {
            return _correctAnswer == false;
        }
        return false;
    }

    public override string GetCorrectAnswer()
    {
        return _correctAnswer.ToString();
    }
}