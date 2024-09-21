using LeaveManagementSystem.web.Models.LeaveTypes;

namespace LeaveManagementSystem.web.Services.LeaveTypes;

public interface ILeaveTypesService
{
    Task<bool> CheckIfLeaveTypeNameExistsAsync(string name);
    Task<bool> CheckIfLeaveTypeNameExistsForEditAsync(LeaveTypeEditVM leaveTypeEdit);
    Task Create(LeaveTypeCreateVM model);
    Task Edit(LeaveTypeEditVM model);
    Task<T?> Get<T>(int id) where T : class;
    Task<List<LeaveTypeReadOnlyVM>> GetAll();
    bool LeaveTypeExists(int id);
    Task Remove(int id);
}