namespace QuestionSet.QuestionSpec
{
    public interface IQuestionSpecification
    {
        string QuestionText { get; }
        string ValidationText { get; }
        string[] Statements { get; }
    }
}
