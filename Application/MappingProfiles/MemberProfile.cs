using Application.Features.Member.Queries.GetMemberByIdentityId;
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