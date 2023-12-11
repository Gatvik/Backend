using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class GymRepository : GenericRepository<Gym>, IGymRepository
{
    public GymRepository(DataContext context) : base(context)
    {
    }
}