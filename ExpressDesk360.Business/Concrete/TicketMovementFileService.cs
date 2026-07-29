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
using ExpressDesk360.Model.Dtos.TicketMovementFile.Commands;
using ExpressDesk360.Model.Dtos.TicketMovementFile.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketMovementFileService : ITicketMovementFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketMovementFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketMovementFile>> GetAsync(Expression<Func<TicketMovementFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementFile>.NotFound();
            return Result<TicketMovementFile>.Success(result);
        }

        public async Task<Result<TicketMovementFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementFile>.NotFound();
            return Result<TicketMovementFile>.Success(result);
        }

        public async Task<Result<TicketMovementFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.GetAsync<TicketMovementFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementFileDto>.NotFound();
            return Result<TicketMovementFileDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketMovementFile>>> GetListAsync(Expression<Func<TicketMovementFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMovementFile>>.NotFound();
            return Result<ICollection<TicketMovementFile>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMovementFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMovementFile>>.NotFound();
            return Result<ICollection<TicketMovementFile>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMovementFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.GetAllAsync<TicketMovementFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMovementFileDto>>.NotFound();
            return Result<ICollection<TicketMovementFileDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(TicketMovementFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketMovementFileCreateDto");
            await _unitOfWork.TicketMovementFiles.AddAndSaveAsync(_mapper.Map<TicketMovementFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketMovementFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.GetAsync<TicketMovementFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMovementFileUpdateDto>.NotFound();
            return Result<TicketMovementFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketMovementFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketMovementFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketMovementFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.TicketMovementFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TicketMovementFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketMovementFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketMovementFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketMovementFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketMovementFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMovementFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketMovementFile>>.Success(result);
        }
    }
}