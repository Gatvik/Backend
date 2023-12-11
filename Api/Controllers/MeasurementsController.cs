using Application.Features.Measurement.Commands.CreateMeasurement;
using Application.Features.Measurement.Commands.DeleteMeasurement;
using Application.Features.Measurement.Commands.DeleteMeasurementForMember;
using Application.Features.Measurement.Queries.GetMeasurementById;
using Application.Features.Measurement.Queries.GetMeasurementsByMember;
using Application.Features.Measurement.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/measurements")]
[Authorize]
public class MeasurementsController : ControllerBase
{
    private readonly IMediator _mediator;

    public MeasurementsController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("getById/{id:int}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<MeasurementDto>> GetById(int id)
    {
        var measurement = await _mediator.Send(new GetMeasurementByIdQuery(id));

        return Ok(measurement);
    }
    
    [HttpGet("getAllByMember")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<List<MeasurementDto>>> GetAllByMember()
    {
        List<MeasurementDto> measurements = await _mediator.Send(new GetMeasurementsByMemberQuery());

        return Ok(measurements);
    }
    
    [HttpPost]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<int>> Create([FromBody] CreateMeasurementCommand command)
    {
        int id = await _mediator.Send(command);

        return CreatedAtAction(nameof(Create), new { id });
    }
    
    [HttpDelete("deleteById/{id:int}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> DeleteById(int id)
    {
        await _mediator.Send(new DeleteMeasurementCommand(id));

        return NoContent();
    }
    
    [HttpDelete("deleteByIdForMember/{id:int}")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult> DeleteByIdForMember(int id)
    {
        await _mediator.Send(new DeleteMeasurementForMemberCommand(id));

        return NoContent();
    }
}