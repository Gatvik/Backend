using Application.Features.Gym.Queries.Shared;
using MediatR;

namespace Application.Features.Gym.Queries.GetAllGyms;

public record GetAllGymsQuery() : IRequest<List<GymDto>>;