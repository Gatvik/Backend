using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class PoolRepository : GenericRepository<Pool>, IPoolRepository
{
    public PoolRepository(DataContext context) : base(context)
    {
    }
}