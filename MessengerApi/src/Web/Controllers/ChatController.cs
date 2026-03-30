using MessengerApi.Application.Chats.Commands.CreateChat;
using MessengerApi.Application.Chats.Dto;
using MessengerApi.Application.Chats.Queries.GetChats;
using MessengerApi.Application.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ChatController : ControllerBase
{
    private readonly IMediator _mediator;
    
    public ChatController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<ChatDto>>> GetChats([AsParameters] GetChatsQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }
    [HttpPost]
    public async Task<ActionResult<Guid>> Create([FromBody] CreateChatCommand command)
    {
        var chatId = await _mediator.Send(command);
        return Ok(chatId);
    }
}
