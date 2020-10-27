using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Api.Application.Command.AddSubmit;
using CtrlPlu.Questionnaire.Api.Application.Query.GetFormResults;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CtrlPlu.Questionnaire.Api.Controllers
{
    [Route("api/submit")]
    [ApiController]
    public class SubmitController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SubmitController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SubmitCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }

        [HttpGet("summary")]
        public async Task<IActionResult> GetSubmissionSummary([FromQuery] GetFormSummaryQuery query)
        {
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        //[HttpGet("answers")]
        //public async Task<IActionResult> GetSubmissionAnswers([FromQuery] GetFormAnswersQuery query)
        //{
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}

        //[HttpGet("individual")]
        //public async Task<IActionResult> GetSubmissionIndividual([FromQuery] GetFormIndividualQuery query)
        //{
        //    var result = await _mediator.Send(query);
        //    return Ok(result);
        //}
    }
}
