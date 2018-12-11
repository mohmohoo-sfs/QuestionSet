using System;

namespace QuestionSet
{
    public interface IValidation<TObject, TResult>
    {
        int QuestionId { get; }

        Func<TObject, TResult> ValidationCheck { get; }

        TResult Validate(TObject obj);
    }
}
