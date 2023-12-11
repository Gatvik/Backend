using Domain.Common;

namespace Domain;

public class Recomendation : BaseEntity
{
    public string Key { get; set; } = null!;
    public string Description { get; set; } = null!;
}