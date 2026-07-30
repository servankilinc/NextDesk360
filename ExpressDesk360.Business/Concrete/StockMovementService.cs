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
using ExpressDesk360.Model.Dtos.StockMovement.Commands;
using ExpressDesk360.Model.Dtos.StockMovement.Queries;
using ExpressDesk360.Model.Enums;

namespace ExpressDesk360.Business.Concrete
{
    public class StockMovementService : IStockMovementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IValidationService _validationService;
        private readonly IMapper _mapper;
        public StockMovementService(IUnitOfWork unitOfWork, IValidationService validationService, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _validationService = validationService;
            _mapper = mapper;
        }

        public async Task<Result<StockMovement>> GetAsync(Expression<Func<StockMovement, bool>> where, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.GetAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovement>.NotFound();
            return Result<StockMovement>.Success(result);
        }

        public async Task<Result<StockMovement>> GetAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.GetAsync(where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovement>.NotFound();
            return Result<StockMovement>.Success(result);
        }

        public async Task<Result<StockMovementDto>> GetBaseAsync(Guid id, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.GetAsync<StockMovementDto>(configurationProvider: _mapper.ConfigurationProvider, where: (f) => f.Id == id, cancellationToken: cancellationToken);
            if (result == null)
                return Result<StockMovementDto>.NotFound();
            return Result<StockMovementDto>.Success(result);
        }

        public async Task<Result<ICollection<StockMovement>>> GetListAsync(Expression<Func<StockMovement, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.GetAllAsync(where: where, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovement>>.NotFound();
            return Result<ICollection<StockMovement>>.Success(result);
        }

        public async Task<Result<ICollection<StockMovement>>> GetListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.GetAllAsync(filter: request?.Filter, sorts: request?.Sorts, tracking: false, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovement>>.NotFound();
            return Result<ICollection<StockMovement>>.Success(result);
        }

        public async Task<Result<ICollection<StockMovementDto>>> GetBaseListAsync(DynamicRequest? request = default, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.GetAllAsync<StockMovementDto>(configurationProvider: _mapper.ConfigurationProvider, filter: request?.Filter, sorts: request?.Sorts, cancellationToken: cancellationToken);
            if (result == null)
                return Result<ICollection<StockMovementDto>>.NotFound();
            return Result<ICollection<StockMovementDto>>.Success(result);
        }

        public async Task<Result<SelectList>> SelectListAsync(Expression<Func<StockMovement, bool>>? where = default, CancellationToken cancellationToken = default)
        {
            // StockMovement has no Name column. Project only translatable columns, then build the
            // label in memory - DateTime.ToString(format) has no SQL translation.
            var rows = await _unitOfWork.StockMovements.GetAllAsync<StockMovementSelectRow>(select: s => new StockMovementSelectRow { Id = s.Id, Date = s.Date, Quantity = s.Quantity }, where: where, cancellationToken: cancellationToken);
            var items = (rows ?? new List<StockMovementSelectRow>())
                .Select(r => new { r.Id, Name = $"{r.Date:yyyy-MM-dd} / {r.Quantity}" })
                .ToList();
            var selectList = new SelectList(items, "Id", "Name");
            return Result<SelectList>.Success(selectList);
        }

        public async Task<Result> CreateAsync(StockMovementCreateDto request, CancellationToken cancellationToken = default)
        {
            var validationResult = await _validationService.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
                return Result.Validation(validationResult.Failures, description: $"Validation failed for StockMovementCreateDto");

            await _unitOfWork.BeginTransactionAsync(cancellationToken);
            try
            {
                var entity = _mapper.Map<StockMovement>(request);
                
                if (request.StockSerialIds != null && request.StockSerialIds.Any())
                {
                    entity.StockMovementStockSerialMaps = request.StockSerialIds.Select(id => new StockMovementStockSerialMap
                    {
                        StockSerialId = id
                    }).ToList();
                }

                await _unitOfWork.StockMovements.AddAndSaveAsync(entity, cancellationToken);

                // CompanyProductStockSerialMap yönetimi
                if (request.StockMovementTypeId == (int)StockEnums.StockMovementType.AttachedToProduct && request.CompanyProductId.HasValue && request.StockSerialIds != null) // AttachedToProduct
                {
                    var maps = request.StockSerialIds.Select(serialId => new CompanyProductStockSerialMap
                    {
                        CompanyProductId = request.CompanyProductId.Value,
                        StockSerialId = serialId
                    });
                    await _unitOfWork.CompanyProductStockSerialMaps.AddAndSaveAsync(maps, cancellationToken);
                }
                else if (request.StockMovementTypeId == (int)StockEnums.StockMovementType.RemovedFromProduct && request.CompanyProductId.HasValue && request.StockSerialIds != null) // RemovedFromProduct
                {
                    foreach (var serialId in request.StockSerialIds)
                    {
                        await _unitOfWork.CompanyProductStockSerialMaps.DeleteAndSaveAsync(
                            where: x => x.CompanyProductId == request.CompanyProductId.Value && x.StockSerialId == serialId, 
                            cancellationToken: cancellationToken);
                    }
                }

                await _unitOfWork.CommitTransactionAsync(cancellationToken);
                return Result.Success();
            }
            catch (Exception)
            {
                await _unitOfWork.RollbackTransactionAsync(cancellationToken);
                throw;
            }
        }





        public async Task<Result<PaginationResponse<StockMovement>>> PaginationAsync(DynamicPaginationRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.PaginationAsync(paginationRequest: request, cancellationToken: cancellationToken);
            return Result<PaginationResponse<StockMovement>>.Success(result);
        }

        public async Task<Result<DatatableResponseClientSide<StockMovement>>> DatatableClientSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.DatatableClientSideAsync(datatableRequest: request, cancellationToken: cancellationToken);
            return Result<DatatableResponseClientSide<StockMovement>>.Success(result);
        }

        public async Task<Result<DatatableResponseServerSide<StockMovementReportDto>>> DatatableServerSideAsync(DynamicDatatableRequest request, CancellationToken cancellationToken = default)
        {
            var result = await _unitOfWork.StockMovements.DatatableServerSideAsync(
                datatableRequest: request,
                select: s => new StockMovementReportDto
                {
                    Id = s.Id,
                    StockModelName = s.Stock != null ? s.Stock.ModelName : null,
                    StockMovementTypeName = s.StockMovementType != null ? s.StockMovementType.Name : null,
                    InOutCode = s.StockMovementType != null ? s.StockMovementType.InOutCode : ' ',
                    UserName = s.User != null ? s.User.Name + " " + s.User.SurName : null,
                    Quantity = s.Quantity,
                    WarehouseName = s.Warehouse != null ? s.Warehouse.Name : null,
                    FaultTypeName = s.FaultType != null ? s.FaultType.Name : null,
                    CompanyProductName = s.CompanyProduct != null ? s.CompanyProduct.Name : null,
                    Date = s.Date,
                    CreateDateUtc = s.CreateDateUtc
                },
                cancellationToken: cancellationToken);
            return Result<DatatableResponseServerSide<StockMovementReportDto>>.Success(result);
        }

        /// <summary>Intermediate projection for <see cref="SelectListAsync"/>; label is built in memory.</summary>
        private sealed class StockMovementSelectRow
        {
            public Guid Id { get; set; }
            public DateTime Date { get; set; }
            public decimal Quantity { get; set; }
        }
    }
}
