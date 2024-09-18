using Application.Features.Pool.Commands.CreatePool;
using Application.Features.Pool.Commands.DeletePool;
using Application.Features.Pool.Commands.UpdatePool;
using Application.Features.Pool.Queries.GetAllPools;
using Application.Features.Pool.Queries.GetPoolOfCurrentUser;
using Application.Features.Pool.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/pools")]
[Authorize]
public class PoolsController : ControllerBase
{
    private readonly IMediator _mediator;

    public PoolsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("getAll")]
    public async Task<ActionResult<List<PoolDto>>> GetAllGyms()
    {
        var result = await _mediator
            .Send(new GetAllPoolsQuery());
        return Ok(result);
    }
    
    [HttpGet("getByMember")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<PoolDto>> GetUserGym()
    {
        var result = await _mediator.Send(new GetPoolOfCurrentUserQuery());
        return Ok(result);
    }

    [HttpDelete("{id:int}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> DeleteGym(int id)
    {
        var result = await _mediator.Send(new DeletePoolCommand(id));
        return Ok(result);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> UpdateGym(UpdatePoolCommand command)
    {
        var result = await _mediator.Send(command);
        return Ok(result);
    }
    
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<int>> CreateGym(CreatePoolCommand command)
    {
        var result = await _mediator.Send(command);
        return CreatedAtAction(nameof(CreateGym), new { id = result });
    }
}