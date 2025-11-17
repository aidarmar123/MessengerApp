
using MessengerApi.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Messages.Command.SendMessage;
using Microsoft.Extensions.DependencyInjection.Messages.Queries.GetMessages;

namespace Microsoft.Extensions.DependencyInjection.Controllers;


[ApiController]
[Route("api/[controller]")]
[Authorize]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("{chatid:guid}")]
    public async Task<ActionResult<List<Message>>> GetByChatId(Guid chatid)
    {
        var messages = await _mediator.Send(new GetMessagesQuery(chatid));
        return Ok(messages);
    }
    
    [HttpPost]
    public async Task<ActionResult<Guid>> Send([FromBody] SendMessageCommand command)
    {
        var messageId = await _mediator.Send(command);
        return Ok(messageId);
    }
}
