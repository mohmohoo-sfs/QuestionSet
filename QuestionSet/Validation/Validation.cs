using System;

namespace QuestionSet.Validation
{
    public class Validation<TObject, TResult>
        : IValidation<TObject, TResult>
    {
        public string Description { get; }

        public Func<TObject, TResult> ValidationCheck { get; }

        public Validation(string description, Func<TObject, TResult> check)
        {
            Description = description;
            ValidationCheck = check;
        }

        public TResult Validate(TObject obj)
        {
            return ValidationCheck(obj);
        }
    }
}
