using System.Threading.Tasks;
using CtrlPlu.Questionnaire.Api.Application.Command.AddForm;
using CtrlPlu.Questionnaire.Api.Application.Command.DeleteForm;
using CtrlPlu.Questionnaire.Api.Application.Command.UpdateForm;
using CtrlPlu.Questionnaire.Api.Application.Query.GetAll;
using CtrlPlu.Questionnaire.Api.Application.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CtrlPlu.Questionnaire.Api.Controllers
{
    [Route("api/forms")]
    [ApiController]
    public class FormController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FormController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllFormsQuery query)
        {
            var timeSlot = await _mediator.Send(query);
            return Ok(timeSlot);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] GetFormByIdQuery query)
        {
            var timeSlot = await _mediator.Send(query);
            return Ok(timeSlot);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddFormCommand command)
        {
            await _mediator.Publish(command);
            return Ok(command);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateFormCommand command)

        {
            command.Id = id;
            await _mediator.Publish(command);
            return Ok(command);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(DeleteFormCommand command)
        {
            await _mediator.Publish(command);
            return Ok(command);
        }
    }
}
