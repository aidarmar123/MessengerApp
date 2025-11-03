using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Chats.Command.CreateChat;

namespace Microsoft.Extensions.DependencyInjection.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateChatCommand command)
    {
        var chatId = await _mediator.Send(command);
        return Ok(chatId);
    }
}
