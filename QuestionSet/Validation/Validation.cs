using System;

namespace QuestionSet.Validation
{
    public class Validation<TObject, TResult>
        : IValidation<TObject, TResult>
    {
        public IQuestion Question { get; }

        public Func<TObject, TResult> ValidationCheck { get; }

        public Validation(IQuestion question, Func<TObject, TResult> check)
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
