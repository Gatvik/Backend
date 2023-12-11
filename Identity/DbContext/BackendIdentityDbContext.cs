using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Identity.DbContext;

public class BackendIdentityDbContext : IdentityDbContext<IdentityUser>
{
    public BackendIdentityDbContext(DbContextOptions<BackendIdentityDbContext> options)
        : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        builder.ApplyConfigurationsFromAssembly(typeof(BackendIdentityDbContext).Assembly);
    }
}