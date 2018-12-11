using QuestionSet.QuestionSpec;
using QuestionSet.Validation;
using System.Collections.Generic;
using System.Linq;

namespace QuestionSet.Questions
{
    public class Factory<TObject, TResult>
    {
        public static (IQuestion[], IValidation<TObject, TResult>[]) CreateQuestionWithValidations(params IQuestionSpecification<TObject, TResult>[] specs)
        {
            var idCounter = 0;
            var questions = new List<IQuestion>();
            var validations = new List<IValidation<TObject, TResult>>();

            foreach(var spec in specs)
            {
                var questionId = ++idCounter;
                questions.Add(new Question(questionId, spec.QuestionText, spec.ValidationWarningText, spec.Statements));
                if (spec.Validation != null)
                {
                    validations.Add(new Validation<TObject, TResult>(questions.Last().Id, spec.Validation));
                }
            }

            return (questions.ToArray(), validations.ToArray());
        }
    }
}