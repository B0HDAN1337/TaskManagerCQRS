using MediatR;
using Microsoft.AspNetCore.Mvc;
using CQRS.Application.Commands;
using CQRS.Application.Queries;

namespace CQRS.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TaskController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllTasksQuery());
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] string title)
        {
            var result = await _mediator.Send(new AddTaskCommand(title));
            return Ok(result);
        }

        [HttpPut("{id}/complete")]
        public async Task<IActionResult> Complete(Guid id)
        {
            var success = await _mediator.Send(new CompleteTaskCommand(id));
            if (success)
            {
                return Ok("Task completed");
            } else
            {
                return NotFound();
            }
        }
    }
}