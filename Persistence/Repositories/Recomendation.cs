using Domain.Common;

namespace Persistence.Repositories;

public class Recomendation : BaseEntity
{
    public string Key { get; set; } = null!;
    public string Description { get; set; }
}