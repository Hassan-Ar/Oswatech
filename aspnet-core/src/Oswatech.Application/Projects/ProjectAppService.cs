using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Auditing;
using Abp.Domain.Repositories;
using Abp.Logging;
using Abp.ObjectMapping;
using Abp.Runtime.Session;
using Abp.UI;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Oswatech.Authorization.Users;
using Oswatech.Models.Products;
using Oswatech.Products.Dtos;
using Oswatech.ProductsStatus;
using Oswatech.Projects.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oswatech.Projects
{
    [Authorize]

    public class ProjectAppService : OswatechAppServiceBase, IProjectAppService
    {
        private readonly IProjectRepository _repository;
        private readonly IObjectMapper _mapper;
        private readonly IUserHistoryRepository _userHistoryRepository;
        private readonly IAbpSession _session;
        public ProjectAppService(IProjectRepository repository, IObjectMapper mapper, IUserHistoryRepository userHistoryRepository, IAbpSession session)
        {
            _repository = repository;
            _mapper = mapper;
            _userHistoryRepository = userHistoryRepository;
            _session = session;
        }


        [HttpPost]
        public async Task Buy(Guid projectId)
        {
            var user = await GetCurrentUserAsync();
            var project = await _repository.FirstOrDefaultAsync(x=>x.Id==projectId);
            if (project.ProductAvailablety)
            {
                project.ProductStatus = Status.Saled;
                project.ProductAvailablety = false;
            }
            else throw new UserFriendlyException("project is not available");

            var userhistory = new UserHistory()
            {
                RentEndDate = null,
                CreationTime = DateTime.Now,
                ProductId = projectId,
                UserId = user.Id,
                TransType = Status.Saled,
            };
            await _userHistoryRepository.InsertAsync(userhistory);
            await _repository.UpdateAsync(project);
        }
        [Authorize(Roles ="Admin")]
        public async Task<ProjectDto> Create(CreateUpdateProjectDto input)
        {
            var project = await _repository.InsertAsync(
                new Project()
                {
                    ProductAddress = input.ProductAddress,
                    ProductAvailablety = input.ProductAvailablety,
                    ProductNumber = input.ProductNumber,
                    ProductStatus = input.ProductStatus,
                    CreationTime = DateTime.Now,
                    Price = input.Price,
                    RentEndDate = input.RentEndDate,
                    HasMarket = input.HasMarket,
                }
                );
            await _repository.InsertAsync( project );


            return ObjectMapper.Map<ProjectDto>(project);        
        }
        [Authorize(Roles = "Admin")]

        public async Task Delete(Guid id)
        {
            if (id.ToString() != null)
            {
                var project = await _repository.GetAsync(id);
                await _repository.DeleteAsync(project);
            }
            else
            {
                throw new UserFriendlyException("notfound");
            }
        }

        public async Task<PagedResultDto<ProjectDto>> GetAll(GetListProductInputDto input)
        {
            var projectlist = await _repository.GetListAsync(
                input.Address,
                input.status,
                input.Price,
                input.SkipCount,
                input.MaxResultCount,
                input.Sorting);
            if (projectlist.Item1 == null)
            {

            }
            return new PagedResultDto<ProjectDto> { Items=ObjectMapper.Map<List<ProjectDto>>(projectlist.Item1) ,TotalCount=projectlist.count};

        }

        public async Task<ProjectDto> GetById(Guid id)
        {
            var project = await _repository.GetAsync(id);
            if (project == null)
            {
                throw new UserFriendlyException("notfound");
            }
            else return _mapper.Map<ProjectDto>(project);
        }

        /// <summary>
        /// rent project
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public async Task Rent(RentRequestDto input)
        {
            var user = await GetCurrentUserAsync();
            var project = await _repository.FirstOrDefaultAsync(x => x.Id == input.ProjectId);


            // check if project is rented or saled to another user
            if (project.ProductAvailablety)
            {
                project.ProductStatus = Status.Rented;
                project.ProductAvailablety = false;
            }
            else throw new UserFriendlyException("The is not available for rent");

            var userhistory = new UserHistory()
            {
                RentEndDate = input.RentEndDate,
                CreationTime = DateTime.Now,
                ProductId = input.ProjectId,
                UserId = user.Id,
                TransType = Status.Rent,
                Type = ProductType.Project
            };

            await _userHistoryRepository.InsertAsync(userhistory);
            await _repository.UpdateAsync(project);
        }
        [Authorize(Roles = "Admin")]

        public async Task<ProjectDto> Update(CreateUpdateProjectDto input)
        {
            var project = await _repository.FirstOrDefaultAsync(x=> x.Id == input.Id);
            if (project is null)
            {
                throw new UserFriendlyException("notfound");
            }


            project.ProductAddress = input.ProductAddress;
            project.ProductAvailablety = input.ProductAvailablety;
            project.ProductNumber = input.ProductNumber;
            project.ProductStatus = input.ProductStatus;
            project.Price = input.Price;
            project.HasMarket = input.HasMarket;
            project.RentEndDate = input.RentEndDate;

            await _repository.UpdateAsync(project);
            return _mapper.Map<ProjectDto>(project);
        }
    }
}