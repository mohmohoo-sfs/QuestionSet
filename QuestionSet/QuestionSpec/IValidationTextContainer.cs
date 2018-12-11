namespace QuestionSet.QuestionSpec
{
    public interface IValidationTextContainer
    {
        IQuestionSpecification Options(params string[] choices);
        IQuestionSpecification YesNoOption();
    }
}
