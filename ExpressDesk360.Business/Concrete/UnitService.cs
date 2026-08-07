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
using ExpressDesk360.Model.Dtos.Common.Unit.Commands;
using ExpressDesk360.Model.Dtos.Common.Unit.Queries;
using ExpressDesk360.Model.Entities.Common;
using ExpressDesk360.Business.Abstract.Common;

namespace ExpressDesk360.Business.Concrete
{
    public class UnitService : IUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public UnitService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> GetAsync(Expression<Func<Unit, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Unit>.NotFound();
            return Result<Unit>.Success(result);
        }

        public async Task<Result<Unit>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<Unit>.NotFound();
            return Result<Unit>.Success(result);
        }

        public async Task<Result<UnitDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.GetAsync<UnitDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UnitDto>.NotFound();
            return Result<UnitDto>.Success(result);
        }

        public async Task<Result<ICollection<Unit>>> GetListAsync(Expression<Func<Unit, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Unit>>.NotFound();
            return Result<ICollection<Unit>>.Success(result);
        }

        public async Task<Result<ICollection<Unit>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<Unit>>.NotFound();
            return Result<ICollection<Unit>>.Success(result);
        }

        public async Task<Result<ICollection<UnitDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.GetAllAsync<UnitDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UnitDto>>.NotFound();
            return Result<ICollection<UnitDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<Unit, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Units.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(UnitCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for UnitCreateDto");
            await _unitOfWork.Units.AddAndSaveAsync(_mapper.Map<Unit>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<UnitUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.GetAsync<UnitUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UnitUpdateDto>.NotFound();
            return Result<UnitUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(UnitUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Units.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Units.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<Unit>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<Unit>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<Unit>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<Unit>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<Unit>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Units.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<Unit>>.Success(result);
        }
    }
}
