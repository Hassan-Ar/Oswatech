using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Oswatech.Buildings.Dtos;
using Oswatech.Models.Products;
using Oswatech.Products.Dtos;
using Oswatech.ProductsStatus;
using Oswatech.Projects.Dtos;
using Oswatech.Property.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IObjectMapper = Abp.ObjectMapping.IObjectMapper;

namespace Oswatech.Buildings
{
    [Authorize]
    public class BuildingAppService : OswatechAppServiceBase,
        IBuildingAppService
    {
        private readonly IBuildingRepository _repository;
        private readonly IObjectMapper _mapper;
        private readonly IUserHistoryRepository _userHistoryRepository;

        public BuildingAppService(IBuildingRepository buildingRepository, IObjectMapper mapper)
        {
            _repository = buildingRepository;
            _mapper = mapper;
        }

        public async Task Buy(Guid id)
        {
            var user = await GetCurrentUserAsync();
            var building = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (building.ProductAvailablety)
            {
                building.ProductStatus = Status.Saled;
                building.ProductAvailablety = false;
            }
            else throw new UserFriendlyException("project is not available");

            var userhistory = new UserHistory()
            {
                RentEndDate = null,
                CreationTime = DateTime.Now,
                ProductId = id,
                UserId = user.Id,
                TransType = Status.Saled,
                Type = ProductType.Building
            };
            await _userHistoryRepository.InsertAsync(userhistory);
            await _repository.UpdateAsync(building);
        }

        [Authorize(Roles = "Admin")]
        public async Task<BuildingDto> Create(CreateBuildingDto input)
        {
            var building = new Building()
            {
                ProductAddress = input.ProductAddress,
                ProductAvailablety = input.ProductAvailablety,
                ProductNumber = input.ProductNumber,
                Price = input.Price,
                ProductStatus = input.ProductStatus,
                ProjectId = input.ProjectId,
                RentEndDate = input.RentEndDate,
                CreationTime=DateTime.Now,
                HasGarage = input.HasGarage
            };
            await _repository.InsertAsync(building);
            return ObjectMapper.Map<BuildingDto>(building);
        }

        [Authorize(Roles = "Admin")]
        public async Task Delete(Guid id)
        {
            var building = await _repository.FirstOrDefaultAsync(x=>x.Id== id);
            if (building != null)
            {
                await _repository.DeleteAsync(building);
            }
            else { throw new UserFriendlyException("notfound"); }
        }

        public async Task<PagedResultDto<BuildingDto>> GetAll(GetListProductInputDto input)
        {
            var buildingList = await _repository.GetListAsync(
                input.Address,
                input.status,
                input.Price,
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting);
            if(buildingList.Item1 == null)
            {
                throw new UserFriendlyException("notFound");
            }
            return new PagedResultDto<BuildingDto>
            {
                Items = ObjectMapper.Map<List<BuildingDto>>(buildingList.Item1),
                TotalCount = buildingList.count
            };

        }

        public async Task<BuildingDto> GetById(Guid id)
        {
            if (id.ToString() == null)
            {
                throw new UserFriendlyException("nullvalue");
            }
            var building = await _repository.FirstOrDefaultAsync(x=>x.Id== id);
            if(building != null)
            {
                throw new UserFriendlyException("notfound");

            }
            return ObjectMapper.Map<BuildingDto>(building);
        }

        public async Task Rent(RentRequestDto input)
        {
            var user = await GetCurrentUserAsync();
            var building = await _repository.FirstOrDefaultAsync(x => x.Id == input.ProjectId);
            if (building.ProductAvailablety)
            {
                building.ProductStatus = Status.Rented;
                building.ProductAvailablety = false;
            }
            else throw new UserFriendlyException("project is not available");

            var userhistory = new UserHistory()
            {
                RentEndDate = null,
                CreationTime = DateTime.Now,
                ProductId = input.ProjectId,
                UserId = user.Id,
                TransType = Status.Saled,
                Type = ProductType.Building,
            };
            await _userHistoryRepository.InsertAsync(userhistory);
            await _repository.UpdateAsync(building);
            throw new NotImplementedException();
        }
        [Authorize(Roles = "Admin")]
        public async Task<BuildingDto> Update(UpdateBuildingDto input)
        {
            var building = await _repository.GetAsync(input.Id);

            building.ProductAddress = input.ProductAddress;
            building.ProductAvailablety = input.ProductAvailablety;
            building.ProductNumber = input.ProductNumber;
            building.Price = input.Price;
            building.ProductStatus = input.ProductStatus;
            building.ProjectId = input.ProjectId;
            building.RentEndDate = input.RentEndDate;
            building.HasGarage = input.HasGarage;
                
            await _repository.UpdateAsync(building);
            return ObjectMapper.Map<BuildingDto>(building);

        }
    }
}
