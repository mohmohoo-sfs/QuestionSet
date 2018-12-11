using Microsoft.AspNetCore.Mvc;
using QuestionSet;

namespace Api.Controllers
{
    public abstract class ProductControllerBase<TVersionedProduct> : Controller
    {
        protected readonly IProductQuestionSet<TVersionedProduct> _questionSet;

        public ProductControllerBase(IProductQuestionSet<TVersionedProduct> questionSet)
        {
            _questionSet = questionSet;
        }

        public virtual IActionResult Get()
        {
            var questions = _questionSet.GetQuestions();
            return Ok(questions);
        }
    }
}
