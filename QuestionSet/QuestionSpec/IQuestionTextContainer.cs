using System;

namespace QuestionSet.QuestionSpec
{
    public interface IQuestionTextContainer<TValidatedObject, TValidationResult>
    {
        IValidationTextContainer<TValidatedObject, TValidationResult> ValidationWarning(string desc, Func<TValidatedObject, TValidationResult> validation);
        IValidationTextContainer<TValidatedObject, TValidationResult> NoValidationWarning();
    }
}