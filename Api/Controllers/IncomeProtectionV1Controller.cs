using Microsoft.AspNetCore.Mvc;
using QuestionSet;
using QuestionSet.Products.v1;
using QuestionSet.Validation;

namespace Api.Controllers
{
    [Route("questions/{version:apiVersion}/incomeprotection")]
    public class IncomeProtectionV1Controller : ProductControllerBase<IncomeProtectionV1>
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

        [HttpPost("validate")]
        [ProducesResponseType(200, Type = typeof(IValidation<IncomeProtectionV1, ValidationResult>[]))]
        public IActionResult Validate([FromBody]IncomeProtectionV1 model)
        {
            var validationResultDetails = _questionSet.Validate(model);
            return Ok(validationResultDetails);
        }
    }
}