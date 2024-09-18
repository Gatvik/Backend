using Application.Features.PoolEnrollment.Commands.DeleteEnrollment;
using Application.Features.PoolEnrollment.Commands.SendRequestToEnroll;
using Application.Features.PoolEnrollment.Queries.GetAllEnrollments;
using Application.Features.PoolEnrollment.Queries.GetEnrollmentsByMember;
using Application.Features.PoolEnrollment.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/poolEnrollments")]
[Authorize]
public class PoolEnrollmentsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PoolEnrollmentsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("getAll")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<List<PoolEnrollmentDto>>> GetAllEnrollments()
    {
        var result = await _mediator.Send(new GetAllEnrollmentsQuery());
        return Ok(result);
    }
    
    [HttpGet("getAllByMember")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<List<PoolEnrollmentDto>>> GetAllEnrollmentsByMember()
    {
        var result = await _mediator.Send(new GetEnrollmentsByMemberQuery());
        return Ok(result);
    }
    
    [HttpPost]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<int>> SendEnrollmentRequest(SendRequestToEnrollCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(SendEnrollmentRequest), new { enrollmentId = result });
    }
    
    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> DeleteEnrollment(int id)
    {
        await _mediator.Send(new DeleteEnrollmentCommand { PoolEnrollmentId = id });
        return NoContent();
    }
}