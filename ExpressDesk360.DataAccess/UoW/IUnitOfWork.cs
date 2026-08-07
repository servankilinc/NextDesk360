using ExpressDesk360.DataAccess.Abstract.Common;
using ExpressDesk360.DataAccess.Abstract.CompanyModule;
using ExpressDesk360.DataAccess.Abstract.InvoiceModule;
using ExpressDesk360.DataAccess.Abstract.ProductionModule;
using ExpressDesk360.DataAccess.Abstract.ProjectModule;
using ExpressDesk360.DataAccess.Abstract.ShippingModule;
using ExpressDesk360.DataAccess.Abstract.StockModule;
using ExpressDesk360.DataAccess.Abstract.TaskModule;
using ExpressDesk360.DataAccess.Abstract.TicketModule;
using ExpressDesk360.DataAccess.Abstract.UserModule;

namespace ExpressDesk360.DataAccess.UoW
{
    public interface IUnitOfWork : IDisposable, IAsyncDisposable
    {
        IBOMRepository BOMs { get; }

        IBOMItemRepository BOMItems { get; }

        ICargoCompanyRepository CargoCompanies { get; }

        ICompanyRepository Companies { get; }

        ICompanyContactRepository CompanyContacts { get; }

        ICompanyFileRepository CompanyFiles { get; }

        ICompanyProductRepository CompanyProducts { get; }

        ICompanyProductStockSerialMapRepository CompanyProductStockSerialMaps { get; }

        ICompanyProductWarrantyRepository CompanyProductWarranties { get; }

        IContactTypeRepository ContactTypes { get; }

        ICurrencyRepository Currencies { get; }

        IFaultTypeRepository FaultTypes { get; }

        IFSFileRepository FSFiles { get; }

        IFSFolderRepository FSFolders { get; }

        IInvoiceRepository Invoices { get; }

        IInvoiceTypeRepository InvoiceTypes { get; }

        IProjectRepository Projects { get; }

        IProjectFileRepository ProjectFiles { get; }

        IProjectMovementRepository ProjectMovements { get; }

        IProjectMovementTypeRepository ProjectMovementTypes { get; }

        IProjectStaffRepository ProjectStaffs { get; }

        IProjectStatusRepository ProjectStatuses { get; }

        IShippingRepository Shippings { get; }

        IShippingFileRepository ShippingFiles { get; }

        IShippingTypeRepository ShippingTypes { get; }

        IStockRepository Stocks { get; }

        IStockBrandRepository StockBrands { get; }

        IStockGroupRepository StockGroups { get; }

        IStockGroupBrandMapRepository StockGroupBrandMaps { get; }

        IStockGroupFaultTypeMapRepository StockGroupFaultTypeMaps { get; }

        IStockMovementRepository StockMovements { get; }

        IStockMovementStockSerialMapRepository StockMovementStockSerialMaps { get; }

        IStockMovementTypeRepository StockMovementTypes { get; }

        IStockSerialRepository StockSerials { get; }

        IStockSerialWarrantyRepository StockSerialWarranties { get; }



        IStockTypeRepository StockTypes { get; }

        IStockTypeGroupMapRepository StockTypeGroupMaps { get; }

        ITaskRepository _Tasks { get; }

        ITaskFileRepository _TaskFiles { get; }

        ITaskMovementRepository _TaskMovements { get; }

        ITaskMovementTypeRepository _TaskMovementTypes { get; }

        ITaskPriorityRepository _TaskPriorities { get; }

        ITaskStaffRepository _TaskStaffs { get; }

        ITaskStatusRepository _TaskStatuses { get; }

        ITicketRepository Tickets { get; }

        ITicketFileRepository TicketFiles { get; }

        ITicketMessageRepository TicketMessages { get; }

        ITicketMessageFileRepository TicketMessageFiles { get; }

        ITicketMovementRepository TicketMovements { get; }

        ITicketMovementFileRepository TicketMovementFiles { get; }

        ITicketMovementTypeRepository TicketMovementTypes { get; }

        ITicketPriorityRepository TicketPriorities { get; }

        ITicketServicePriceRepository TicketServicePrices { get; }

        ITicketStaffRepository TicketStaffs { get; }

        ITicketStatusRepository TicketStatuses { get; }

        ITicketTypeRepository TicketTypes { get; }

        IUnitRepository Units { get; }

        IUserRepository Users { get; }

        IUserContactRepository UserContacts { get; }

        IUserFileRepository UserFiles { get; }

        IWarehouseRepository Warehouses { get; }

        IWarrantyTypeRepository WarrantyTypes { get; }

        IRefreshTokenRepository RefreshTokens { get; }

        int SaveChanges();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        Task BeginTransactionAsync(CancellationToken cancellationToken = default);
        Task CommitTransactionAsync(CancellationToken cancellationToken = default);
        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);
    }
}