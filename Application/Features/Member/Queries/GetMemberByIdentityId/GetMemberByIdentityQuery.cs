using Application.Features.Member.Queries.Shared;
using MediatR;

namespace Application.Features.Member.Queries.GetMemberByIdentityId;

public record GetMemberByIdentityQuery(string IdentityId) : IRequest<MemberDto>;