namespace QuestionSet.QuestionSpec
{
    public interface IValidationTextContainer<TValidatedObject, TValidationResult>
    {
        IQuestionSpecification<TValidatedObject, TValidationResult> AvailableStatements(params string[] choices);
        IQuestionSpecification<TValidatedObject, TValidationResult> NoAdditionalStatement();
    }
}
