using System.Security.Claims;
using Application.Contracts.Identity;
using Application.Exceptions;
using Application.Models.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace Application.Services;

public class UserService : IUserService
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly IHttpContextAccessor _contextAccessor;

    public UserService(UserManager<IdentityUser> userManager, IHttpContextAccessor contextAccessor)
    {
        _userManager = userManager;
        _contextAccessor = contextAccessor;
    }

    // public async Task<List<User>> GetMembers()
    // {
    //     var employees = await _userManager.GetUsersInRoleAsync("Member");
    //     return employees.Select(q => new User()
    //     {
    //         Id = q.Id,
    //         Email = q.Email,
    //         FirstName = q.FirstName,
    //         LastName = q.LastName
    //     }).ToList();
    // }
    //
    // public async Task<User> GetMember(string userId)
    // {
    //     var member = await _userManager.FindByIdAsync(userId);
    //     
    //     if (member is null)
    //         throw new NotFoundException($"User with {userId} not found.", userId);
    //     
    //     return new User()
    //     {
    //         Email = member.Email!,
    //         Id = member.Id,
    //         FirstName = member.FirstName,
    //         LastName = member.LastName
    //     };
    // }

    public string UserId => _contextAccessor.HttpContext?.User?.FindFirstValue("uid")!;
}