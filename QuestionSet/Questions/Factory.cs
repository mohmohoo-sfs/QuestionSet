using QuestionSet.QuestionSpec;
using QuestionSet.Validation;
using System.Collections.Generic;

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
                var question = new Question(questionId, spec.QuestionText, spec.ValidationWarningText, spec.Statements); 
                questions.Add(question);
                if (spec.Validation != null)
                {
                    validations.Add(new Validation<TObject, TResult>(question, spec.Validation));
                }
            }

            return (questions.ToArray(), validations.ToArray());
        }
    }
}