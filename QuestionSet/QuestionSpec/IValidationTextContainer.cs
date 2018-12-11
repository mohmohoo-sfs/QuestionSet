namespace QuestionSet.QuestionSpec
{
    public interface IValidationTextContainer
    {
        IQuestionSpecification AvailableStatements(params string[] choices);
        IQuestionSpecification NoAdditionalStatement();
    }
}
