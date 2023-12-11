using Application.Contracts.Persistence;
using Domain;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class GymEnrollmentRepository : GenericRepository<GymEnrollmentRequest>, IGymEnrollmentRepository
{
    public GymEnrollmentRepository(DataContext context) : base(context)
    {
    }
}