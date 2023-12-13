using Application.Features.Member.Queries.Shared;
using MediatR;

namespace Application.Features.Member.Queries.GetAll;

public class GetAllMembersQuery : IRequest<List<MemberDto>>
{
    
}