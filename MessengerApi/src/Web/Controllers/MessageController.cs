using MessengerApi.Application.Messages.Command.SendMessage;
using Microsoft.AspNetCore.Mvc;

namespace Microsoft.Extensions.DependencyInjection.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Send([FromBody] SendMessageCommand command)
    {
        var messageId = await _mediator.Send(command);
        return Ok(messageId);
    }
}
