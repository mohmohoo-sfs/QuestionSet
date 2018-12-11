namespace QuestionSet.QuestionSpec
{
    public interface IQuestionSpecification
    {
        string QuestionText { get; }
        string ValidationText { get; }
        IAnswerOptionItem[] OptionsItems { get; }
    }
}
