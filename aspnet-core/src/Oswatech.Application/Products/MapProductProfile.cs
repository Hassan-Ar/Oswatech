using AutoMapper;
using Castle.MicroKernel.Registration;
using Oswatech.Attributes.Dtos;
using Oswatech.Authorization.Users;
using Oswatech.Buildings;
using Oswatech.Buildings.Dtos;
using Oswatech.Models.Attributes;
using Oswatech.Models.Products;
using Oswatech.Products.Dtos;
using Oswatech.Projects;
using Oswatech.Projects.Dtos;
using Oswatech.Property.Dtos;
using Oswatech.Users.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Products
{
    public class MapProductProfile : Profile
    {
        public MapProductProfile()
        {
            CreateMap<Project, CreateUpdateProjectDto>().ReverseMap();
            CreateMap<Project, ProjectDto>().ReverseMap();
            CreateMap<Properties.Property, PropertyDto>().ReverseMap();
            CreateMap<Properties.Property, CreatePropertyDto>().ReverseMap();
            CreateMap<Properties.Property, UpdatePropertyDto>().ReverseMap();
            CreateMap<Building, BuildingDto>().ReverseMap();
            CreateMap<Building, CreateBuildingDto>().ReverseMap();
            CreateMap<Building, UpdateBuildingDto>().ReverseMap();
            CreateMap<Models.Attributes.Attribute, AttributeDto>().ReverseMap();
            CreateMap<UserHistory, UserHistoryDto>();


        }
    }
}
