using AutoMapper;
using Oswatech.Attributes.Dtos;
using Oswatech.Authorization.Users;
using Oswatech.Buildings;
using Oswatech.Buildings.Dtos;
using Oswatech.Projects;
using Oswatech.Projects.Dtos;
using Oswatech.Property.Dtos;

namespace Oswatech.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<UserDto, User>()
                .ForMember(x => x.Roles, opt => opt.Ignore())
                .ForMember(x => x.CreationTime, opt => opt.Ignore());

            CreateMap<CreateUserDto, User>();
            CreateMap<CreateUserDto, User>().ForMember(x => x.Roles, opt => opt.Ignore());

            CreateMap<Project, CreateUpdateProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Properties.Property, PropertyDto>().ReverseMap();
            CreateMap<Properties.Property, CreatePropertyDto>().ReverseMap();
            CreateMap<Properties.Property, UpdatePropertyDto>().ReverseMap();
            CreateMap<Building, BuildingDto>().ReverseMap();
            CreateMap<Building, CreateBuildingDto>().ReverseMap();
            CreateMap<Building, UpdateBuildingDto>().ReverseMap();
            CreateMap<Building, UpdateBuildingDto>().ReverseMap();
            CreateMap<Models.Attributes.Attribute, AttributeDto>().ReverseMap();
        }
    }
}
