namespace QuestionSet
{
    public interface IAnswer
    {
        int QuestionId { get; }

        string Value { get; }
    }
}