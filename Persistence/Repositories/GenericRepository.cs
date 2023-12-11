using System.Linq.Expressions;
using Application.Contracts.Persistence;
using Domain.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;

namespace Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly DataContext Context;

    public GenericRepository(DataContext context)
    {
        Context = context;
    }
    
    public async Task<IReadOnlyList<T>> GetAllAsync()
    {
        return await Context.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<IReadOnlyList<T>> GetAllByPredicateAsync(Expression<Func<T, bool>> predicate)
    {
        return await Context.Set<T>().AsNoTracking().Where(predicate).ToListAsync();
    }

    public Task<T?> GetByIdAsync(int id)
    {
        return GetByPredicateAsync(q => q.Id == id);
    }

    public Task<T?> GetByPredicateAsync(Expression<Func<T, bool>> predicate)
    {
        return Context.Set<T>().AsNoTracking().FirstOrDefaultAsync(predicate);
    }
    
    public async Task CreateAsync(T entity)
    {
        await Context.AddAsync(entity);
        await Context.SaveChangesAsync();
    }

    public async Task UpdateAsync(T entity)
    {
        Context.Entry(entity).State = EntityState.Modified;
        await Context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        Context.Remove(entity);
        await Context.SaveChangesAsync();
    }
}