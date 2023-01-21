using AutoMapper;

namespace EMS.Profiles
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Models.Domain.Employee, Models.DTO.Employee>().ReverseMap();
        }
    }
}
