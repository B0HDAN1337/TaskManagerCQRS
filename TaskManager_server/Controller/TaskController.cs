using MediatR;
using Microsoft.AspNetCore.Mvc;
using TaskManager_server.Application.Commands;
using TaskManager_server.Application.Queries;

namespace TaskManager_server.Controller
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
            }
            else
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}/delete")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var delete = await _mediator.Send(new DeleteTaskCommand(id));
            if(delete)
            {
                return Ok("Task deleted");
            } else
            {
                return NotFound();
            }
        }
    }
}