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
                    Title = "Ticket",
                    Icon = "<i class=\"ki-duotone ki-delivery-24 fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span><span class=\"path4\"></span></i>",
                    GroupName = "Ticket",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "Ticket",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Ticket/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "TicketFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMessage",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketMessage/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMessageFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketMessageFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMovement",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketMovement/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketMovementFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketMovementFile/Index"
                        //},
                        //new MenuItem // *** sistemde kod içerisinde olması gerekiyor o yüzden kullanıcı ekleyemez ***
                        //{
                        //    Title = "TicketMovementType",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketMovementType/Index"
                        //},
                        new MenuItem
                        {
                            Title = "TicketPriority",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/TicketPriority/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "TicketServicePrice",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketServicePrice/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "TicketStaff",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/TicketStaff/Index"
                        //},
                        new MenuItem
                        {
                            Title = "TicketStatus",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/TicketStatus/Index"
                        },
                        new MenuItem
                        {
                            Title = "TicketType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/TicketType/Index"
                        },
                        new MenuItem
                        {
                            Title = "FaultType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/FaultType/Index"
                        },
                    }
                },

               new MenuItem
                {
                    Title = "Stock",
                    Icon = "<i class=\"ki-duotone ki-parcel-tracking fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span></i>",
                    GroupName = "Stock",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "Stock",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Stock/Index"
                        },
                        new MenuItem
                        {
                            Title = "StockBrand",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/StockBrand/Index"
                        },
                        new MenuItem
                        {
                            Title = "StockGroup",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/StockGroup/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "StockGroupBrandMap",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockGroupBrandMap/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockGroupFaultTypeMap",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockGroupFaultTypeMap/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockMovement",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockMovement/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockMovementStockSerialMap",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockMovementStockSerialMap/Index"
                        //},
                        //new MenuItem // *** sistemde kod içerisinde olması gerekiyor o yüzden kullanıcı ekleyemez ***
                        //{
                        //    Title = "StockMovementType",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockMovementType/Index"
                        //},
                        new MenuItem
                        {
                            Title = "StockSerial",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/StockSerial/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "StockSerialWarranty",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockSerialWarranty/Index"
                        //},
                        //new MenuItem // *** sistemde kod içerisinde olması gerekiyor o yüzden kullanıcı ekleyemez ***
                        //{
                        //    Title = "StockType",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockType/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "StockTypeGroupMap",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/StockTypeGroupMap/Index"
                        //},

                        new MenuItem
                        {
                            Title = "Unit",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Unit/Index"
                        },
                        new MenuItem
                        {
                            Title = "Warehouse",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Warehouse/Index"
                        },
                    }
                },

                new MenuItem
                {
                    Title = "Shipping",
                    Icon = "<i class=\"ki-duotone ki-delivery-time fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span><span class=\"path4\"></span><span class=\"path5\"></span></i>",
                    GroupName = "Shipping",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "Shipping",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Shipping/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "ShippingFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/ShippingFile/Index"
                        //},
                        new MenuItem
                        {
                            Title = "ShippingType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/ShippingType/Index"
                        },
                        new MenuItem
                        {
                            Title = "CargoCompany",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/CargoCompany/Index"
                        },
                    }
                },

                new MenuItem
                {
                    Title = "Project",
                    Icon = "<i class=\"ki-duotone ki-some-files fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span></i>",
                    GroupName = "Project",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "Project",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Project/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "ProjectFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/ProjectFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "ProjectMovement",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/ProjectMovement/Index"
                        //},
                        new MenuItem
                        {
                            Title = "ProjectMovementType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/ProjectMovementType/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "ProjectStaff",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/ProjectStaff/Index"
                        //},
                        new MenuItem
                        {
                            Title = "ProjectStatus",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/ProjectStatus/Index"
                        },
                    }
                },


                new MenuItem
                {
                    Title = "Invoice",
                    Icon = "<i class=\"ki-duotone ki-cheque fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span><span class=\"path4\"></span><span class=\"path5\"></span><span class=\"path6\"></span><span class=\"path7\"></span></i>",
                    GroupName = "Invoice",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "Invoice",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Invoice/Index"
                        },
                        new MenuItem
                        {
                            Title = "InvoiceType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/InvoiceType/Index"
                        }
                    }
                },


                new MenuItem
                {
                    Title = "Company",
                    Icon = "<i class=\"ki-duotone ki-bank fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span></i>",
                    GroupName = "Company",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "Company",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Company/Index"
                        },
                        new MenuItem
                        {
                            Title = "CompanyContact",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/CompanyContact/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "CompanyFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/CompanyFile/Index"
                        //},
                    }
                },



                new MenuItem
                {
                    Title = "Task",
                    Icon = "<i class=\"ki-duotone ki-calendar-tick fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span><span class=\"path4\"></span><span class=\"path5\"></span><span class=\"path6\"></span></i>",
                    GroupName = "Task",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "_Task",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/_Task/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "_TaskFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/_TaskFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "_TaskMovement",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/_TaskMovement/Index"
                        //},
                        new MenuItem
                        {
                            Title = "_TaskMovementType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/_TaskMovementType/Index"
                        },
                        new MenuItem
                        {
                            Title = "_TaskPriority",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/_TaskPriority/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "_TaskStaff",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/_TaskStaff/Index"
                        //},
                        new MenuItem
                        {
                            Title = "_TaskStatus",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/_TaskStatus/Index"
                        },
                    }
                },


                new MenuItem
                {
                    Title = "Production",
                    Icon = "<i class=\"ki-duotone ki-laravel fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span><span class=\"path4\"></span><span class=\"path5\"></span><span class=\"path6\"></span><span class=\"path7\"></span></i>",
                    GroupName = "Production",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "CompanyProduct",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/CompanyProduct/Index"
                        },
                        new MenuItem
                        {
                            Title = "CompanyProductStockSerialMap",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/CompanyProductStockSerialMap/Index"
                        },
                        new MenuItem
                        {
                            Title = "CompanyProductWarranty",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/CompanyProductWarranty/Index"
                        },
                        new MenuItem
                        {
                            Title = "BOM",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/BOM/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "BOMItem",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/BOMItem/Index"
                        //},
                    }
                },


                new MenuItem
                {
                    Title = "Definations",
                    // <i class=\"ki-duotone ki-setting-2 fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span></i>
                    Icon = "<i class=\"ki-duotone ki-switch fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span></i>",
                    GroupName = "Definations",
                    SubMenuItems = new List<MenuItem>
                    {
                        new MenuItem
                        {
                            Title = "ContactType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/ContactType/Index"
                        },
                        new MenuItem
                        {
                            Title = "Currency",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/Currency/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "FSFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/FSFile/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "FSFolder",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/FSFolder/Index"
                        //},
                        new MenuItem
                        {
                            Title = "WarrantyType",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/WarrantyType/Index"
                        }
                    }
                },

                new MenuItem
                {
                    Title = "User",
                    Icon = "<i class=\"ki-duotone ki-user-edit fs-2x\"><span class=\"path1\"></span><span class=\"path2\"></span><span class=\"path3\"></span></i>",
                    GroupName = "User",
                    SubMenuItems = new List<MenuItem>{
                        new MenuItem
                        {
                            Title = "User",
                            Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                            Path = "/User/Index"
                        },
                        //new MenuItem
                        //{
                        //    Title = "UserContact",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/UserContact/Index"
                        //},
                        //new MenuItem
                        //{
                        //    Title = "UserFile",
                        //    Icon = "<i class=\"ki-outline ki-to-right text-gray-600 fs-8\"></i>",
                        //    Path = "/UserFile/Index"
                        //},
                    }
                },
            };
            string currentPath = (HttpContext.Request.Path.Value ?? string.Empty).TrimEnd('/'); foreach (var menu in menuItems) { HandleActiveMenu(menu, currentPath); }
            return View(menuItems);
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