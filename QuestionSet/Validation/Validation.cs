using System;

namespace QuestionSet.Validation
{
    public class Validation<TObject, TResult>
        : IValidation<TObject, TResult>
    {
        public int QuestionId { get; }

        public Func<TObject, TResult> ValidationCheck { get; }

        public Validation(int questionId, Func<TObject, TResult> check)
        {
            QuestionId = questionId;
            ValidationCheck = check;
        }

        public TResult Validate(TObject obj)
        {
            return ValidationCheck(obj);
        }
    }
}
