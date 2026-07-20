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
using ExpressDesk360.Model.Dtos.TicketMessageFile.Commands;
using ExpressDesk360.Model.Dtos.TicketMessageFile.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class TicketMessageFileService : ITicketMessageFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public TicketMessageFileService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<TicketMessageFile>> GetAsync(Expression<Func<TicketMessageFile, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessageFile>.NotFound();
            return Result<TicketMessageFile>.Success(result);
        }

        public async Task<Result<TicketMessageFile>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessageFile>.NotFound();
            return Result<TicketMessageFile>.Success(result);
        }

        public async Task<Result<TicketMessageFileDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.GetAsync<TicketMessageFileDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessageFileDto>.NotFound();
            return Result<TicketMessageFileDto>.Success(result);
        }

        public async Task<Result<ICollection<TicketMessageFile>>> GetListAsync(Expression<Func<TicketMessageFile, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMessageFile>>.NotFound();
            return Result<ICollection<TicketMessageFile>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMessageFile>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMessageFile>>.NotFound();
            return Result<ICollection<TicketMessageFile>>.Success(result);
        }

        public async Task<Result<ICollection<TicketMessageFileDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.GetAllAsync<TicketMessageFileDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<TicketMessageFileDto>>.NotFound();
            return Result<ICollection<TicketMessageFileDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(TicketMessageFileCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for TicketMessageFileCreateDto");
            await _unitOfWork.TicketMessageFiles.AddAndSaveAsync(_mapper.Map<TicketMessageFile>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<TicketMessageFileUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.GetAsync<TicketMessageFileUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<TicketMessageFileUpdateDto>.NotFound();
            return Result<TicketMessageFileUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(TicketMessageFileUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.TicketMessageFiles.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.TicketMessageFiles.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketMessageFiles.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            await _unitOfWork.TicketMessageFiles.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<TicketMessageFile>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<TicketMessageFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<TicketMessageFile>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<TicketMessageFile>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<TicketMessageFile>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.TicketMessageFiles.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<TicketMessageFile>>.Success(result);
        }
    }
}