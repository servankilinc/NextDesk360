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
using ExpressDesk360.Model.Dtos.UserModule.UserContact.Commands;
using ExpressDesk360.Model.Dtos.UserModule.UserContact.Queries;
using ExpressDesk360.Model.Entities.UserModule;
using ExpressDesk360.Business.Abstract.UserModule;

namespace ExpressDesk360.Business.Concrete
{
    public class UserContactService : IUserContactService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public UserContactService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<UserContact>> GetAsync(Expression<Func<UserContact, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserContact>.NotFound();
            return Result<UserContact>.Success(result);
        }

        public async Task<Result<UserContact>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserContact>.NotFound();
            return Result<UserContact>.Success(result);
        }

        public async Task<Result<UserContactDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.GetAsync<UserContactDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserContactDto>.NotFound();
            return Result<UserContactDto>.Success(result);
        }

        public async Task<Result<ICollection<UserContact>>> GetListAsync(Expression<Func<UserContact, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UserContact>>.NotFound();
            return Result<ICollection<UserContact>>.Success(result);
        }

        public async Task<Result<ICollection<UserContact>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UserContact>>.NotFound();
            return Result<ICollection<UserContact>>.Success(result);
        }

        public async Task<Result<ICollection<UserContactDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.GetAllAsync<UserContactDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UserContactDto>>.NotFound();
            return Result<ICollection<UserContactDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<UserContact, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.UserContacts.GetAllAsync<object>(select: s => new { s.Id, s.Info }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Info");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(UserContactCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for UserContactCreateDto");
            await _unitOfWork.UserContacts.AddAndSaveAsync(_mapper.Map<UserContact>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<UserContactUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.GetAsync<UserContactUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserContactUpdateDto>.NotFound();
            return Result<UserContactUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(UserContactUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.UserContacts.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.UserContacts.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.UserContacts.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<UserContact>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<UserContact>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<UserContact>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<UserContact>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<UserContact>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.UserContacts.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<UserContact>>.Success(result);
        }
    }
}