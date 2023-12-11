using Application.Features.GymEnrollment.Commands.SendRequestToEnroll;
using Application.Features.GymEnrollment.Queries.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class GymEnrollmentProfile : Profile
{
    public GymEnrollmentProfile()
    {
        CreateMap<GymEnrollmentRequest, GymEnrollmentDto>();
    }
}