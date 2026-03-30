using MessengerApi.Application.Chats.Dto;
using MessengerApi.Application.Chats.Queries.GetChats;
using MessengerApi.Application.Common.Models;
using MessengerApi.Application.Messages.Command.SendMessage;
using MessengerApi.Application.Messages.Dto;
using MessengerApi.Application.Messages.Queries.GetMessagesQuery;
using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;


[ApiController]
[Route("api/[controller]")]
public class MessageController : ControllerBase
{
    private readonly IMediator _mediator;

    public MessageController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<MessageDto>>> GetMessage([FromQuery] GetMessagesQuery query)
    {
        var result = await _mediator.Send(query);
        return Ok(result);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> Send([FromBody] SendMessageCommand command)
    {
        var messageId = await _mediator.Send(command);
        return Ok(messageId);
    }
  
}
