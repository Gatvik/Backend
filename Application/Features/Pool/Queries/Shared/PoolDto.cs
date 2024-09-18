namespace Application.Features.Pool.Queries.Shared;

public class PoolDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
}