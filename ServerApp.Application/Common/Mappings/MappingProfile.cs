using AutoMapper;
using ServerApp.Application.Employees.Commands.SaveEmployee;
using ServerApp.Core.Entities;

namespace ServerApp.Application.Common.Mappings
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<SaveEmployeeRequest, Employee>();
        }
    }
}
