namespace QuestionSet.QuestionSpec
{
    public interface IQuestionTextContainer
    {
        IValidationTextContainer ValidationRequired(string desc);
        IValidationTextContainer ValidationNotRequired();
    }
}