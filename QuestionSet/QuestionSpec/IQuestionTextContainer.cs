namespace QuestionSet.QuestionSpec
{
    public interface IQuestionTextContainer
    {
        IValidationTextContainer Validation(string desc);
        IValidationTextContainer NoValidation();
    }
}
