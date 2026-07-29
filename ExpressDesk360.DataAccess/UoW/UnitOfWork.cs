using ExpressDesk360.DataAccess.Abstract;
using ExpressDesk360.DataAccess.Contexts;
using Microsoft.EntityFrameworkCore.Storage;

namespace ExpressDesk360.DataAccess.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private IDbContextTransaction? _transaction;
        private readonly AppDbContext _context;
        public IBOMRepository BOMs { get; private set; }
        public IBOMItemRepository BOMItems { get; private set; }
        public ICargoCompanyRepository CargoCompanies { get; private set; }
        public ICompanyRepository Companies { get; private set; }
        public ICompanyContactRepository CompanyContacts { get; private set; }
        public ICompanyFileRepository CompanyFiles { get; private set; }
        public ICompanyProductRepository CompanyProducts { get; private set; }
        public ICompanyProductStockSerialMapRepository CompanyProductStockSerialMaps { get; private set; }
        public ICompanyProductWarrantyRepository CompanyProductWarranties { get; private set; }
        public IContactTypeRepository ContactTypes { get; private set; }
        public ICurrencyRepository Currencies { get; private set; }
        public IFaultTypeRepository FaultTypes { get; private set; }
        public IFSFileRepository FSFiles { get; private set; }
        public IFSFolderRepository FSFolders { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IInvoiceTypeRepository InvoiceTypes { get; private set; }
        public IProjectRepository Projects { get; private set; }
        public IProjectFileRepository ProjectFiles { get; private set; }
        public IProjectMovementRepository ProjectMovements { get; private set; }
        public IProjectMovementTypeRepository ProjectMovementTypes { get; private set; }
        public IProjectStaffRepository ProjectStaffs { get; private set; }
        public IProjectStatusRepository ProjectStatuses { get; private set; }
        public IShippingRepository Shippings { get; private set; }
        public IShippingFileRepository ShippingFiles { get; private set; }
        public IShippingTypeRepository ShippingTypes { get; private set; }
        public IStockRepository Stocks { get; private set; }
        public IStockBrandRepository StockBrands { get; private set; }
        public IStockGroupRepository StockGroups { get; private set; }
        public IStockGroupBrandMapRepository StockGroupBrandMaps { get; private set; }
        public IStockGroupFaultTypeMapRepository StockGroupFaultTypeMaps { get; private set; }
        public IStockMovementRepository StockMovements { get; private set; }
        public IStockMovementStockSerialMapRepository StockMovementStockSerialMaps { get; private set; }
        public IStockMovementTypeRepository StockMovementTypes { get; private set; }
        public IStockSerialRepository StockSerials { get; private set; }
        public IStockSerialWarrantyRepository StockSerialWarranties { get; private set; }
        public IStockTypeRepository StockTypes { get; private set; }
        public IStockTypeGroupMapRepository StockTypeGroupMaps { get; private set; }
        public I_TaskRepository _Tasks { get; private set; }
        public I_TaskFileRepository _TaskFiles { get; private set; }
        public I_TaskMovementRepository _TaskMovements { get; private set; }
        public I_TaskMovementTypeRepository _TaskMovementTypes { get; private set; }
        public I_TaskPriorityRepository _TaskPriorities { get; private set; }
        public I_TaskStaffRepository _TaskStaffs { get; private set; }
        public I_TaskStatusRepository _TaskStatuses { get; private set; }
        public ITicketRepository Tickets { get; private set; }
        public ITicketFileRepository TicketFiles { get; private set; }
        public ITicketMessageRepository TicketMessages { get; private set; }
        public ITicketMessageFileRepository TicketMessageFiles { get; private set; }
        public ITicketMovementRepository TicketMovements { get; private set; }
        public ITicketMovementFileRepository TicketMovementFiles { get; private set; }
        public ITicketMovementTypeRepository TicketMovementTypes { get; private set; }
        public ITicketPriorityRepository TicketPriorities { get; private set; }
        public ITicketServicePriceRepository TicketServicePrices { get; private set; }
        public ITicketStaffRepository TicketStaffs { get; private set; }
        public ITicketStatusRepository TicketStatuses { get; private set; }
        public ITicketTypeRepository TicketTypes { get; private set; }
        public IUnitRepository Units { get; private set; }
        public IUserRepository Users { get; private set; }
        public IUserContactRepository UserContacts { get; private set; }
        public IUserFileRepository UserFiles { get; private set; }
        public IWarehouseRepository Warehouses { get; private set; }
        public IWarrantyTypeRepository WarrantyTypes { get; private set; }
        public IRefreshTokenRepository RefreshTokens { get; private set; }

        public UnitOfWork(AppDbContext context, IBOMRepository bOMRepository, IBOMItemRepository bOMItemRepository, ICargoCompanyRepository cargoCompanyRepository, ICompanyRepository companyRepository, ICompanyContactRepository companyContactRepository, ICompanyFileRepository companyFileRepository, ICompanyProductRepository companyProductRepository, ICompanyProductStockSerialMapRepository companyProductStockSerialMapRepository, ICompanyProductWarrantyRepository companyProductWarrantyRepository, IContactTypeRepository contactTypeRepository, ICurrencyRepository currencyRepository, IFaultTypeRepository faultTypeRepository, IFSFileRepository fSFileRepository, IFSFolderRepository fSFolderRepository, IInvoiceRepository invoiceRepository, IInvoiceTypeRepository invoiceTypeRepository, IProjectRepository projectRepository, IProjectFileRepository projectFileRepository, IProjectMovementRepository projectMovementRepository, IProjectMovementTypeRepository projectMovementTypeRepository, IProjectStaffRepository projectStaffRepository, IProjectStatusRepository projectStatusRepository, IShippingRepository shippingRepository, IShippingFileRepository shippingFileRepository, IShippingTypeRepository shippingTypeRepository, IStockRepository stockRepository, IStockBrandRepository stockBrandRepository, IStockGroupRepository stockGroupRepository, IStockGroupBrandMapRepository stockGroupBrandMapRepository, IStockGroupFaultTypeMapRepository stockGroupFaultTypeMapRepository, IStockMovementRepository stockMovementRepository, IStockMovementStockSerialMapRepository stockMovementStockSerialMapRepository, IStockMovementTypeRepository stockMovementTypeRepository, IStockSerialRepository stockSerialRepository, IStockSerialWarrantyRepository stockSerialWarrantyRepository, IStockTypeRepository stockTypeRepository, IStockTypeGroupMapRepository stockTypeGroupMapRepository, I_TaskRepository _TaskRepository, I_TaskFileRepository _TaskFileRepository, I_TaskMovementRepository _TaskMovementRepository, I_TaskMovementTypeRepository _TaskMovementTypeRepository, I_TaskPriorityRepository _TaskPriorityRepository, I_TaskStaffRepository _TaskStaffRepository, I_TaskStatusRepository _TaskStatusRepository, ITicketRepository ticketRepository, ITicketFileRepository ticketFileRepository, ITicketMessageRepository ticketMessageRepository, ITicketMessageFileRepository ticketMessageFileRepository, ITicketMovementRepository ticketMovementRepository, ITicketMovementFileRepository ticketMovementFileRepository, ITicketMovementTypeRepository ticketMovementTypeRepository, ITicketPriorityRepository ticketPriorityRepository, ITicketServicePriceRepository ticketServicePriceRepository, ITicketStaffRepository ticketStaffRepository, ITicketStatusRepository ticketStatusRepository, ITicketTypeRepository ticketTypeRepository, IUnitRepository unitRepository, IUserRepository userRepository, IUserContactRepository userContactRepository, IUserFileRepository userFileRepository, IWarehouseRepository warehouseRepository, IWarrantyTypeRepository warrantyTypeRepository, IRefreshTokenRepository refreshTokenRepository)
        {
            _context = context;
            BOMs = bOMRepository;
            BOMItems = bOMItemRepository;
            CargoCompanies = cargoCompanyRepository;
            Companies = companyRepository;
            CompanyContacts = companyContactRepository;
            CompanyFiles = companyFileRepository;
            CompanyProducts = companyProductRepository;
            CompanyProductStockSerialMaps = companyProductStockSerialMapRepository;
            CompanyProductWarranties = companyProductWarrantyRepository;
            ContactTypes = contactTypeRepository;
            Currencies = currencyRepository;
            FaultTypes = faultTypeRepository;
            FSFiles = fSFileRepository;
            FSFolders = fSFolderRepository;
            Invoices = invoiceRepository;
            InvoiceTypes = invoiceTypeRepository;
            Projects = projectRepository;
            ProjectFiles = projectFileRepository;
            ProjectMovements = projectMovementRepository;
            ProjectMovementTypes = projectMovementTypeRepository;
            ProjectStaffs = projectStaffRepository;
            ProjectStatuses = projectStatusRepository;
            Shippings = shippingRepository;
            ShippingFiles = shippingFileRepository;
            ShippingTypes = shippingTypeRepository;
            Stocks = stockRepository;
            StockBrands = stockBrandRepository;
            StockGroups = stockGroupRepository;
            StockGroupBrandMaps = stockGroupBrandMapRepository;
            StockGroupFaultTypeMaps = stockGroupFaultTypeMapRepository;
            StockMovements = stockMovementRepository;
            StockMovementStockSerialMaps = stockMovementStockSerialMapRepository;
            StockMovementTypes = stockMovementTypeRepository;
            StockSerials = stockSerialRepository;
            StockSerialWarranties = stockSerialWarrantyRepository;
            StockTypes = stockTypeRepository;
            StockTypeGroupMaps = stockTypeGroupMapRepository;
            _Tasks = _TaskRepository;
            _TaskFiles = _TaskFileRepository;
            _TaskMovements = _TaskMovementRepository;
            _TaskMovementTypes = _TaskMovementTypeRepository;
            _TaskPriorities = _TaskPriorityRepository;
            _TaskStaffs = _TaskStaffRepository;
            _TaskStatuses = _TaskStatusRepository;
            Tickets = ticketRepository;
            TicketFiles = ticketFileRepository;
            TicketMessages = ticketMessageRepository;
            TicketMessageFiles = ticketMessageFileRepository;
            TicketMovements = ticketMovementRepository;
            TicketMovementFiles = ticketMovementFileRepository;
            TicketMovementTypes = ticketMovementTypeRepository;
            TicketPriorities = ticketPriorityRepository;
            TicketServicePrices = ticketServicePriceRepository;
            TicketStaffs = ticketStaffRepository;
            TicketStatuses = ticketStatusRepository;
            TicketTypes = ticketTypeRepository;
            Units = unitRepository;
            Users = userRepository;
            UserContacts = userContactRepository;
            UserFiles = userFileRepository;
            Warehouses = warehouseRepository;
            WarrantyTypes = warrantyTypeRepository;
            RefreshTokens = refreshTokenRepository;
        }

        public int SaveChanges()
        {
            return _context.SaveChanges();
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
                throw new InvalidOperationException("Transaction already started for begin transaction.");
            _transaction = _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            if (_transaction == null) return;
            try
            {
                _transaction.Commit();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public void RollbackTransaction()
        {
            if (_transaction == null) return;
            try
            {
                _transaction.Rollback();
            }
            finally
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await _context.SaveChangesAsync(cancellationToken);
        }

        public async Task BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction != null)
                throw new InvalidOperationException("Transaction already started for begin transaction.");
            _transaction = await _context.Database.BeginTransactionAsync(cancellationToken);
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) return;
            try
            {
                await _transaction.CommitAsync(cancellationToken);
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (_transaction == null) return;
            try
            {
                await _transaction.RollbackAsync(cancellationToken);
            }
            finally
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async ValueTask DisposeAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }
    }
}