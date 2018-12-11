using System;

namespace QuestionSet.QuestionSpec
{
    public interface IQuestionSpecification<TObject, TResult>
    {
        string QuestionText { get; }
        string ValidationWarningText { get; }
        string[] Statements { get; }
        Func<TObject, TResult> Validation { get; }
    }
}
