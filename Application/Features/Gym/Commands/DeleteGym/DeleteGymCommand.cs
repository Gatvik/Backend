using MediatR;

namespace Application.Features.Gym.Commands.DeleteGym;

public record DeleteGymCommand(int Id) : IRequest<Unit>;