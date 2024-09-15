using AutoMapper;
using LeaveManagementSystem.web.Data;
using LeaveManagementSystem.web.Models.LeaveTypes;

namespace LeaveManagementSystem.web.MappingProfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<LeaveType, LeaveTypeReadOnlyVM>();
        }
    }
}
