namespace QuestionSet
{
    public interface IProductQuestionSet<TVersionedProduct>
    {
        IQuestion[] GetQuestions();

        IValidationResultDetails Validate(TVersionedProduct product);
    }
}
