using System;

namespace QuestionSet
{
    public interface IValidation<TObject, TResult>
    {
        string Description { get; }

        Func<TObject, TResult> ValidationCheck { get; }

        TResult Validate(TObject obj);
    }
}
