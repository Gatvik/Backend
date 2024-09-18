using Application.Features.Pool.Queries.Shared;
using MediatR;

namespace Application.Features.Pool.Queries.GetAllPools;

public record GetAllPoolsQuery() : IRequest<List<PoolDto>>;