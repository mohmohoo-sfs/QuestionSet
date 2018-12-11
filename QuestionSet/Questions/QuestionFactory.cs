using QuestionSet.QuestionSpec;
using QuestionSet.Validator;
using System;
using System.Linq;

namespace QuestionSet.Questions
{
    public class QuestionFactory
    {
        private int _count;

        private IQuestion[] _questions;

        public static QuestionFactory Init()
        {
            return new QuestionFactory { _count = 0, _questions = new IQuestion[0] };
        }

        public QuestionFactory YesNo(IQuestionSpecification spec)
        {
            var countPlus1 = _count + 1; 
            var questions = _questions.ToList();
            questions.Add(new YesNoQuestion(countPlus1, spec.QuestionText, spec.ValidationText));
            return new QuestionFactory { _count = countPlus1, _questions = questions.ToArray() };
        }

        public QuestionFactory FreeText(IQuestionSpecification spec)
        {
            var countPlus1 = _count + 1;
            var questions = _questions.ToList();
            questions.Add(new FreeTextQuestion(countPlus1, spec.QuestionText, spec.ValidationText));
            return new QuestionFactory { _count = countPlus1, _questions = questions.ToArray() };
        }

        public QuestionFactory SingleChoice(IQuestionSpecification spec)
        {
            var countPlus1 = _count + 1;
            var question = new SingleChoiceQuestion(countPlus1, spec.QuestionText, spec.ValidationText, new SingleChoiceAnswerValidator());
            spec.OptionsItems
                .ToList()
                .ForEach(question.AddOption);

            var questions = _questions.ToList();
            questions.Add(question);
            return new QuestionFactory { _count = countPlus1, _questions = questions.ToArray() };
        }

        public QuestionFactory MultipleChoice(IQuestionSpecification spec)
        {
            var countPlus1 = _count + 1;
            var question = new MultiChoiceQuestion(countPlus1, spec.QuestionText, spec.ValidationText, new MultipleChoiceAnswerValidator());

            spec.OptionsItems
                .ToList()
                .ForEach(question.Add);
            var questions = _questions.ToList();
            questions.Add(question);

            return new QuestionFactory { _count = countPlus1, _questions = questions.ToArray() };
        }

        public IQuestion[] Completed()
        {
            return _questions;
        }
    }
}