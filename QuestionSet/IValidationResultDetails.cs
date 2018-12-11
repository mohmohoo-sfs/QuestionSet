namespace QuestionSet
{
    public interface IValidationResultDetails
    {
        string Result { get; set; }

        IQuestion[] FailedValidationQuestions { get; set; }
    }
}
