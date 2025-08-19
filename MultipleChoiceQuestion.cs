// MultipleChoiceQuestion.cs
public class MultipleChoiceQuestion : Question
{
    public string[] Options { get; private set; }
    private int _correctOptionIndex;

    public MultipleChoiceQuestion(string text, string[] options, int correctOptionIndex) : base(text)
    {
        Options = options;
        _correctOptionIndex = correctOptionIndex;
    }

    public override bool CheckAnswer(string answer)
    {
        if (int.TryParse(answer, out int userChoice))
        {
            return userChoice - 1 == _correctOptionIndex;
        }
        return false;
    }

    public override string GetCorrectAnswer()
    {
        return Options[_correctOptionIndex];
    }
}