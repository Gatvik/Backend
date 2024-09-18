using MediatR;

namespace Application.Features.Pool.Commands.DeletePool;

public record DeletePoolCommand(int Id) : IRequest<Unit>;