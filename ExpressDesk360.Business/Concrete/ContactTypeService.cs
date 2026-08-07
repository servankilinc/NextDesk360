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
using ExpressDesk360.Model.Dtos.Common.ContactType.Commands;
using ExpressDesk360.Model.Dtos.Common.ContactType.Queries;
using ExpressDesk360.Model.Entities.Common;
using ExpressDesk360.Business.Abstract.Common;

namespace ExpressDesk360.Business.Concrete
{
    public class ContactTypeService : IContactTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ContactTypeService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ContactType>> GetAsync(Expression<Func<ContactType, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ContactType>.NotFound();
            return Result<ContactType>.Success(result);
        }

        public async Task<Result<ContactType>> GetAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ContactType>.NotFound();
            return Result<ContactType>.Success(result);
        }

        public async Task<Result<ContactTypeDto>> GetBaseAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.GetAsync<ContactTypeDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ContactTypeDto>.NotFound();
            return Result<ContactTypeDto>.Success(result);
        }

        public async Task<Result<ICollection<ContactType>>> GetListAsync(Expression<Func<ContactType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ContactType>>.NotFound();
            return Result<ICollection<ContactType>>.Success(result);
        }

        public async Task<Result<ICollection<ContactType>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ContactType>>.NotFound();
            return Result<ICollection<ContactType>>.Success(result);
        }

        public async Task<Result<ICollection<ContactTypeDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.GetAllAsync<ContactTypeDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ContactTypeDto>>.NotFound();
            return Result<ICollection<ContactTypeDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<ContactType, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var list = await _unitOfWork.ContactTypes.GetAllAsync<object>(select: s => new { s.Id, s.Name }, where: where, cancellationToken: cancellationToken);
            var selectList = new SelectList(list ?? new List<object>(), "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(ContactTypeCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ContactTypeCreateDto");
            await _unitOfWork.ContactTypes.AddAndSaveAsync(_mapper.Map<ContactType>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ContactTypeUpdateDto>> GetUpdateModelAsync(int id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.GetAsync<ContactTypeUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ContactTypeUpdateDto>.NotFound();
            return Result<ContactTypeUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ContactTypeUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ContactTypes.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ContactTypes.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }



        public async Task<Result<PaginationResponse<ContactType>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ContactType>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ContactType>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ContactType>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ContactType>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ContactTypes.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ContactType>>.Success(result);
        }
    }
}
