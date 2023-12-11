using Application.Features.Member.Queries.GetMemberByIdentityId;
using Application.Features.Member.Queries.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class MemberProfile : Profile
{
    public MemberProfile()
    {
        CreateMap<Member, MemberDto>();
    }
}