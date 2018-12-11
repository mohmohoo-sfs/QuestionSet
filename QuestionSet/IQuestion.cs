namespace QuestionSet
{
    public interface IQuestion
    {
        int Id { get; }

        string Type { get; }

        string Text { get; }

        string ValidationDescription { get; }
    }
}
