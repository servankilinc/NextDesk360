using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using ExpressDesk360.Business.Concrete;
using ExpressDesk360.Business.Utils.TokenService;
using ExpressDesk360.Business.Abstract.StockModule;
using ExpressDesk360.Business.Concrete.StockModule;
using ExpressDesk360.Business.Abstract.ProductionModule;
using ExpressDesk360.Business.Abstract.ShippingModule;
using ExpressDesk360.Business.Abstract.InvoiceModule;
using ExpressDesk360.Business.Abstract.ProjectModule;
using ExpressDesk360.Business.Abstract.Common;
using ExpressDesk360.Business.Abstract.CompanyModule;
using ExpressDesk360.Business.Abstract.TaskModule;
using ExpressDesk360.Business.Abstract.TicketModule;
using ExpressDesk360.Business.Abstract.UserModule;

namespace ExpressDesk360.Business
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddBusinessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<ITokenService, TokenService>();
            services.AddScoped<IAuthService, AuthService>();
#region ENTITY SERVICES
            services.AddScoped<IBOMService, BOMService>();
            services.AddScoped<IBOMItemService, BOMItemService>();
            services.AddScoped<ICargoCompanyService, CargoCompanyService>();
            services.AddScoped<ICompanyService, CompanyService>();
            services.AddScoped<ICompanyContactService, CompanyContactService>();
            services.AddScoped<ICompanyFileService, CompanyFileService>();
            services.AddScoped<ICompanyProductService, CompanyProductService>();
            services.AddScoped<ICompanyProductStockSerialMapService, CompanyProductStockSerialMapService>();
            services.AddScoped<ICompanyProductWarrantyService, CompanyProductWarrantyService>();
            services.AddScoped<IContactTypeService, ContactTypeService>();
            services.AddScoped<ICurrencyService, CurrencyService>();
            services.AddScoped<IFaultTypeService, FaultTypeService>();
            services.AddScoped<IFSFileService, FSFileService>();
            services.AddScoped<IFSFolderService, FSFolderService>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceTypeService, InvoiceTypeService>();
            services.AddScoped<IProjectService, ProjectService>();
            services.AddScoped<IProjectFileService, ProjectFileService>();
            services.AddScoped<IProjectMovementService, ProjectMovementService>();
            services.AddScoped<IProjectMovementTypeService, ProjectMovementTypeService>();
            services.AddScoped<IProjectStaffService, ProjectStaffService>();
            services.AddScoped<IProjectStatusService, ProjectStatusService>();
            services.AddScoped<IShippingService, ShippingService>();
            services.AddScoped<IShippingFileService, ShippingFileService>();
            services.AddScoped<IShippingTypeService, ShippingTypeService>();
            services.AddScoped<IStockService, StockService>();
            services.AddScoped<IStockBrandService, StockBrandService>();
            services.AddScoped<IStockGroupService, StockGroupService>();
            services.AddScoped<IStockGroupBrandMapService, StockGroupBrandMapService>();
            services.AddScoped<IStockGroupFaultTypeMapService, StockGroupFaultTypeMapService>();
            services.AddScoped<IStockMovementService, StockMovementService>();
            services.AddScoped<IStockMovementStockSerialMapService, StockMovementStockSerialMapService>();
            services.AddScoped<IStockMovementTypeService, StockMovementTypeService>();
            services.AddScoped<IStockSerialService, StockSerialService>();
            services.AddScoped<IStockSerialWarrantyService, StockSerialWarrantyService>();
            services.AddScoped<IStockTypeService, StockTypeService>();
            services.AddScoped<IStockTypeGroupMapService, StockTypeGroupMapService>();
            services.AddScoped<ITaskService, _TaskService>();
            services.AddScoped<ITaskFileService, _TaskFileService>();
            services.AddScoped<ITaskMovementService, _TaskMovementService>();
            services.AddScoped<ITaskMovementTypeService, _TaskMovementTypeService>();
            services.AddScoped<ITaskPriorityService, _TaskPriorityService>();
            services.AddScoped<ITaskStaffService, _TaskStaffService>();
            services.AddScoped<ITaskStatusService, _TaskStatusService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<ITicketFileService, TicketFileService>();
            services.AddScoped<ITicketMessageService, TicketMessageService>();
            services.AddScoped<ITicketMessageFileService, TicketMessageFileService>();
            services.AddScoped<ITicketMovementService, TicketMovementService>();
            services.AddScoped<ITicketMovementFileService, TicketMovementFileService>();
            services.AddScoped<ITicketMovementTypeService, TicketMovementTypeService>();
            services.AddScoped<ITicketPriorityService, TicketPriorityService>();
            services.AddScoped<ITicketServicePriceService, TicketServicePriceService>();
            services.AddScoped<ITicketStaffService, TicketStaffService>();
            services.AddScoped<ITicketStatusService, TicketStatusService>();
            services.AddScoped<ITicketTypeService, TicketTypeService>();
            services.AddScoped<IUnitService, UnitService>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserContactService, UserContactService>();
            services.AddScoped<IUserFileService, UserFileService>();
            services.AddScoped<IWarehouseService, WarehouseService>();
            services.AddScoped<IWarrantyTypeService, WarrantyTypeService>();
#endregion
            return services;
        }
    }
}