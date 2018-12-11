using QuestionSet.QuestionSpec;
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

        public QuestionFactory Create(IQuestionSpecification spec)
        {
            var countPlus1 = _count + 1; 
            var questions = _questions.ToList();
            questions.Add(new Question(countPlus1, spec.QuestionText, spec.ValidationText, spec.Statements));
            return new QuestionFactory { _count = countPlus1, _questions = questions.ToArray() };
        }

        public IQuestion[] Completed()
        {
            return _questions;
        }
    }
}