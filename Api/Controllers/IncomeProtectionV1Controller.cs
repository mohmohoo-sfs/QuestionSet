using Microsoft.AspNetCore.Mvc;
using QuestionSet;
using QuestionSet.Products.v1;

namespace Api.Controllers
{
    [Route("questions/{version:apiVersion}/incomeprotection")]
    public class IncomeProtectionV1Controller : ProductControllerBase
    {
        public IncomeProtectionV1Controller()
            : base(new IncomeProtectionV1QuestionSet())
        {
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IQuestion[]))]
        public override IActionResult Get()
        {
            return base.Get();
        }
    }
}