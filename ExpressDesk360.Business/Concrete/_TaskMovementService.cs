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
using ExpressDesk360.Model.Dtos._TaskMovement.Commands;
using ExpressDesk360.Model.Dtos._TaskMovement.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class _TaskMovementService : I_TaskMovementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public _TaskMovementService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<_TaskMovement>> GetAsync(Expression<Func<_TaskMovement, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskMovement>.NotFound();
            return Result<_TaskMovement>.Success(result);
        }

        public async Task<Result<_TaskMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<_TaskMovement>.NotFound();
            return Result<_TaskMovement>.Success(result);
        }

        public async Task<Result<TaskMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.GetAsync<TaskMovementDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskMovementDto>.NotFound();
            return Result<TaskMovementDto>.Success(result);
        }

        public async Task<Result<ICollection<_TaskMovement>>> GetListAsync(Expression<Func<_TaskMovement, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskMovement>>.NotFound();
            return Result<ICollection<_TaskMovement>>.Success(result);
        }

        public async Task<Result<ICollection<_TaskMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<_TaskMovement>>.NotFound();
            return Result<ICollection<_TaskMovement>>.Success(result);
        }

        public async Task<Result<ICollection<TaskMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.GetAllAsync<TaskMovementDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskMovementDto>>.NotFound();
            return Result<ICollection<TaskMovementDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<_TaskMovement, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork._TaskMovements.GetAllAsync<object>(select: s => new { s.Id, s.Description }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Description");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TaskMovementCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TaskMovementCreateDto");
            await _unitOfWork._TaskMovements.AddAndSaveAsync(_mapper.Map<_TaskMovement>(request), cancellationToken);
            return Result.Success();
        }





        public async Task<Result<PaginationResponse<_TaskMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<_TaskMovement>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<_TaskMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<_TaskMovement>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<_TaskMovement>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovements.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<_TaskMovement>>.Success(result);
        }
    }
}
