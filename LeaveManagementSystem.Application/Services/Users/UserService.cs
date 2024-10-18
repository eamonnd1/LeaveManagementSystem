using Microsoft.AspNetCore.Http;

namespace LeaveManagementSystem.Application.Services.Users;

public class UserService(UserManager<ApplicationUser> _userManager,
    IHttpContextAccessor _httpContextAccessor) : IUserService
{
    public async Task<ApplicationUser> GetLoggedInUser()
    {
        var user = await _userManager.GetUserAsync(_httpContextAccessor.HttpContext?.User);
        return user;
    }

    public async Task<ApplicationUser> GetUserById(string UserId)
    {
        var user = await _userManager.FindByIdAsync(UserId);
        return user;
    }

    public async Task<List<ApplicationUser>> GetEmployees()
    {
        var emoloyees = await _userManager.GetUsersInRoleAsync(Roles.Employee);
        return emoloyees.ToList();
    }
}
