using Application.Contracts.Identity;
using Application.Features.Authentication.Commands.Login;
using Application.Features.Authentication.Commands.Register;
using Application.Features.Authentication.Commands.ValidateToken;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthenticationController : ControllerBase
{
    private readonly IMediator _mediator;

    public AuthenticationController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost("login")]
    public async Task<ActionResult<LoginResponse>> Login(LoginCommand request)
    {
        return Ok(await _mediator.Send(request));
    }
    
    [HttpPost("register")]
    public async Task<ActionResult<RegistrationResponse>> Register(RegistrationCommand command)
    {
        return Ok(await _mediator.Send(command));
    }
    
    [HttpPost("validateToken")]
    public ActionResult<ValidateTokenResponse> ValidateToken(ValidateTokenCommand command)
    {
        return Ok(_mediator.Send(command));
    }
}