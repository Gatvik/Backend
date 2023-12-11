using Application.Features.Gym.Commands.CreateGym;
using Application.Features.Gym.Queries.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class GymProfile : Profile
{
    public GymProfile()
    {
        CreateMap<CreateGymCommand, Gym>();
        CreateMap<Gym, GymDto>();
    }
}