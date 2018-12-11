namespace QuestionSet.Validation
{

    public class ValidationResultDetails
        : IValidationResultDetails
    {
        public string Result { get; set; }

        public IQuestion[] FailedValidationQuestions { get; set; }
    }
}
