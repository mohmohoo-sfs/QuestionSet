namespace QuestionSet.QuestionSpec
{
    public interface IQuestionTextContainer
    {
        IValidationTextContainer ValidationWarning(string desc);
        IValidationTextContainer NoValidationWarning();
    }
}
