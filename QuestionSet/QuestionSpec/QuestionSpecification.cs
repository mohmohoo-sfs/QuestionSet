using System;
using System.Linq;

namespace QuestionSet.QuestionSpec
{
    public class QuestionSpecification<TValidatedObject, TValidationResult>
        : IQuestionTextContainer<TValidatedObject, TValidationResult>
        , IValidationTextContainer<TValidatedObject, TValidationResult>
        , IQuestionSpecification<TValidatedObject, TValidationResult>
    {
        private QuestionSpecification() { }

        public string QuestionText { get; private set; }

        public string ValidationWarningText { get; private set; }

        public string[] Statements { get; private set; }

        public Func<TValidatedObject, TValidationResult> Validation { get; private set; }

        public static IQuestionTextContainer<TValidatedObject, TValidationResult> Question(string text)
        {
            return new QuestionSpecification<TValidatedObject, TValidationResult>
            {
                QuestionText = text,
                ValidationWarningText = string.Empty
            };
        }

        public IValidationTextContainer<TValidatedObject, TValidationResult> ValidationWarning(string desc, Func<TValidatedObject, TValidationResult> validation)
        {
            return new QuestionSpecification<TValidatedObject, TValidationResult>
            {
                QuestionText = QuestionText,
                ValidationWarningText = desc,
                Validation = Validation
            };
        }

        public IValidationTextContainer<TValidatedObject, TValidationResult> NoValidationWarning()
        {
            return new QuestionSpecification<TValidatedObject, TValidationResult>
            {
                QuestionText = QuestionText,
                ValidationWarningText = string.Empty
            };
        }

        public IQuestionSpecification<TValidatedObject, TValidationResult> AvailableStatements(params string[] statements)
        {
            if (statements == null || statements.Count() == 0)
            {
                throw new ArgumentException("At least one selectable option must be provided", "options");
            }
            return new QuestionSpecification<TValidatedObject, TValidationResult>
            {
                QuestionText = QuestionText,
                ValidationWarningText = ValidationWarningText,
                Statements = statements
            };
        }

        public IQuestionSpecification<TValidatedObject, TValidationResult> NoAdditionalStatement()
        {
            return new QuestionSpecification<TValidatedObject, TValidationResult>
            {
                QuestionText = QuestionText,
                ValidationWarningText = ValidationWarningText,
                Statements = new string[] { }
            };

        }
    }
}
