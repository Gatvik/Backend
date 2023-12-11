using Application.Features.Gym.Commands.CreateGym;
using Application.Features.Gym.Queries.GetAllGyms;
using Application.Features.Gym.Queries.GetGymOfCurrentUser;
using Application.Features.Gym.Queries.Shared;
using Application.Features.GymEnrollment.Commands.DeleteEnrollment;
using Application.Features.GymEnrollment.Commands.SendRequestToEnroll;
using Application.Features.Member.Commands.EnrollMemberToGym;
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
    
    [HttpPost("create")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<int>> CreateGym(CreateGymCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateGym), new {id = result});
    }
    
    [HttpDelete("deleteEnrollment")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<Unit>> DeleteEnrollment(DeleteEnrollmentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost("sendEnrollmentRequest")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<int>> SendEnrollmentRequest(SendRequestToEnrollCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(SendEnrollmentRequest), new { enrollmentId = result });
    }
    
    [HttpGet("getByUser")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<GymDto>> GetUserGym()
    {
        var result = await _mediator.Send(new GetGymOfCurrentUserQuery());
        return Ok(result);
    }
    
    [HttpGet("getAll")]
    public async Task<ActionResult<List<GymDto>>> GetAllGyms()
    {
        var result = await _mediator.Send(new GetAllGymsQuery());
        return Ok(result);
    }
}