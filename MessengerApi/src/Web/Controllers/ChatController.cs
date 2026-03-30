using MessengerApi.Application.Chats.Commands.CreateChat;
using Microsoft.AspNetCore.Mvc;

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
