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
using ExpressDesk360.Model.Dtos.StockModule.StockBrand.Commands;
using ExpressDesk360.Model.Dtos.StockModule.StockBrand.Queries;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Model.Entities.StockModule;

namespace ExpressDesk360.Business.Concrete.StockModule
{
    public class StockBrandService : IStockBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockBrandService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockBrand>> GetAsync(Expression<Func<StockBrand, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockBrand>.NotFound();
            return Result<StockBrand>.Success(result);
        }

        public async Task<Result<StockBrand>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockBrand>.NotFound();
            return Result<StockBrand>.Success(result);
        }

        public async Task<Result<StockBrand>> GetDetailAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAsync(
                where: f => f.Id == id,
                include: i => i.Include(x => x.StockGroupBrandMaps).ThenInclude(m => m.StockGroup),
                cancellationToken: cancellationToken);

            if (result == null)
                return Result<StockBrand>.NotFound();
            return Result<StockBrand>.Success(result);
        }

        public async Task<Result<StockBrandDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAsync<StockBrandDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockBrandDto>.NotFound();
            return Result<StockBrandDto>.Success(result);
        }

        public async Task<Result<ICollection<StockBrand>>> GetListAsync(Expression<Func<StockBrand, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockBrand>>.NotFound();
            return Result<ICollection<StockBrand>>.Success(result);
        }

        public async Task<Result<ICollection<StockBrand>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockBrand>>.NotFound();
            return Result<ICollection<StockBrand>>.Success(result);
        }

        public async Task<Result<ICollection<StockBrandDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAllAsync<StockBrandDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockBrandDto>>.NotFound();
            return Result<ICollection<StockBrandDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<StockBrand, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.StockBrands.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockBrandCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockBrandCreateDto");
            await _unitOfWork.StockBrands.AddAndSaveAsync(_mapper.Map<StockBrand>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockBrandUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.GetAsync<StockBrandUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockBrandUpdateDto>.NotFound();
            return Result<StockBrandUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockBrandUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockBrands.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockBrands.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<StockBrand>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockBrand>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockBrand>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockBrand>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockBrandReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockBrands.DatatableServerSideAsync(
                datatableRequest: request,
                select: s => new StockBrandReportDto
                {
                    Id = s.Id,
                    Name = s.Name,
                    IsActive = s.IsActive,
                    CreateDateUtc = s.CreateDateUtc,
                    UpdateDateUtc = s.UpdateDateUtc
                },
                cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockBrandReportDto>>.Success(result);
        }
    }
}
