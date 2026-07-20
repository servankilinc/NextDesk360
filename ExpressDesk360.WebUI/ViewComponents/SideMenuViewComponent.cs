using Microsoft.AspNetCore.Mvc;
using ExpressDesk360.WebUI.Models.UI;

namespace ExpressDesk360.WebUI.ViewComponents
{
    public class SideMenuViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            var menuItems = new List<MenuItem>
            {
                new MenuItem
                {
                    Title = "Dashboard",
                    Icon = "<i class=\"ki-duotone ki-element-11 fs-2\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span><span class=\"path4\"></span></i>",
                    Path = "/Home/Index"
                },
                new MenuItem
                {
                    Title = "Pages",
                    Icon = "<i class=\"fa-regular fa-folder-open\"></i>",
                    GroupName = "Pages",
                    SubMenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = "_Task",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/_Task/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "_TaskFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/_TaskFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "_TaskMovement",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/_TaskMovement/Index"
                        //},
                        new MenuItem
                        {
                            Title = "_TaskMovementType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/_TaskMovementType/Index"
                        },
                        new MenuItem
                        {
                            Title = "_TaskPriority",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/_TaskPriority/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "_TaskStaff",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/_TaskStaff/Index"
                        //},
                        new MenuItem
                        {
                            Title = "_TaskStatus",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/_TaskStatus/Index"
                        },
                        new MenuItem
                        {
                            Title = "BOM",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/BOM/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "BOMItem",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/BOMItem/Index"
                        //},
                        new MenuItem
                        {
                            Title = "CargoCompany",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/CargoCompany/Index"
                        },
                        new MenuItem
                        {
                            Title = "Company",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Company/Index"
                        },
                        new MenuItem
                        {
                            Title = "CompanyContact",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/CompanyContact/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "CompanyFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/CompanyFile/Index"
                        //},
                        new MenuItem
                        {
                            Title = "CompanyProduct",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/CompanyProduct/Index"
                        },
                        new MenuItem
                        {
                            Title = "CompanyProductStockSerialMap",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/CompanyProductStockSerialMap/Index"
                        },
                        new MenuItem
                        {
                            Title = "CompanyProductWarranty",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/CompanyProductWarranty/Index"
                        },
                        new MenuItem
                        {
                            Title = "ContactType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/ContactType/Index"
                        },
                        new MenuItem
                        {
                            Title = "Currency",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Currency/Index"
                        },
                        new MenuItem
                        {
                            Title = "FaultType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/FaultType/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "FSFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/FSFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "FSFolder",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/FSFolder/Index"
                        //},
                        new MenuItem
                        {
                            Title = "Invoice",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Invoice/Index"
                        },
                        new MenuItem
                        {
                            Title = "InvoiceType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/InvoiceType/Index"
                        },
                        new MenuItem
                        {
                            Title = "Project",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Project/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "ProjectFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/ProjectFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "ProjectMovement",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/ProjectMovement/Index"
                        //},
                        new MenuItem
                        {
                            Title = "ProjectMovementType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/ProjectMovementType/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "ProjectStaff",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/ProjectStaff/Index"
                        //},
                        new MenuItem
                        {
                            Title = "ProjectStatus",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/ProjectStatus/Index"
                        },
                        new MenuItem
                        {
                            Title = "Shipping",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Shipping/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "ShippingFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/ShippingFile/Index"
                        //},
                        new MenuItem
                        {
                            Title = "ShippingType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/ShippingType/Index"
                        },
                        new MenuItem
                        {
                            Title = "Stock",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Stock/Index"
                        },
                        new MenuItem
                        {
                            Title = "StockBrand",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/StockBrand/Index"
                        },
                        new MenuItem
                        {
                            Title = "StockGroup",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/StockGroup/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "StockGroupBrandMap",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockGroupBrandMap/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockGroupFaultTypeMap",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockGroupFaultTypeMap/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockMovement",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockMovement/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockMovementStockSerialMap",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockMovementStockSerialMap/Index"
                        //},
                        //new MenuItem // *** sistemde kod içerisinde olması gerekiyor o yüzden kullanıcı ekleyemez ***
                        //{
                        //    Title = "StockMovementType",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockMovementType/Index"
                        //},
                        new MenuItem
                        {
                            Title = "StockSerial",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/StockSerial/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "StockSerialWarranty",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockSerialWarranty/Index"
                        //},
                        //new MenuItem // *** sistemde kod içerisinde olması gerekiyor o yüzden kullanıcı ekleyemez ***
                        //{
                        //    Title = "StockType",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockType/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockTypeGroupMap",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/StockTypeGroupMap/Index"
                        //},
                        new MenuItem
                        {
                            Title = "Ticket",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Ticket/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "TicketFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMessage",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketMessage/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMessageFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketMessageFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMovement",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketMovement/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMovementFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketMovementFile/Index"
                        //},
                        //new MenuItem // *** sistemde kod içerisinde olması gerekiyor o yüzden kullanıcı ekleyemez ***
                        //{
                        //    Title = "TicketMovementType",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketMovementType/Index"
                        //},
                        new MenuItem
                        {
                            Title = "TicketPriority",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/TicketPriority/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "TicketServicePrice",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketServicePrice/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketStaff",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/TicketStaff/Index"
                        //},
                        new MenuItem
                        {
                            Title = "TicketStatus",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/TicketStatus/Index"
                        },
                        new MenuItem
                        {
                            Title = "TicketType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/TicketType/Index"
                        },
                        new MenuItem
                        {
                            Title = "Unit",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Unit/Index"
                        },
                        new MenuItem
                        {
                            Title = "User",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/User/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "UserContact",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/UserContact/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "UserFile",
                        //    Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                        //    Path = "/UserFile/Index"
                        //},
                        new MenuItem
                        {
                            Title = "Warehouse",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/Warehouse/Index"
                        },
                        new MenuItem
                        {
                            Title = "WarrantyType",
                            Icon = "<i class=\"ki-duotone ki-right text-gray-900 fs-2tx\"></i>",
                            Path = "/WarrantyType/Index"
                        }
                    }
                }
            };
            string currentPath = (HttpContext.Request.Path.Value ?? string.Empty).TrimEnd('/'); foreach  ( var  menu  in  menuItems ) { HandleActiveMenu ( menu ,  currentPath ) ;  } return  View ( menuItems ) ; 
        }

        private bool HandleActiveMenu(MenuItem item, string currentPath)
        {
            bool isActive = !string.IsNullOrWhiteSpace(item.Path) && (currentPath.Equals(item.Path, StringComparison.OrdinalIgnoreCase) || currentPath.StartsWith(item.Path + "/", StringComparison.OrdinalIgnoreCase));
            bool hasActiveChild = false;
            if (item.SubMenuItems != null)
            {
                foreach (var child in item.SubMenuItems)
                {
                    if (HandleActiveMenu(child, currentPath))
                        hasActiveChild = true;
                }
            }

            item.IsActive = isActive;
            item.HasActiveChild = hasActiveChild;
            return isActive || hasActiveChild;
        }
    }
}