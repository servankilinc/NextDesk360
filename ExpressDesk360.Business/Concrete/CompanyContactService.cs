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
using ExpressDesk360.Model.Dtos.CompanyContact.Commands;
using ExpressDesk360.Model.Dtos.CompanyContact.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class CompanyContactService : ICompanyContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public CompanyContactService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<CompanyContact>> GetAsync(Expression<Func<CompanyContact, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyContact>.NotFound();
            return Result<CompanyContact>.Success(result);
        }

        public async Task<Result<CompanyContact>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyContact>.NotFound();
            return Result<CompanyContact>.Success(result);
        }

        public async Task<Result<CompanyContactDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.GetAsync<CompanyContactDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyContactDto>.NotFound();
            return Result<CompanyContactDto>.Success(result);
        }

        public async Task<Result<ICollection<CompanyContact>>> GetListAsync(Expression<Func<CompanyContact, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyContact>>.NotFound();
            return Result<ICollection<CompanyContact>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyContact>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyContact>>.NotFound();
            return Result<ICollection<CompanyContact>>.Success(result);
        }

        public async Task<Result<ICollection<CompanyContactDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.GetAllAsync<CompanyContactDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<CompanyContactDto>>.NotFound();
            return Result<ICollection<CompanyContactDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<CompanyContact, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.CompanyContacts.GetAllAsync<object>(select: s => new { s.Id, s.Info }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Info");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(CompanyContactCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for CompanyContactCreateDto");
            await _unitOfWork.CompanyContacts.AddAndSaveAsync(_mapper.Map<CompanyContact>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<CompanyContactUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.GetAsync<CompanyContactUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<CompanyContactUpdateDto>.NotFound();
            return Result<CompanyContactUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(CompanyContactUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.CompanyContacts.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.CompanyContacts.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.CompanyContacts.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.CompanyContacts.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<CompanyContact>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<CompanyContact>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<CompanyContact>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<CompanyContact>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<CompanyContact>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.CompanyContacts.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<CompanyContact>>.Success(result);
        }
    }
}