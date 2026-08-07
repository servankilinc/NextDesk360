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
using ExpressDesk360.Model.Dtos.TicketModule.TicketType.Commands;
using ExpressDesk360.Model.Dtos.TicketModule.TicketType.Queries;
using ExpressDesk360.Model.Entities.TicketModule;
using ExpressDesk360.Business.Abstract.TicketModule;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketTypeService : ITicketTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketType>> GetAsync(Expression<Func<TicketType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketType>.NotFound();
            return Result<TicketType>.Success(result);
        }

        public async Task<Result<TicketType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketType>.NotFound();
            return Result<TicketType>.Success(result);
        }

        public async Task<Result<TicketTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.GetAsync<TicketTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketTypeDto>.NotFound();
            return Result<TicketTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketType>>> GetListAsync(Expression<Func<TicketType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketType>>.NotFound();
            return Result<ICollection<TicketType>>.Success(result);
        }

        public async Task<Result<ICollection<TicketType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketType>>.NotFound();
            return Result<ICollection<TicketType>>.Success(result);
        }

        public async Task<Result<ICollection<TicketTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.GetAllAsync<TicketTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketTypeDto>>.NotFound();
            return Result<ICollection<TicketTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<TicketType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.TicketTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(TicketTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketTypeCreateDto");
            await _unitOfWork.TicketTypes.AddAndSaveAsync(_mapper.Map<TicketType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.GetAsync<TicketTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketTypeUpdateDto>.NotFound();
            return Result<TicketTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<TicketType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketType>>.Success(result);
        }
    }
}
