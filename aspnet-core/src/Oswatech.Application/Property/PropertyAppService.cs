using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Domain.Repositories;
using Abp.ObjectMapping;
using Abp.UI;
using Castle.MicroKernel.Registration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Oswatech.Models.Products;
using Oswatech.Products.Dtos;
using Oswatech.ProductsStatus;
using Oswatech.Projects;
using Oswatech.Projects.Dtos;
using Oswatech.Properties;
using Oswatech.Property.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Property
{
    [Authorize]
    public class PropertyAppService :OswatechAppServiceBase,IPropertyAppService

    {
        private readonly IPropertyRepository _repository;
        private readonly IUserHistoryRepository _userHistoryRepository;


        public PropertyAppService(IPropertyRepository repository, IUserHistoryRepository userHistoryRepository)
        {
            _repository = repository;
            _userHistoryRepository = userHistoryRepository;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<PropertyDto> Create(CreatePropertyDto input)
        {

            var property = new Properties.Property()
            {
                ProductAddress = input.ProductAddress,
                Price = input.Price,
                ProductAvailablety = input.ProductAvailablety,
                ProductNumber = input.ProductNumber,
                ProductStatus = input.ProductStatus,    
                BathsNumber = input.BathsNumber,
                BedsNumber = input.BedsNumber,
                BuildingId = input.BuildingId,
                RentEndDate=input.RentEndDate,
                RoomsNumber = input.RoomsNumber,
                HasWIFI = input.HasWIFI,
                CreationTime=DateTime.Now,
            };
         await   _repository.InsertAsync(property);
            return ObjectMapper.Map<PropertyDto>(property);
        }
        [Authorize(Roles = "Admin")]

        public async Task Delete(Guid id)
        {
           
            var property = await _repository.FirstOrDefaultAsync(x => x.Id == id);
            if (property == null)
            {
                throw new  UserFriendlyException("notfound");
            }
            await _repository.DeleteAsync(property);

        }

        public async Task<PagedResultDto<PropertyDto>> GetAll(GetListProductInputDto input)
        {
            int count = await _repository.CountAsync();
            var propertylist = await _repository.GetListAsync(input.Address,
                input.status,
                input.Price,
                input.BedsNumber,
                input.RoomsNumber,
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting);

            return  new PagedResultDto<PropertyDto> { 
                Items = ObjectMapper.Map<List<PropertyDto>>(propertylist.Item1), 
                TotalCount = propertylist.count 
            };

        }

        public async Task<PropertyDto> GetById(Guid id)
        {
        var property = await _repository.FirstOrDefaultAsync(x=>x.Id==id);
            if (property == null)
            {
                throw new UserFriendlyException("notfound");
            }
            return   ObjectMapper.Map<PropertyDto>(property);
        }
        [Authorize(Roles = "Admin")]

        public async Task<PropertyDto> Update(UpdatePropertyDto input)
        {
            if(input == null)
            {
                throw new  UserFriendlyException("inputisnull");
            }
            var property = await _repository.FirstOrDefaultAsync(input.Id);
            property.WindowsNumber = input.WindowsNumber;
            property.RoomsNumber = input.RoomsNumber;
            property.BedsNumber = input.BedsNumber;
            property.BathsNumber = input.BathsNumber;
            property.ProductNumber = input.ProductNumber;   
            property.ProductAddress = input.ProductAddress;
            property.Price = input.Price;
            property.ProductAvailablety = input.ProductAvailablety;
            property.ProductStatus = input.ProductStatus;
            property.BuildingId = input.BuildingId;
            property.RentEndDate=input.RentEndDate;
            property.HasWIFI = input.HasWIFI;

            if (property == null)
            {
                throw new UserFriendlyException("notfound");

            }

            await _repository.UpdateAsync(property);
            return ObjectMapper.Map<PropertyDto>(property);
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
                Type = ProductType.Property
            };
            await _userHistoryRepository.InsertAsync(userhistory);
            await _repository.UpdateAsync(building);
            throw new NotImplementedException();
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
                Type = ProductType.Property
            };
            await _userHistoryRepository.InsertAsync(userhistory);
            await _repository.UpdateAsync(building);
        }

    }
}
