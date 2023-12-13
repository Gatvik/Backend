using Application.Features.Authentication.Commands.ChangeEmail;
using Application.Features.Authentication.Commands.ChangePassword;
using Application.Features.Member.Commands.DeleteMemberById;
using Application.Features.Member.Commands.EnrollMemberToGym;
using Application.Features.Member.Commands.LeaveFromGym;
using Application.Features.Member.Commands.UpdateMember;
using Application.Features.Member.Queries.GetMemberByCurrentUser;
using Application.Features.Member.Queries.GetMemberByIdentityId;
using Application.Features.Member.Queries.Shared;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[ApiController]
[Route("api/v1/members")]
[Authorize]
public class MembersController : ControllerBase
{
    private readonly IMediator _mediator;

    public MembersController(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{identityId}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<MemberDto>> GetMemberByIdentityId(string identityId)
    {
        var member = await _mediator.Send(new GetMemberByIdentityQuery(identityId));
        return Ok(member);
    }
    
    [HttpGet("getByCurrentUser")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult<MemberDto>> GetMemberByCurrentUser()
    {
        var member = await _mediator.Send(new GetMemberByCurrentUserQuery());
        return Ok(member);
    }

    [HttpDelete("deleteUser/{identityId}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> DeleteUserById(string identityId)
    {
        await _mediator.Send(new DeleteMemberByIdCommand(identityId));
        return NoContent();
    }

    [HttpPut("changeEmail")]
    public async Task<ActionResult> ChangeEmail(ChangeEmailCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPut("changePassword")]
    public async Task<ActionResult> ChangePassword(ChangePasswordCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpPost("enrollToGym")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult> EnrollMemberToGym(EnrollMemberToGymCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete("leaveFromGym")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult> LeaveFromGym()
    {
        await _mediator.Send(new LeaveFromGymCommand());
        return NoContent();
    }
    
    [HttpPut("updateMember")]
    [Authorize(Roles = "Member")]
    public async Task<ActionResult> UpdateMember(UpdateMemberCommand command)
    {
        await _mediator.Send(command);
        return NoContent();
    }
}