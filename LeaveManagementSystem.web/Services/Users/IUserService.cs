

namespace LeaveManagementSystem.web.Services.Users
{
    public interface IUserService
    {
        Task<List<ApplicationUser>> GetEmployees();
        Task<ApplicationUser> GetLoggedInUser();
        Task<ApplicationUser> GetUserById(string UserId);
    }
}