using Application.Contracts.Persistence;
using Domain;
using Microsoft.EntityFrameworkCore;
using Persistence.DatabaseContext;
using Persistence.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

public class MemberRepositoryTests : IDisposable
{
    private readonly DataContext _context;
    private readonly MemberRepository _repository;

    public MemberRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
         
        _context = new DataContext(options);
         
        SeedDatabase();
        
        _repository = new MemberRepository(_context);
    }

    private void SeedDatabase()
    {
        var members = new List<Member>
        {
            new Member 
            { 
                IdentityId = "123", 
                FirstName = "John", 
                LastName = "Doe", 
                Sex = "Male", 
                Pool = new Pool 
                { 
                    Name = "Pool1",
                    Address = "123 Main St", 
                    City = "New York", 
                    Country = "USA", 
                    Description = "A large gym with a pool."
                } 
            },
            new Member 
            { 
                IdentityId = "456", 
                FirstName = "Jane", 
                LastName = "Doe", 
                Sex = "Female", 
                Pool = new Pool 
                { 
                    Name = "Pool2",
                    Address = "456 Park Ave", 
                    City = "Los Angeles", 
                    Country = "USA", 
                    Description = "A modern gym with state-of-the-art facilities."
                } 
            }
        };

        _context.Members.AddRange(members);
        _context.SaveChanges();
    }

    [Fact]
    public async Task GetByIdentityIdAsync_ShouldReturnNull_WhenMemberDoesNotExist()
    {
        // Act
        var result = await _repository.GetByIdentityIdAsync("999");

        // Assert
        Assert.Null(result);
    }

    [Fact]
    public async Task GetWithGymByIdentityIdAsync_ShouldReturnMemberWithPool_WhenMemberExists()
    {
        // Act
        var result = await _repository.GetWithGymByIdentityIdAsync("123");

        // Assert
        Assert.NotNull(result);
        Assert.Equal("123", result.IdentityId);
        Assert.NotNull(result.Pool);
        Assert.Equal("Pool1", result.Pool.Name);
    }

    [Fact]
    public async Task GetAllWithGymByIdentityIdAsync_ShouldReturnAllMembersWithPools()
    {
        // Act
        var result = await _repository.GetAllWithGymByIdentityIdAsync();

        // Assert
        Assert.Equal(2, result.Count);
        Assert.NotNull(result[0].Pool);
        Assert.NotNull(result[1].Pool);
        Assert.Equal("Pool1", result[0].Pool.Name);
        Assert.Equal("Pool2", result[1].Pool.Name);
    }
    
    public void Dispose()
    {
        _context.Dispose();
    }
}
