using System.ComponentModel.DataAnnotations.Schema;
using Domain.Common;

namespace Domain;

public class Gym : BaseEntity
{
    public string Name { get; set; } = null!;
    public string Address { get; set; } = null!;
    public string City { get; set; } = null!;
    public string Country { get; set; } = null!;
    public string Description { get; set; } = null!;
    
    public ICollection<Member> Members { get; set; } = null!;
}