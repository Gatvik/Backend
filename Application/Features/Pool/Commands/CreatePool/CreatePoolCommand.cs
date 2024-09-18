using MediatR;

namespace Application.Features.Pool.Commands.CreatePool;

public class CreatePoolCommand : IRequest<int>
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
}