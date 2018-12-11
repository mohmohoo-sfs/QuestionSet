using System;

namespace QuestionSet.Validation
{
    public class Validator<TObject, TResult>
        : IValidation<TObject, TResult>
    {
        public IQuestion Question { get; }

        public Func<TObject, TResult> ValidationCheck { get; }

        public Validator(IQuestion question, Func<TObject, TResult> check)
        {
            Question = question;
            ValidationCheck = check;
        }

        public TResult Validate(TObject obj)
        {
            return ValidationCheck(obj);
        }
    }
}
