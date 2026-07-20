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
using ExpressDesk360.Model.Dtos.TicketMovementType.Commands;
using ExpressDesk360.Model.Dtos.TicketMovementType.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketMovementTypeService : ITicketMovementTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketMovementTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketMovementType>> GetAsync(Expression<Func<TicketMovementType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementType>.NotFound();
            return Result<TicketMovementType>.Success(result);
        }

        public async Task<Result<TicketMovementType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementType>.NotFound();
            return Result<TicketMovementType>.Success(result);
        }

        public async Task<Result<TicketMovementTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.GetAsync<TicketMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementTypeDto>.NotFound();
            return Result<TicketMovementTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketMovementType>>> GetListAsync(Expression<Func<TicketMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMovementType>>.NotFound();
            return Result<ICollection<TicketMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMovementType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMovementType>>.NotFound();
            return Result<ICollection<TicketMovementType>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMovementTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.GetAllAsync<TicketMovementTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMovementTypeDto>>.NotFound();
            return Result<ICollection<TicketMovementTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketMovementType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.TicketMovementTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TicketMovementTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketMovementTypeCreateDto");
            await _unitOfWork.TicketMovementTypes.AddAndSaveAsync(_mapper.Map<TicketMovementType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketMovementTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.GetAsync<TicketMovementTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementTypeUpdateDto>.NotFound();
            return Result<TicketMovementTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketMovementTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketMovementTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketMovementTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketMovementTypes.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(int id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketMovementTypes.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TicketMovementType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketMovementType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketMovementType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketMovementType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketMovementType>>.Success(result);
        }
    }
}