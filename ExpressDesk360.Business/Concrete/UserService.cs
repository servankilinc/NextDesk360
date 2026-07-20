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
using ExpressDesk360.Model.Dtos.User.Commands;
using ExpressDesk360.Model.Dtos.User.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<User>> GetAsync(Expression<Func<User, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<User>.NotFound();
            return Result<User>.Success(result);
        }

        public async Task<Result<User>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<User>.NotFound();
            return Result<User>.Success(result);
        }

        public async Task<Result<UserDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.GetAsync<UserDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserDto>.NotFound();
            return Result<UserDto>.Success(result);
        }

        public async Task<Result<ICollection<User>>> GetListAsync(Expression<Func<User, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<User>>.NotFound();
            return Result<ICollection<User>>.Success(result);
        }

        public async Task<Result<ICollection<User>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<User>>.NotFound();
            return Result<ICollection<User>>.Success(result);
        }

        public async Task<Result<ICollection<UserDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.GetAllAsync<UserDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<UserDto>>.NotFound();
            return Result<ICollection<UserDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<User, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.Users.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(UserCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for UserCreateDto");
            await _unitOfWork.Users.AddAndSaveAsync(_mapper.Map<User>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<UserUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.GetAsync<UserUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<UserUpdateDto>.NotFound();
            return Result<UserUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(UserUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.Users.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.Users.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            // RefreshToken has no soft-delete flag and no query filter, so a soft-deleted user's
            // tokens stay usable and keep the session alive. Revoke them alongside the delete.
            await _unitOfWork.RefreshTokens.RevokeDeviceRefreshTokensAsync(f => f.UserId == id && f.IsRevoked == false, cancellationToken);
            
            var affected = await _unitOfWork.Users.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result> RestoreAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var restored = await _unitOfWork.Users.RestoreAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (restored == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<User>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<User>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<User>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<User>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<User>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.Users.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<User>>.Success(result);
        }
    }
}