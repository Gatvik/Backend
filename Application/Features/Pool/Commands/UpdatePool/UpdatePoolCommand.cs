using MediatR;

namespace Application.Features.Pool.Commands.UpdatePool;

public class UpdatePoolCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
}