namespace LeaveManagementSystem.web.MappingProfiles;

public class LeaveAllocationAutoMapperProfile : Profile
{
    public LeaveAllocationAutoMapperProfile()
    {
        CreateMap<LeaveAllocation, LeaveAllocationVM>();
        CreateMap<ApplicationUser, EmployeeListVM>();
        CreateMap<Period, PeriodVM>();
    }
}
