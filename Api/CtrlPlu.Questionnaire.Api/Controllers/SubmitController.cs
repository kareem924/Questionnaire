using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Api.Application.Command.AddSubmit;
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
    }
}
