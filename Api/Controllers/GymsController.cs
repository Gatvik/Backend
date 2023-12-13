using Application.Features.Gym.Commands.CreateGym;
using Application.Features.Gym.Commands.DeleteGym;
using Application.Features.Gym.Commands.UpdateGym;
using Application.Features.Gym.Queries.GetAllGyms;
using Application.Features.Gym.Queries.GetGymOfCurrentUser;
using Application.Features.Gym.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/gyms")]
[Authorize]
public class GymsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GymsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getByUser")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<GymDto>> GetUserGym()
    {
        var result = await _mediator.Send(new GetGymOfCurrentUserQuery());
        return Ok(result);
    }

    [HttpGet("getAll")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<List<GymDto>>> GetAllGyms()
    {
        var result = await _mediator.Send(new GetAllGymsQuery());
        return Ok(result);
    }

    [HttpDelete("delete/{id:int}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> DeleteGym(int id)
    {
        var result = await _mediator.Send(new DeleteGymCommand(id));
        return Ok(result);
    }

    [HttpPut("update")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> UpdateGym(UpdateGymCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPost("create")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<int>> CreateGym(CreateGymCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateGym), new { id = result });
    }
}