using Microsoft.AspNetCore.Mvc;
using QuestionSet;

namespace Api.Controllers
{
    public abstract class ProductControllerBase : Controller
    {
        private readonly IProductQuestionSet _questionSet;

        public ProductControllerBase(IProductQuestionSet questionSet)
        {
            _questionSet = questionSet;
        }

        public virtual IActionResult Get()
        {
            var questions = _questionSet.GetQuestions();
            return Ok(questions);
        }

        public virtual IActionResult Validate()
        {
            throw new System.NotImplementedException();
        }
    }
}
