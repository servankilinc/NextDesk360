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
using ExpressDesk360.Model.Entities.TaskModule;
using ExpressDesk360.Business.Abstract.TaskModule;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovementType.Queries;
using ExpressDesk360.Model.Dtos.TaskModule.TaskMovementType.Commands;

namespace ExpressDesk360.Business.Concrete
{
    public class _TaskMovementTypeService : ITaskMovementTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public _TaskMovementTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TaskMovementType>> GetAsync(Expression<Func<TaskMovementType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskMovementType>.NotFound();
            return Result<TaskMovementType>.Success(result);
        }

        public async Task<Result<TaskMovementType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskMovementType>.NotFound();
            return Result<TaskMovementType>.Success(result);
        }

        public async Task<Result<TaskMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.GetAsync<TaskMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskMovementTypeDto>.NotFound();
            return Result<TaskMovementTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<TaskMovementType>>> GetListAsync(Expression<Func<TaskMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskMovementType>>.NotFound();
            return Result<ICollection<TaskMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<TaskMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskMovementType>>.NotFound();
            return Result<ICollection<TaskMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<TaskMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.GetAllAsync<TaskMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TaskMovementTypeDto>>.NotFound();
            return Result<ICollection<TaskMovementTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<TaskMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork._TaskMovementTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TaskMovementTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TaskMovementTypeCreateDto");
            await _unitOfWork._TaskMovementTypes.AddAndSaveAsync(_mapper.Map<TaskMovementType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TaskMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.GetAsync<TaskMovementTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TaskMovementTypeUpdateDto>.NotFound();
            return Result<TaskMovementTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TaskMovementTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork._TaskMovementTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork._TaskMovementTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<TaskMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TaskMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TaskMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TaskMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TaskMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork._TaskMovementTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TaskMovementType>>.Success(result);
        }
    }
}
