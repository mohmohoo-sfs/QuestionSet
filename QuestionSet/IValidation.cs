using System;

namespace QuestionSet
{
    public interface IValidation<TObject, TResult>
    {
        IQuestion Question { get; }

        Func<TObject, TResult> ValidationCheck { get; }

        TResult Validate(TObject obj);
    }
}
