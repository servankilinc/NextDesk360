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
using ExpressDesk360.DataAccess.Concrete.Common;
using ExpressDesk360.DataAccess.Concrete.CompanyModule;
using ExpressDesk360.DataAccess.Concrete.InvoiceModule;
using ExpressDesk360.DataAccess.Concrete.ProductionModule;
using ExpressDesk360.DataAccess.Concrete.ProjectModule;
using ExpressDesk360.DataAccess.Concrete.ShippingModule;
using ExpressDesk360.DataAccess.Concrete.StockModule;
using ExpressDesk360.DataAccess.Concrete.TaskModule;
using ExpressDesk360.DataAccess.Concrete.TicketModule;
using ExpressDesk360.DataAccess.Concrete.UserModule;
using ExpressDesk360.DataAccess.Contexts;
using ExpressDesk360.DataAccess.Interceptors;
using ExpressDesk360.DataAccess.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ExpressDesk360.DataAccess
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IBOMRepository, BOMRepository>();
            services.AddScoped<IBOMItemRepository, BOMItemRepository>();
            services.AddScoped<ICargoCompanyRepository, CargoCompanyRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyContactRepository, CompanyContactRepository>();
            services.AddScoped<ICompanyFileRepository, CompanyFileRepository>();
            services.AddScoped<ICompanyProductRepository, CompanyProductRepository>();
            services.AddScoped<ICompanyProductStockSerialMapRepository, CompanyProductStockSerialMapRepository>();
            services.AddScoped<ICompanyProductWarrantyRepository, CompanyProductWarrantyRepository>();
            services.AddScoped<IContactTypeRepository, ContactTypeRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IFaultTypeRepository, FaultTypeRepository>();
            services.AddScoped<IFSFileRepository, FSFileRepository>();
            services.AddScoped<IFSFolderRepository, FSFolderRepository>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceTypeRepository, InvoiceTypeRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<IProjectFileRepository, ProjectFileRepository>();
            services.AddScoped<IProjectMovementRepository, ProjectMovementRepository>();
            services.AddScoped<IProjectMovementTypeRepository, ProjectMovementTypeRepository>();
            services.AddScoped<IProjectStaffRepository, ProjectStaffRepository>();
            services.AddScoped<IProjectStatusRepository, ProjectStatusRepository>();
            services.AddScoped<IShippingRepository, ShippingRepository>();
            services.AddScoped<IShippingFileRepository, ShippingFileRepository>();
            services.AddScoped<IShippingTypeRepository, ShippingTypeRepository>();
            services.AddScoped<IStockRepository, StockRepository>();
            services.AddScoped<IStockBrandRepository, StockBrandRepository>();
            services.AddScoped<IStockGroupRepository, StockGroupRepository>();
            services.AddScoped<IStockGroupBrandMapRepository, StockGroupBrandMapRepository>();
            services.AddScoped<IStockGroupFaultTypeMapRepository, StockGroupFaultTypeMapRepository>();
            services.AddScoped<IStockMovementRepository, StockMovementRepository>();
            services.AddScoped<IStockMovementStockSerialMapRepository, StockMovementStockSerialMapRepository>();
            services.AddScoped<IStockMovementTypeRepository, StockMovementTypeRepository>();
            services.AddScoped<IStockSerialRepository, StockSerialRepository>();
            services.AddScoped<IStockSerialWarrantyRepository, StockSerialWarrantyRepository>();
            services.AddScoped<IStockTypeRepository, StockTypeRepository>();
            services.AddScoped<IStockTypeGroupMapRepository, StockTypeGroupMapRepository>();
            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskFileRepository, TaskFileRepository>();
            services.AddScoped<ITaskMovementRepository, TaskMovementRepository>();
            services.AddScoped<ITaskMovementTypeRepository, TaskMovementTypeRepository>();
            services.AddScoped<ITaskPriorityRepository, TaskPriorityRepository>();
            services.AddScoped<ITaskStaffRepository, TaskStaffRepository>();
            services.AddScoped<ITaskStatusRepository, TaskStatusRepository>();
            services.AddScoped<ITicketRepository, TicketRepository>();
            services.AddScoped<ITicketFileRepository, TicketFileRepository>();
            services.AddScoped<ITicketMessageRepository, TicketMessageRepository>();
            services.AddScoped<ITicketMessageFileRepository, TicketMessageFileRepository>();
            services.AddScoped<ITicketMovementRepository, TicketMovementRepository>();
            services.AddScoped<ITicketMovementFileRepository, TicketMovementFileRepository>();
            services.AddScoped<ITicketMovementTypeRepository, TicketMovementTypeRepository>();
            services.AddScoped<ITicketPriorityRepository, TicketPriorityRepository>();
            services.AddScoped<ITicketServicePriceRepository, TicketServicePriceRepository>();
            services.AddScoped<ITicketStaffRepository, TicketStaffRepository>();
            services.AddScoped<ITicketStatusRepository, TicketStatusRepository>();
            services.AddScoped<ITicketTypeRepository, TicketTypeRepository>();
            services.AddScoped<IUnitRepository, UnitRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserContactRepository, UserContactRepository>();
            services.AddScoped<IUserFileRepository, UserFileRepository>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IWarrantyTypeRepository, WarrantyTypeRepository>();
            services.AddScoped<IRefreshTokenRepository, RefreshTokenRepository>();
            #region DB CONTEXT
            services.AddSingleton<AuditInterceptor>();
            services.AddSingleton<ArchiveInterceptor>();
            services.AddSingleton<EntityLifecycleInterceptor>();
            services.AddDbContext<AppDbContext>((serviceProvider, opt) =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Database"))
                   .AddInterceptors(serviceProvider.GetRequiredService<AuditInterceptor>())
                   .AddInterceptors(serviceProvider.GetRequiredService<ArchiveInterceptor>())
                   .AddInterceptors(serviceProvider.GetRequiredService<EntityLifecycleInterceptor>());
            });
            #endregion
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}