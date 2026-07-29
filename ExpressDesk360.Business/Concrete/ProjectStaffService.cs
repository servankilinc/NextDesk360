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
using ExpressDesk360.Model.Dtos.ProjectStaff.Commands;
using ExpressDesk360.Model.Dtos.ProjectStaff.Queries;

namespace ExpressDesk360.Business.Concrete
{
    public class ProjectStaffService : IProjectStaffService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public ProjectStaffService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<ProjectStaff>> GetAsync(Expression<Func<ProjectStaff, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStaff>.NotFound();
            return Result<ProjectStaff>.Success(result);
        }

        public async Task<Result<ProjectStaff>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStaff>.NotFound();
            return Result<ProjectStaff>.Success(result);
        }

        public async Task<Result<ProjectStaffDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.GetAsync<ProjectStaffDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStaffDto>.NotFound();
            return Result<ProjectStaffDto>.Success(result);
        }

        public async Task<Result<ICollection<ProjectStaff>>> GetListAsync(Expression<Func<ProjectStaff, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectStaff>>.NotFound();
            return Result<ICollection<ProjectStaff>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectStaff>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectStaff>>.NotFound();
            return Result<ICollection<ProjectStaff>>.Success(result);
        }

        public async Task<Result<ICollection<ProjectStaffDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.GetAllAsync<ProjectStaffDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<ProjectStaffDto>>.NotFound();
            return Result<ICollection<ProjectStaffDto>>.Success(result);
        }

        public async Task<Result> CreateAsync(ProjectStaffCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for ProjectStaffCreateDto");
            await _unitOfWork.ProjectStaffs.AddAndSaveAsync(_mapper.Map<ProjectStaff>(request), cancellationToken);
            return Result.Success();
        }

        public async Task<Result<ProjectStaffUpdateDto>> GetUpdateModelAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.GetAsync<ProjectStaffUpdateDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ProjectStaffUpdateDto>.NotFound();
            return Result<ProjectStaffUpdateDto>.Success(result);
        }

        public async Task<Result> UpdateAsync(ProjectStaffUpdateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures);
            var entity = await _unitOfWork.ProjectStaffs.GetAsync(where: (f) => f.Id == request.Id, cancellationToken: cancellationToken);
            if (entity == null)
                return Result.NotFound();
            await _unitOfWork.ProjectStaffs.UpdateAndSaveAsync(_mapper.Map(request, entity), cancellationToken);
            return Result.Success();
        }

        public async Task<Result> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var affected = await _unitOfWork.ProjectStaffs.DeleteAndSaveAsync(where: (f) => f.Id == id, cancellationToken);
            if (affected == 0) return Result.NotFound();
            return Result.Success();
        }

        public async Task<Result<PaginationResponse<ProjectStaff>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<ProjectStaff>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<ProjectStaff>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<ProjectStaff>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<ProjectStaff>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.ProjectStaffs.DatatableServerSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<ProjectStaff>>.Success(result);
        }
    }
}