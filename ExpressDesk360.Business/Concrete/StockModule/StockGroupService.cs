using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Core.Utils.Validation;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.UoW;
using ExpressDesk360.Model.Dtos.StockModule.StockGroup.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockGroup.Queries;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Concrete.StockModule
{
    public class StockGroupService : IStockGroupService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockGroupService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockGroup>> GetAsync(Expression<Func<StockGroup, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroup>.NotFound();
            return Result<StockGroup>.Success(result);
        }

        public async Task<Result<StockGroup>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroup>.NotFound();
            return Result<StockGroup>.Success(result);
        }

        public async Task<Result<StockGroup>> GetDetailAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync(
                where: f => f.Id == id,
                include: i => i.Include(x => x.StockGroupBrandMaps).ThenInclude(m => m.StockBrand)
                               .Include(x => x.StockGroupFaultTypeMaps).ThenInclude(m => m.FaultType),
                cancellationToken: cancellationToken);

            if (result == null)
                return Result<StockGroup>.NotFound();
            return Result<StockGroup>.Success(result);
        }

        public async Task<Result<StockGroupDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAsync<StockGroupDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockGroupDto>.NotFound();
            return Result<StockGroupDto>.Success(result);
        }

        public async Task<Result<ICollection<StockGroup>>> GetListAsync(Expression<Func<StockGroup, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroup>>.NotFound();
            return Result<ICollection<StockGroup>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroup>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroup>>.NotFound();
            return Result<ICollection<StockGroup>>.Success(result);
        }

        public async Task<Result<ICollection<StockGroupDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.GetAllAsync<StockGroupDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockGroupDto>>.NotFound();
            return Result<ICollection<StockGroupDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<StockGroup, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.StockGroups.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockGroupCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockGroupCreateDto");
            
            var entity = _mapper.Map<StockGroup>(request);
            if (request.BrandIds != null && request.BrandIds.Any())
            {
                entity.StockGroupBrandMaps = request.BrandIds.Select(id => new StockGroupBrandMap { StockBrandId = id }).ToList();
            }
            if (request.FaultTypeIds != null && request.FaultTypeIds.Any())
            {
                entity.StockGroupFaultTypeMaps = request.FaultTypeIds.Select(id => new StockGroupFaultTypeMap { FaultTypeId = id }).ToList();
            }

            await _unitOfWork.StockGroups.AddAndSaveAsync(entity, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockGroupUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var entity = await _unitOfWork.StockGroups.GetAsync(
                where: f => f.Id == id,
                include: i => i.Include(x => x.StockGroupBrandMaps).Include(x => x.StockGroupFaultTypeMaps),
                cancellationToken: cancellationToken);

            if (entity == null)
                return Result<StockGroupUpdateDto>.NotFound();

            var result = _mapper.Map<StockGroupUpdateDto>(entity);
            result.BrandIds = entity.StockGroupBrandMaps?.Select(x => x.StockBrandId).ToList();
            result.FaultTypeIds = entity.StockGroupFaultTypeMaps?.Select(x => x.FaultTypeId).ToList();

            return Result<StockGroupUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockGroupUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            
            var entity = await _unitOfWork.StockGroups.GetAsync(
                where: (f) => f.Id == request.Id, 
                include: i => i.Include(x => x.StockGroupBrandMaps).Include(x => x.StockGroupFaultTypeMaps),
                cancellationToken: cancellationToken);
            
            if (entity == null)
                return Result.NotFound();

            entity = _mapper.Map(request, entity);

            if (request.BrandIds != null)
            {
                entity.StockGroupBrandMaps?.Clear();
                if (entity.StockGroupBrandMaps == null) entity.StockGroupBrandMaps = new List<StockGroupBrandMap>();
                foreach (var id in request.BrandIds)
                {
                    entity.StockGroupBrandMaps.Add(new StockGroupBrandMap { StockGroupId = entity.Id, StockBrandId = id });
                }
            }

            if (request.FaultTypeIds != null)
            {
                entity.StockGroupFaultTypeMaps?.Clear();
                if (entity.StockGroupFaultTypeMaps == null) entity.StockGroupFaultTypeMaps = new List<StockGroupFaultTypeMap>();
                foreach (var id in request.FaultTypeIds)
                {
                    entity.StockGroupFaultTypeMaps.Add(new StockGroupFaultTypeMap { StockGroupId = entity.Id, FaultTypeId = id });
                }
            }

            await _unitOfWork.StockGroups.UpdateAndSaveAsync(entity, cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<StockGroup>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockGroup>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockGroup>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockGroup>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockGroupReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockGroups.DatatableServerSideAsync(
                datatableRequest: request,
                select: s => new StockGroupReportDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    CreateDateUtc = s.CreateDateUtc,
                    UpdateDateUtc = s.UpdateDateUtc
                },
                cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockGroupReportDto>>.Success(result);
        }
    }
}
