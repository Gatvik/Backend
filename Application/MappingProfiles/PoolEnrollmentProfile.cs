using Application.Features.PoolEnrollment.Queries.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class PoolEnrollmentProfile : Profile
{
    public PoolEnrollmentProfile()
    {
        CreateMap<PoolEnrollmentRequest, PoolEnrollmentDto>();
    }
}