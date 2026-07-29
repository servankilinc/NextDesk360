using AutoMapper;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using ExpressDesk360.Business.Abstract;
using ExpressDesk360.Core.BaseRequestModels;
using ExpressDesk360.Core.Utils.Datatable;
using ExpressDesk360.Core.Utils.Pagination;
using ExpressDesk360.Core.Utils.ResultPattern;
using ExpressDesk360.Core.Utils.Validation;
using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.UoW;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.Dtos.FaultType.Commands;
using ExpressDesk360.Model.Dtos.FaultType.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class FaultTypeService : IFaultTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public FaultTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<FaultType>> GetAsync(Expression<Func<FaultType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FaultType>.NotFound();
            return Result<FaultType>.Success(result);
        }

        public async Task<Result<FaultType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FaultType>.NotFound();
            return Result<FaultType>.Success(result);
        }

        public async Task<Result<FaultTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.GetAsync<FaultTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FaultTypeDto>.NotFound();
            return Result<FaultTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<FaultType>>> GetListAsync(Expression<Func<FaultType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FaultType>>.NotFound();
            return Result<ICollection<FaultType>>.Success(result);
        }

        public async Task<Result<ICollection<FaultType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FaultType>>.NotFound();
            return Result<ICollection<FaultType>>.Success(result);
        }

        public async Task<Result<ICollection<FaultTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.GetAllAsync<FaultTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<FaultTypeDto>>.NotFound();
            return Result<ICollection<FaultTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<FaultType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.FaultTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(FaultTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for FaultTypeCreateDto");
            await _unitOfWork.FaultTypes.AddAndSaveAsync(_mapper.Map<FaultType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<FaultTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.GetAsync<FaultTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<FaultTypeUpdateDto>.NotFound();
            return Result<FaultTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(FaultTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.FaultTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.FaultTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<FaultType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<FaultType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<FaultType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<FaultType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<FaultType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.FaultTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<FaultType>>.Success(result);
        }
    }
}
