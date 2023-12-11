using Application.Features.GymEnrollment.Commands.DeleteEnrollment;
using Application.Features.GymEnrollment.Commands.SendRequestToEnroll;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/gymEnrollments")]
[Authorize]
public class GymEnrollmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public GymEnrollmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpPost("sendEnrollmentRequest")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<int>> SendEnrollmentRequest(SendRequestToEnrollCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(SendEnrollmentRequest), new { enrollmentId = result });
    }
    
    [HttpDelete("deleteEnrollment")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<Unit>> DeleteEnrollment(DeleteEnrollmentCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}