using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection.Auth.Command;

namespace Microsoft.Extensions.DependencyInjection.Controllers;

[ApiController]
[Route("[controller]/[action]")]
public class AuthController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    public async Task<ActionResult<AuthDto>> AuthUser([FromBody] AuthCommand command)
    {
        var authDto = await _mediator.Send(command);
        return Ok(authDto);
    }
}
