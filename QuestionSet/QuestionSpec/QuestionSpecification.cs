using System;
using System.Linq;

namespace QuestionSet.QuestionSpec
{
    public class QuestionSpecification
        : IQuestionTextContainer
        , IValidationTextContainer
        , IQuestionSpecification
    {
        private QuestionSpecification() { }

        public string QuestionText { get; private set; }

        public string ValidationText { get; private set; }

        public string[] Statements { get; private set; }

        public static IQuestionTextContainer Text(string text)
        {
            return new QuestionSpecification
            {
                QuestionText = text,
                ValidationText = string.Empty
            };
        }

        public IValidationTextContainer ValidationWarning(string desc)
        {
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = desc
            };
        }

        public IValidationTextContainer NoValidationWarning()
        {
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = string.Empty
            };
        }

        public IQuestionSpecification AvailableStatements(params string[] statements)
        {
            if (statements == null || statements.Count() == 0)
            {
                throw new ArgumentException("At least one selectable option must be provided", "options");
            }
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = ValidationText,
                Statements = statements
            };
        }

        public IQuestionSpecification NoAdditionalStatement()
        {
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = ValidationText,
                Statements = new string[] { }
            };

        }
    }
}
