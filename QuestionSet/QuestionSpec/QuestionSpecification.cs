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

        public IAnswerOptionItem[] OptionsItems { get; private set; }

        public static IQuestionTextContainer Text(string text)
        {
            return new QuestionSpecification
            {
                QuestionText = text,
                ValidationText = string.Empty
            };
        }

        public IValidationTextContainer Validation(string desc)
        {
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = desc
            };
        }

        public IValidationTextContainer NoValidation()
        {
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = string.Empty
            };
        }

        public IQuestionSpecification Options(params string[] options)
        {
            if (options == null || options.Count() == 0)
            {
                throw new ArgumentException("At least one selectable option must be provided", "options");
            }
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = ValidationText,
                OptionsItems = options
                    .Select((c, index) => new AnswerOptionItem { Id = ++index, Text = c })
                    .ToArray()
            };
        }

        public IQuestionSpecification YesNoOption()
        {
            return new QuestionSpecification
            {
                QuestionText = QuestionText,
                ValidationText = ValidationText,
                OptionsItems = new[] 
                {
                    new AnswerOptionItem { Id = 1, Text = "Yes" },
                    new AnswerOptionItem { Id = 2, Text = "No" }
                }
            };

        }
    }
}
