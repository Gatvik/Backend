﻿using Application.Features.GymEnrollment.Commands.DeleteEnrollment;
using Application.Features.GymEnrollment.Commands.SendRequestToEnroll;
using Application.Features.GymEnrollment.Queries.GetAllEnrollments;
using Application.Features.GymEnrollment.Queries.GetEnrollmentsByMember;
using Application.Features.GymEnrollment.Queries.Shared;
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
    
    [HttpGet("getAll")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<List<GymEnrollmentDto>>> GetAllEnrollments()
    {
        var result = await _mediator.Send(new GetAllEnrollmentsQuery());
        return Ok(result);
    }
    
    [HttpGet("getAllByMember")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<List<GymEnrollmentDto>>> GetAllEnrollmentsByMember()
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
        await _mediator.Send(new DeleteEnrollmentCommand { GymEnrollmentId = id });
        return NoContent();
    }
}