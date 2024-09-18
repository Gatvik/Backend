using Application.Features.Pool.Commands.CreatePool;
using Application.Features.Pool.Queries.Shared;
using AutoMapper;
using Domain;

namespace Application.MappingProfiles;

public class PoolProfile : Profile
{
    public PoolProfile()
    {
        CreateMap<CreatePoolCommand, Pool>();
        CreateMap<Pool, PoolDto>();
    }
}