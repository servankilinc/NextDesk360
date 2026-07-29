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
using ExpressDesk360.Model.Dtos.StockSerial.Commands;
using ExpressDesk360.Model.Dtos.StockSerial.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class StockSerialService : IStockSerialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockSerialService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockSerial>> GetAsync(Expression<Func<StockSerial, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerial>.NotFound();
            return Result<StockSerial>.Success(result);
        }

        public async Task<Result<StockSerial>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerial>.NotFound();
            return Result<StockSerial>.Success(result);
        }

        public async Task<Result<StockSerialDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.GetAsync<StockSerialDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerialDto>.NotFound();
            return Result<StockSerialDto>.Success(result);
        }

        public async Task<Result<ICollection<StockSerial>>> GetListAsync(Expression<Func<StockSerial, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockSerial>>.NotFound();
            return Result<ICollection<StockSerial>>.Success(result);
        }

        public async Task<Result<ICollection<StockSerial>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockSerial>>.NotFound();
            return Result<ICollection<StockSerial>>.Success(result);
        }

        public async Task<Result<ICollection<StockSerialDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.GetAllAsync<StockSerialDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockSerialDto>>.NotFound();
            return Result<ICollection<StockSerialDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<StockSerial, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.StockSerials.GetAllAsync<object>(select: s => new { s.Id, s.SerialNumber }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "SerialNumber");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockSerialCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockSerialCreateDto");
            await _unitOfWork.StockSerials.AddAndSaveAsync(_mapper.Map<StockSerial>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<StockSerialUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.GetAsync<StockSerialUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockSerialUpdateDto>.NotFound();
            return Result<StockSerialUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(StockSerialUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.StockSerials.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.StockSerials.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<StockSerial>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockSerial>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockSerial>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockSerial>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockSerial>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockSerials.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockSerial>>.Success(result);
        }
    }
}
