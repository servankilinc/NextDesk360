using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ExpressDesk360.Model.Entities;
using ExpressDesk360.Model.ProjectEntities;
using ExpressDesk360.Model.Enums;
using ExpressDesk360.Core.Utils;

namespace ExpressDesk360.DataAccess.Contexts
{
    public class AppDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Production Tables
            modelBuilder.Entity<BOM>(b =>
            {
                b.ToTable("BOM");
                b.HasKey(b => b.Id);
                b.HasMany(b => b.BOMItems).WithOne(b => b.BOM).HasForeignKey(b => b.BOMId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(b => b.CompanyProducts).WithOne(c => c.BOM).HasForeignKey(c => c.BOMId).OnDelete(DeleteBehavior.SetNull);
                b.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<BOMItem>(b =>
            {
                b.ToTable("BOMItem");
                b.HasKey(b => b.Id);
                b.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<CompanyProduct>(c =>
            {
                c.ToTable("CompanyProduct");
                c.HasKey(c => c.Id);
                c.HasMany(c => c.CompanyProductStockSerialMaps).WithOne(c => c.CompanyProduct).HasForeignKey(c => c.CompanyProductId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.CompanyProductWarranties).WithOne(c => c.CompanyProduct).HasForeignKey(c => c.CompanyProductId).OnDelete(DeleteBehavior.Cascade);
                c.HasMany(c => c.Tickets).WithOne(t => t.CompanyProduct).HasForeignKey(t => t.CompanyProductId).OnDelete(DeleteBehavior.Restrict);
                c.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<CompanyProductStockSerialMap>(c =>
            {
                c.ToTable("CompanyProductStockSerialMap");
                c.HasKey(c => c.Id);
            });
            modelBuilder.Entity<CompanyProductWarranty>(c =>
            {
                c.ToTable("CompanyProductWarranty");
                c.HasKey(c => c.Id);
                c.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region Company Tables
            modelBuilder.Entity<Company>(c =>
            {
                c.ToTable("Company");
                c.HasKey(c => c.Id);
                c.HasMany(c => c.CompanyContacts).WithOne(c => c.Company).HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Cascade);
                c.HasMany(c => c.CompanyFiles).WithOne(c => c.Company).HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Cascade);
                c.HasMany(c => c.CompanyProducts).WithOne(c => c.Company).HasForeignKey(c => c.CompanyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.SellerCompanyInvoices).WithOne(i => i.SellerCompany).HasForeignKey(i => i.SellerCompanyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.BuyerCompanyInvoices).WithOne(i => i.BuyerCompany).HasForeignKey(i => i.BuyerCompanyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.StockSerials).WithOne(s => s.Company).HasForeignKey(s => s.CompanyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.Tickets).WithOne(t => t.Company).HasForeignKey(t => t.CompanyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.Users).WithOne(u => u.Company).HasForeignKey(u => u.CompanyId).OnDelete(DeleteBehavior.SetNull);
                c.HasMany(c => c.Warehouses).WithOne(w => w.Company).HasForeignKey(w => w.CompanyId).OnDelete(DeleteBehavior.Restrict);
                c.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<CompanyContact>(c =>
            {
                c.ToTable("CompanyContact");
                c.HasKey(c => c.Id);
            });
            modelBuilder.Entity<CompanyFile>(c =>
            {
                c.ToTable("CompanyFile");
                c.HasKey(c => c.Id);
            });
            #endregion

            #region Invoice
            modelBuilder.Entity<Invoice>(i =>
            {
                i.ToTable("Invoice");
                i.HasKey(i => i.Id);
                i.HasMany(i => i.StockMovements).WithOne(s => s.Invoice).HasForeignKey(s => s.InvoiceId).OnDelete(DeleteBehavior.Restrict);
                i.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<InvoiceType>(i =>
            {
                i.ToTable("InvoiceType");
                i.HasKey(i => i.Id);
                i.HasMany(i => i.Invoices).WithOne(i => i.InvoiceType).HasForeignKey(i => i.InvoiceTypeId).OnDelete(DeleteBehavior.Restrict);
                i.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region Project Tables
            modelBuilder.Entity<Project>(p =>
            {
                p.ToTable("Project");
                p.HasKey(p => p.Id);
                p.HasMany(p => p.ProjectFiles).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId).OnDelete(DeleteBehavior.Cascade);
                p.HasMany(p => p.ProjectMovements).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId).OnDelete(DeleteBehavior.Cascade);
                p.HasMany(p => p.ProjectStaffs).WithOne(p => p.Project).HasForeignKey(p => p.ProjectId).OnDelete(DeleteBehavior.Cascade);
                p.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<ProjectFile>(p =>
            {
                p.ToTable("ProjectFile");
                p.HasKey(p => p.Id);
            });
            modelBuilder.Entity<ProjectMovement>(p =>
            {
                p.ToTable("ProjectMovement");
                p.HasKey(p => p.Id);
                p.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<ProjectMovementType>(p =>
            {
                p.ToTable("ProjectMovementType");
                p.HasKey(p => p.Id);
                p.HasMany(p => p.ProjectMovements).WithOne(p => p.ProjectMovementType).HasForeignKey(p => p.ProjectMovementTypeId).OnDelete(DeleteBehavior.Restrict);
                p.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<ProjectStaff>(p =>
            {
                p.ToTable("ProjectStaff");
                p.HasKey(p => p.Id);
            });
            modelBuilder.Entity<ProjectStatus>(p =>
            {
                p.ToTable("ProjectStatus");
                p.HasKey(p => p.Id);
                p.HasMany(p => p.ProjectMovementTypes).WithOne(p => p.ProjectStatus).HasForeignKey(p => p.ProjectStatusId).OnDelete(DeleteBehavior.Cascade);
                p.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region Shipping
            modelBuilder.Entity<Shipping>(s =>
            {
                s.ToTable("Shipping");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.ShippingFiles).WithOne(s => s.Shipping).HasForeignKey(s => s.ShippingId).OnDelete(DeleteBehavior.Cascade);
                s.HasMany(s => s.TicketMovements).WithOne(t => t.Shipping).HasForeignKey(t => t.ShippingId).OnDelete(DeleteBehavior.SetNull);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<ShippingFile>(s =>
            {
                s.ToTable("ShippingFile");
                s.HasKey(s => s.Id);
            });
            modelBuilder.Entity<ShippingType>(s =>
            {
                s.ToTable("ShippingType");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.Shippings).WithOne(s => s.ShippingType).HasForeignKey(s => s.ShippingTypeId).OnDelete(DeleteBehavior.Restrict);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<CargoCompany>(c =>
            {
                c.ToTable("CargoCompany");
                c.HasKey(c => c.Id);
                c.HasMany(c => c.Shippings).WithOne(s => s.CargoCompany).HasForeignKey(s => s.CargoCompanyId).OnDelete(DeleteBehavior.Restrict);
                c.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region Stock Tables
            modelBuilder.Entity<Stock>(s =>
            {
                s.ToTable("Stock");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.BOMs).WithOne(b => b.Stock).HasForeignKey(b => b.StockId).OnDelete(DeleteBehavior.Restrict);
                s.HasMany(s => s.BOMItems).WithOne(b => b.Stock).HasForeignKey(b => b.StockId).OnDelete(DeleteBehavior.Cascade);
                s.HasMany(s => s.CompanyProducts).WithOne(c => c.Stock).HasForeignKey(c => c.StockId).OnDelete(DeleteBehavior.Restrict);
                s.HasMany(s => s.StockMovements).WithOne(s => s.Stock).HasForeignKey(s => s.StockId).OnDelete(DeleteBehavior.Restrict);
                s.HasMany(s => s.StockSerials).WithOne(s => s.Stock).HasForeignKey(s => s.StockId).OnDelete(DeleteBehavior.Restrict);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockBrand>(s =>
            {
                s.ToTable("StockBrand");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.Stocks).WithOne(s => s.StockBrand).HasForeignKey(s => s.StockBrandId).OnDelete(DeleteBehavior.Restrict);
                s.HasMany(s => s.StockGroupBrandMaps).WithOne(s => s.StockBrand).HasForeignKey(s => s.StockBrandId).OnDelete(DeleteBehavior.Cascade);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockGroup>(s =>
            {
                s.ToTable("StockGroup");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.Stocks).WithOne(s => s.StockGroup).HasForeignKey(s => s.StockGroupId).OnDelete(DeleteBehavior.Restrict);
                s.HasMany(s => s.StockGroupBrandMaps).WithOne(s => s.StockGroup).HasForeignKey(s => s.StockGroupId).OnDelete(DeleteBehavior.Cascade);
                s.HasMany(s => s.StockGroupFaultTypeMaps).WithOne(s => s.StockGroup).HasForeignKey(s => s.StockGroupId).OnDelete(DeleteBehavior.Cascade);
                s.HasMany(s => s.StockTypeGroupMaps).WithOne(s => s.StockGroup).HasForeignKey(s => s.StockGroupId).OnDelete(DeleteBehavior.Cascade);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockGroupBrandMap>(s =>
            {
                s.ToTable("StockGroupBrandMap");
                s.HasKey(s => s.Id);
            });
            modelBuilder.Entity<StockGroupFaultTypeMap>(s =>
            {
                s.ToTable("StockGroupFaultTypeMap");
                s.HasKey(s => s.Id);
            });
            modelBuilder.Entity<StockMovement>(s =>
            {
                s.ToTable("StockMovement");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.StockMovementStockSerialMaps).WithOne(s => s.StockMovement).HasForeignKey(s => s.StockMovementId).OnDelete(DeleteBehavior.Restrict);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockMovementStockSerialMap>(s =>
            {
                s.ToTable("StockMovementStockSerialMap");
                s.HasKey(s => s.Id);
            });
            modelBuilder.Entity<StockMovementType>(s =>
            {
                s.ToTable("StockMovementType");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.StockMovements).WithOne(s => s.StockMovementType).HasForeignKey(s => s.StockMovementTypeId).OnDelete(DeleteBehavior.Restrict);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockSerial>(s =>
            {
                s.ToTable("StockSerial");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.CompanyProductStockSerialMaps).WithOne(c => c.StockSerial).HasForeignKey(c => c.StockSerialId).OnDelete(DeleteBehavior.Restrict);
                s.HasMany(s => s.StockMovementStockSerialMaps).WithOne(s => s.StockSerial).HasForeignKey(s => s.StockSerialId).OnDelete(DeleteBehavior.Restrict);
                s.HasMany(s => s.StockSerialWarranties).WithOne(s => s.StockSerial).HasForeignKey(s => s.StockSerialId).OnDelete(DeleteBehavior.Cascade);
                s.HasMany(s => s.StockSerialMovements).WithOne(s => s.StockSerial).HasForeignKey(s => s.StockSerialId).OnDelete(DeleteBehavior.Restrict);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockSerialWarranty>(s =>
            {
                s.ToTable("StockSerialWarranty");
                s.HasKey(s => s.Id);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockType>(s =>
            {
                s.ToTable("StockType");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.StockTypeGroupMaps).WithOne(s => s.StockType).HasForeignKey(s => s.StockTypeId).OnDelete(DeleteBehavior.Cascade);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockTypeGroupMap>(s =>
            {
                s.ToTable("StockTypeGroupMap");
                s.HasKey(s => s.Id);
            });
            modelBuilder.Entity<Warehouse>(w =>
            {
                w.ToTable("Warehouse");
                w.HasKey(w => w.Id);
                w.HasMany(w => w.StockMovements).WithOne(s => s.Warehouse).HasForeignKey(s => s.WarehouseId).OnDelete(DeleteBehavior.Restrict);
                w.HasMany(w => w.StockSerials).WithOne(s => s.Warehouse).HasForeignKey(s => s.WarehouseId).OnDelete(DeleteBehavior.Restrict);
                w.HasMany(w => w.StockSerialMovements).WithOne(s => s.Warehouse).HasForeignKey(s => s.WarehouseId).OnDelete(DeleteBehavior.Restrict);
                w.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<StockSerialMovementType>(s =>
            {
                s.ToTable("StockSerialMovementType");
                s.HasKey(s => s.Id);
                s.HasMany(s => s.StockSerialMovements).WithOne(s => s.StockSerialMovementType).HasForeignKey(s => s.StockSerialMovementTypeId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<StockSerialMovement>(s =>
            {
                s.ToTable("StockSerialMovement");
                s.HasKey(s => s.Id);
                s.HasOne(s => s.StockSerial).WithMany(ss => ss.StockSerialMovements).HasForeignKey(s => s.StockSerialId).OnDelete(DeleteBehavior.Restrict);
                s.HasOne(s => s.StockSerialMovementType).WithMany(smt => smt.StockSerialMovements).HasForeignKey(s => s.StockSerialMovementTypeId).OnDelete(DeleteBehavior.Restrict);
                s.HasOne(s => s.Warehouse).WithMany(w => w.StockSerialMovements).HasForeignKey(s => s.WarehouseId).OnDelete(DeleteBehavior.Restrict);
                s.HasOne(s => s.CompanyProduct).WithMany(cp => cp.StockSerialMovements).HasForeignKey(s => s.CompanyProductId).OnDelete(DeleteBehavior.Restrict);
                s.HasOne(s => s.FaultType).WithMany(ft => ft.StockSerialMovements).HasForeignKey(s => s.FaultTypeId).OnDelete(DeleteBehavior.Restrict);
                s.HasOne(s => s.Ticket).WithMany(t => t.StockSerialMovements).HasForeignKey(s => s.TicketId).OnDelete(DeleteBehavior.Restrict);
                s.HasOne(s => s.User).WithMany(u => u.StockSerialMovements).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Restrict);
                s.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region Ticket Tables
            modelBuilder.Entity<Ticket>(t =>
            {
                t.ToTable("Ticket");
                t.HasKey(t => t.Id);
                t.HasMany(t => t.TicketFiles).WithOne(t => t.Ticket).HasForeignKey(t => t.TicketId).OnDelete(DeleteBehavior.Cascade);
                t.HasMany(t => t.TicketMessages).WithOne(t => t.Ticket).HasForeignKey(t => t.TicketId).OnDelete(DeleteBehavior.Cascade);
                t.HasMany(t => t.TicketMovements).WithOne(t => t.Ticket).HasForeignKey(t => t.TicketId).OnDelete(DeleteBehavior.Cascade);
                t.HasMany(t => t.TicketServicePrices).WithOne(t => t.Ticket).HasForeignKey(t => t.TicketId).OnDelete(DeleteBehavior.Cascade);
                t.HasMany(t => t.TicketStaffs).WithOne(t => t.Ticket).HasForeignKey(t => t.TicketId).OnDelete(DeleteBehavior.Cascade);
                t.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<TicketFile>(t =>
            {
                t.ToTable("TicketFile");
                t.HasKey(t => t.Id);
            });
            modelBuilder.Entity<TicketMessage>(t =>
            {
                t.ToTable("TicketMessage");
                t.HasKey(t => t.Id);
                t.HasMany(t => t.TicketMessageFiles).WithOne(t => t.TicketMessage).HasForeignKey(t => t.TicketMessageId).OnDelete(DeleteBehavior.Cascade);
                t.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<TicketMessageFile>(t =>
            {
                t.ToTable("TicketMessageFile");
                t.HasKey(t => t.Id);
            });
            modelBuilder.Entity<TicketMovement>(t =>
            {
                t.ToTable("TicketMovement");
                t.HasKey(t => t.Id);
                t.HasMany(t => t.StockMovements).WithOne(s => s.TicketMovement).HasForeignKey(s => s.TicketMovementId).OnDelete(DeleteBehavior.Restrict);
                t.HasMany(t => t.TicketMovementFiles).WithOne(t => t.TicketMovement).HasForeignKey(t => t.TicketMovementId).OnDelete(DeleteBehavior.Cascade);
                t.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<TicketMovementFile>(t =>
            {
                t.ToTable("TicketMovementFile");
                t.HasKey(t => t.Id);
            });
            modelBuilder.Entity<TicketMovementType>(t =>
            {
                t.ToTable("TicketMovementType");
                t.HasKey(t => t.Id);
                t.HasMany(t => t.LastTicketMovementTypeTickets).WithOne(t => t.LastTicketMovementType).HasForeignKey(t => t.LastTicketMovementTypeId).OnDelete(DeleteBehavior.Restrict);
                t.HasMany(t => t.TicketMovements).WithOne(t => t.TicketMovementType).HasForeignKey(t => t.TicketMovementTypeId).OnDelete(DeleteBehavior.Restrict);
                t.HasQueryFilter(f => !f.IsDeleted);


                t.HasData(
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.NewTicket, Name = TicketEnums.TicketMovementType.NewTicket.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.NewTicket, Accessible = true, Color = "#3699FF", InformationText = "Talep ilk kez açıldı.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.AppointedTechnicSupportStaff, Name = TicketEnums.TicketMovementType.AppointedTechnicSupportStaff.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.InTheProcess, Accessible = true, Color = "#8950FC", InformationText = "Talebe temsilci atandı.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.DirectedToTechnicalServices, Name = TicketEnums.TicketMovementType.DirectedToTechnicalServices.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.InTheProcess, Accessible = true, Color = "#FFA800", InformationText = "Teknik servise yönlendirme yapıldı.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.FaultDetected, Name = TicketEnums.TicketMovementType.FaultDetected.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.InTheProcess, Accessible = true, Color = "#1BC5BD", InformationText = "Arıza tespiti tamamlandı.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.CargoWaiting, Name = TicketEnums.TicketMovementType.CargoWaiting.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.WaitingForProccess, Accessible = true, Color = "#F64E60", InformationText = "Kargo teslimatı bekleniyor.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.PartWaiting, Name = TicketEnums.TicketMovementType.PartWaiting.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.WaitingForProccess, Accessible = true, Color = "#E4E6EF", InformationText = "Yedek parça bekleniyor.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.CargoSent, Name = TicketEnums.TicketMovementType.CargoSent.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.WaitingForProccess, Accessible = true, Color = "#3699FF", InformationText = "Kargo gönderimi yapıldı.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.ProcessApprovalWaiting, Name = TicketEnums.TicketMovementType.ProcessApprovalWaiting.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.ApprovalIsPending, Accessible = true, Color = "#FFA800", InformationText = "Yönetici onayı bekleniyor.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.FeeApprovalaWaiting, Name = TicketEnums.TicketMovementType.FeeApprovalaWaiting.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.ApprovalIsPending, Accessible = true, Color = "#F64E60", InformationText = "Müşteri ücret onayı bekleniyor.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.Approved, Name = TicketEnums.TicketMovementType.Approved.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.InTheProcess, Accessible = true, Color = "#1BC5BD", InformationText = "Onay alındı, işleme devam ediliyor.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.Denied, Name = TicketEnums.TicketMovementType.Denied.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.Denied, Accessible = true, Color = "#3F4254", InformationText = "Talep iptal edildi.", IsDeleted = false },
                    new TicketMovementType { Id = (int)TicketEnums.TicketMovementType.Completted, Name = TicketEnums.TicketMovementType.Completted.GetDescription(), TicketStatusId = (int)TicketEnums.TicketStatusType.Completted, Accessible = true, Color = "#1BC5BD", InformationText = "Talep tamamlandı ve kapatıldı.", IsDeleted = false }
                );
            });
            modelBuilder.Entity<TicketPriority>(t =>
            {
                t.ToTable("TicketPriority");
                t.HasKey(t => t.Id);
                t.HasMany(t => t.Tickets).WithOne(t => t.TicketPriority).HasForeignKey(t => t.TicketPriorityId).OnDelete(DeleteBehavior.Restrict);
                t.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<TicketServicePrice>(t =>
            {
                t.ToTable("TicketServicePrice");
                t.HasKey(t => t.Id);
                t.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<TicketStaff>(t =>
            {
                t.ToTable("TicketStaff");
                t.HasKey(t => t.Id);
            });
            modelBuilder.Entity<TicketStatus>(t =>
            {
                t.ToTable("TicketStatus");
                t.HasKey(t => t.Id);
                t.HasMany(t => t.TicketMovementTypes).WithOne(t => t.TicketStatus).HasForeignKey(t => t.TicketStatusId).OnDelete(DeleteBehavior.Restrict);
                t.HasQueryFilter(f => !f.IsDeleted);

                t.HasData(
                    new TicketStatus
                    {
                        Id = (int)TicketEnums.TicketStatusType.NewTicket,
                        Name = TicketEnums.TicketStatusType.NewTicket.GetDescription(),
                        Description = "Yeni açılan ve atanma bekleyen talepler",
                        IsDeleted = false
                    },
                    new TicketStatus
                    {
                        Id = (int)TicketEnums.TicketStatusType.InTheProcess,
                        Name = TicketEnums.TicketStatusType.InTheProcess.GetDescription(),
                        Description = "Personel atanmış ve işlem süreci devam eden talepler",
                        IsDeleted = false
                    },
                    new TicketStatus
                    {
                        Id = (int)TicketEnums.TicketStatusType.WaitingForProccess,
                        Name = TicketEnums.TicketStatusType.WaitingForProccess.GetDescription(),
                        Description = "Kargo veya parça bekleyen talepler",
                        IsDeleted = false
                    },
                    new TicketStatus
                    {
                        Id = (int)TicketEnums.TicketStatusType.ApprovalIsPending,
                        Name = TicketEnums.TicketStatusType.ApprovalIsPending.GetDescription(),
                        Description = "Yönetici veya müşteri onayı bekleyen talepler",
                        IsDeleted = false
                    },
                    new TicketStatus
                    {
                        Id = (int)TicketEnums.TicketStatusType.Denied,
                        Name = TicketEnums.TicketStatusType.Denied.GetDescription(),
                        Description = "İptal edilen ve işlem yapılmayan talepler",
                        IsDeleted = false
                    },
                    new TicketStatus
                    {
                        Id = (int)TicketEnums.TicketStatusType.Completted,
                        Name = TicketEnums.TicketStatusType.Completted.GetDescription(),
                        Description = "Çözümlenmiş ve kapatılmış talepler",
                        IsDeleted = false
                    }
                );
            });
            modelBuilder.Entity<TicketType>(t =>
            {
                t.ToTable("TicketType");
                t.HasKey(t => t.Id);
                t.HasMany(t => t.Tickets).WithOne(t => t.TicketType).HasForeignKey(t => t.TicketTypeId).OnDelete(DeleteBehavior.Restrict);
                t.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<FaultType>(f =>
            {
                f.ToTable("FaultType");
                f.HasKey(f => f.Id);
                f.HasMany(f => f.StockGroupFaultTypeMaps).WithOne(s => s.FaultType).HasForeignKey(s => s.FaultTypeId).OnDelete(DeleteBehavior.Cascade);
                f.HasMany(f => f.TicketMovements).WithOne(t => t.FaultType).HasForeignKey(t => t.FaultTypeId).OnDelete(DeleteBehavior.Restrict);
                f.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region Task Tables
            modelBuilder.Entity<_Task>(_ =>
            {
                _.ToTable("_Task");
                _.HasKey(_ => _.Id);
                _.HasMany(_ => _.TaskFiles).WithOne(_ => _.Task).HasForeignKey(_ => _.TaskId).OnDelete(DeleteBehavior.Cascade);
                _.HasMany(_ => _.TaskMovements).WithOne(_ => _.Task).HasForeignKey(_ => _.TaskId).OnDelete(DeleteBehavior.Cascade);
                _.HasMany(_ => _.TaskStaffs).WithOne(_ => _.Task).HasForeignKey(_ => _.TaskId).OnDelete(DeleteBehavior.Cascade);
                _.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<_TaskFile>(_ =>
            {
                _.ToTable("_TaskFile");
                _.HasKey(_ => _.Id);
            });
            modelBuilder.Entity<_TaskMovement>(_ =>
            {
                _.ToTable("_TaskMovement");
                _.HasKey(_ => _.Id);
                _.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<_TaskMovementType>(_ =>
            {
                _.ToTable("_TaskMovementType");
                _.HasKey(_ => _.Id);
                _.HasMany(_ => _.LastTaskMovementTypeTasks).WithOne(_ => _.LastTaskMovementType).HasForeignKey(_ => _.LastTaskMovementTypeId).OnDelete(DeleteBehavior.Restrict);
                _.HasMany(_ => _.TaskMovements).WithOne(_ => _.TaskMovementType).HasForeignKey(_ => _.TaskMovementTypeId).OnDelete(DeleteBehavior.Restrict);
                _.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<_TaskPriority>(_ =>
            {
                _.ToTable("_TaskPriority");
                _.HasKey(_ => _.Id);
                _.HasMany(_ => _.Tasks).WithOne(_ => _.TaskPriority).HasForeignKey(_ => _.TaskPriorityId).OnDelete(DeleteBehavior.Restrict);
                _.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<_TaskStaff>(_ =>
            {
                _.ToTable("_TaskStaff");
                _.HasKey(_ => _.Id);
            });
            modelBuilder.Entity<_TaskStatus>(_ =>
            {
                _.ToTable("_TaskStatus");
                _.HasKey(_ => _.Id);
                _.HasMany(_ => _.TaskMovementTypes).WithOne(_ => _.TaskStatus).HasForeignKey(_ => _.TaskStatusId).OnDelete(DeleteBehavior.Cascade);
                _.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region File System
            modelBuilder.Entity<FSFile>(f =>
            {
                f.ToTable("FS_File");
                f.HasKey(f => f.Id);
                f.HasMany(f => f.FileCompanyFiles).WithOne(c => c.File).HasForeignKey(c => c.FileId).OnDelete(DeleteBehavior.Restrict);
                f.HasMany(f => f.FileProjectFiles).WithOne(p => p.File).HasForeignKey(p => p.FileId).OnDelete(DeleteBehavior.Restrict);
                f.HasMany(f => f.FileShippingFiles).WithOne(s => s.File).HasForeignKey(s => s.FileId).OnDelete(DeleteBehavior.Restrict);
                f.HasMany(f => f.FileTaskFiles).WithOne(_ => _.File).HasForeignKey(_ => _.FileId).OnDelete(DeleteBehavior.Restrict);
                f.HasMany(f => f.FileTicketFiles).WithOne(t => t.File).HasForeignKey(t => t.FileId).OnDelete(DeleteBehavior.Restrict);
                f.HasMany(f => f.FileTicketMessageFiles).WithOne(t => t.File).HasForeignKey(t => t.FileId).OnDelete(DeleteBehavior.Restrict);
                f.HasMany(f => f.FileTicketMovementFiles).WithOne(t => t.File).HasForeignKey(t => t.FileId).OnDelete(DeleteBehavior.Restrict);
                f.HasMany(f => f.FileUserFiles).WithOne(u => u.File).HasForeignKey(u => u.FileId).OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<FSFolder>(f =>
            {
                f.ToTable("FS_Folder");
                f.HasKey(f => f.Id);
                f.HasMany(f => f.FolderFSFiles).WithOne(f => f.Folder).HasForeignKey(f => f.FolderId).OnDelete(DeleteBehavior.Cascade);
                // Self-referencing FK: SQL Server rejects ON DELETE CASCADE here (multiple cascade paths).
                f.HasMany(f => f.ParentFolderFSFolders).WithOne(f => f.ParentFolder).HasForeignKey(f => f.ParentFolderId).OnDelete(DeleteBehavior.Restrict);
            });
            #endregion

            #region Commons
            modelBuilder.Entity<ContactType>(c =>
            {
                c.ToTable("ContactType");
                c.HasKey(c => c.Id);
                c.HasMany(c => c.CompanyContacts).WithOne(c => c.ContactType).HasForeignKey(c => c.ContactTypeId).OnDelete(DeleteBehavior.Cascade);
                c.HasMany(c => c.UserContacts).WithOne(u => u.ContactType).HasForeignKey(u => u.ContactTypeId).OnDelete(DeleteBehavior.Cascade);
                c.HasQueryFilter(f => !f.IsDeleted);
            });

            modelBuilder.Entity<Currency>(c =>
            {
                c.ToTable("Currency");
                c.HasKey(c => c.Id);
                c.HasMany(c => c.Invoices).WithOne(i => i.Currency).HasForeignKey(i => i.CurrencyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.PriceCurrencyShippings).WithOne(s => s.PriceCurrency).HasForeignKey(s => s.PriceCurrencyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.PurchaseCurrencyStocks).WithOne(s => s.PurchaseCurrency).HasForeignKey(s => s.PurchaseCurrencyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.SalePriceCurrencyStocks).WithOne(s => s.SalePriceCurrency).HasForeignKey(s => s.SalePriceCurrencyId).OnDelete(DeleteBehavior.Restrict);
                c.HasMany(c => c.TicketServicePrices).WithOne(t => t.Currency).HasForeignKey(t => t.CurrencyId).OnDelete(DeleteBehavior.Restrict);
                c.HasQueryFilter(f => !f.IsDeleted);
            });

            modelBuilder.Entity<Unit>(u =>
            {
                u.ToTable("Unit");
                u.HasKey(u => u.Id);
                u.HasMany(u => u.Stocks).WithOne(s => s.Unit).HasForeignKey(s => s.UnitId).OnDelete(DeleteBehavior.Restrict);
                u.HasQueryFilter(f => !f.IsDeleted);
            });

            modelBuilder.Entity<WarrantyType>(w =>
            {
                w.ToTable("WarrantyType");
                w.HasKey(w => w.Id);
                w.HasMany(w => w.CompanyProductWarranties).WithOne(c => c.WarrantyType).HasForeignKey(c => c.WarrantyTypeId).OnDelete(DeleteBehavior.Restrict);
                w.HasMany(w => w.StockSerialWarranties).WithOne(s => s.WarrantyType).HasForeignKey(s => s.WarrantyTypeId).OnDelete(DeleteBehavior.Restrict);
                w.HasQueryFilter(f => !f.IsDeleted);
            });
            #endregion

            #region Project Core Tables
            modelBuilder.Entity<Log>(l =>
                {
                    l.ToTable("ProjectLogs");
                    l.HasKey(l => l.Id);
                });
            modelBuilder.Entity<Archive>(a =>
            {
                a.ToTable("ProjectArchives");
                a.HasKey(a => a.Id);
            });
            #endregion

            #region User Tables
            modelBuilder.Entity<User>(u =>
            {
                u.ToTable("User");
                u.HasKey(u => u.Id);
                u.HasMany(u => u.OwnerFSFolders).WithOne(f => f.Owner).HasForeignKey(f => f.OwnerId).OnDelete(DeleteBehavior.SetNull);
                u.HasMany(u => u.ProjectMovements).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Restrict);
                u.HasMany(u => u.ProjectStaffs).WithOne(p => p.User).HasForeignKey(p => p.UserId).OnDelete(DeleteBehavior.Cascade);
                u.HasMany(u => u.Shippings).WithOne(s => s.User).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.SetNull);
                u.HasMany(u => u.StockMovements).WithOne(s => s.User).HasForeignKey(s => s.UserId).OnDelete(DeleteBehavior.Restrict);
                u.HasMany(u => u.OwnerTasks).WithOne(_ => _.Owner).HasForeignKey(_ => _.OwnerId).OnDelete(DeleteBehavior.SetNull);
                u.HasMany(u => u.TaskMovements).WithOne(_ => _.User).HasForeignKey(_ => _.UserId).OnDelete(DeleteBehavior.Restrict);
                u.HasMany(u => u.TaskStaffs).WithOne(_ => _.User).HasForeignKey(_ => _.UserId).OnDelete(DeleteBehavior.Cascade);
                u.HasMany(u => u.RequesterTickets).WithOne(t => t.Requester).HasForeignKey(t => t.RequesterId).OnDelete(DeleteBehavior.Restrict);
                u.HasMany(u => u.SenderTicketMessages).WithOne(t => t.Sender).HasForeignKey(t => t.SenderId).OnDelete(DeleteBehavior.SetNull);
                u.HasMany(u => u.TicketMovements).WithOne(t => t.User).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Restrict);
                u.HasMany(u => u.TicketStaffs).WithOne(t => t.User).HasForeignKey(t => t.UserId).OnDelete(DeleteBehavior.Cascade);
                u.HasMany(u => u.UserContacts).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
                u.HasMany(u => u.UserFiles).WithOne(u => u.User).HasForeignKey(u => u.UserId).OnDelete(DeleteBehavior.Cascade);
                u.HasMany(u => u.RefreshTokens).WithOne(r => r.User).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
                u.HasQueryFilter(f => !f.IsDeleted);
            });
            modelBuilder.Entity<UserContact>(u =>
            {
                u.ToTable("UserContact");
                u.HasKey(u => u.Id);
            });
            modelBuilder.Entity<UserFile>(u =>
            {
                u.ToTable("UserFile");
                u.HasKey(u => u.Id);
            });
            modelBuilder.Entity<RefreshToken>(r =>
            {
                r.HasKey(r => r.Id);
                r.HasOne(r => r.User).WithMany(u => u.RefreshTokens).HasForeignKey(r => r.UserId).OnDelete(DeleteBehavior.Cascade);
            });
            #endregion

            #region Identity Tables
            modelBuilder.Entity<IdentityRole<Guid>>(entity =>
            {
                entity.ToTable("Roles");

                entity.HasData(new IdentityRole<Guid>
                {
                    Id = new Guid("b370875e-34cd-4b79-891c-93ae38f99d11"),
                    Name = "User",
                    NormalizedName = "USER",
                    ConcurrencyStamp = new Guid("b370875e-34cd-4b79-891c-93ae38f99d11").ToString()
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("cd6040ef-dacc-4678-9a85-154f12581cff"),
                    Name = "Manager",
                    NormalizedName = "MANAGER",
                    ConcurrencyStamp = new Guid("cd6040ef-dacc-4678-9a85-154f12581cff").ToString()
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("7138ec51-4f9e-4afd-b61b-5a9a4584f5da"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = new Guid("7138ec51-4f9e-4afd-b61b-5a9a4584f5da").ToString()
                },
                new IdentityRole<Guid>
                {
                    Id = new Guid("1f20c152-530e-4064-a39c-bbbed341fe84"),
                    Name = "Owner",
                    NormalizedName = "OWNER",
                    ConcurrencyStamp = new Guid("1f20c152-530e-4064-a39c-bbbed341fe84").ToString()
                });
            });
            modelBuilder.Entity<IdentityUserClaim<Guid>>(entity =>
            {
                entity.ToTable("UserClaims");
            });
            modelBuilder.Entity<IdentityUserLogin<Guid>>(entity =>
            {
                entity.ToTable("UserLogins");
            });
            modelBuilder.Entity<IdentityRoleClaim<Guid>>(entity =>
            {
                entity.ToTable("RoleClaims");
            });
            modelBuilder.Entity<IdentityUserRole<Guid>>(entity =>
            {
                entity.ToTable("UserRoles");
            });
            modelBuilder.Entity<IdentityUserToken<Guid>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
            #endregion
        }


        public DbSet<BOM> BOMs { get; set; }
        public DbSet<BOMItem> BOMItems { get; set; }
        public DbSet<CargoCompany> CargoCompanies { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyContact> CompanyContacts { get; set; }
        public DbSet<CompanyFile> CompanyFiles { get; set; }
        public DbSet<CompanyProduct> CompanyProducts { get; set; }
        public DbSet<CompanyProductStockSerialMap> CompanyProductStockSerialMaps { get; set; }
        public DbSet<CompanyProductWarranty> CompanyProductWarranties { get; set; }
        public DbSet<ContactType> ContactTypes { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public DbSet<FaultType> FaultTypes { get; set; }
        public DbSet<FSFile> FSFiles { get; set; }
        public DbSet<FSFolder> FSFolders { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<InvoiceType> InvoiceTypes { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectFile> ProjectFiles { get; set; }
        public DbSet<ProjectMovement> ProjectMovements { get; set; }
        public DbSet<ProjectMovementType> ProjectMovementTypes { get; set; }
        public DbSet<ProjectStaff> ProjectStaffs { get; set; }
        public DbSet<ProjectStatus> ProjectStatuses { get; set; }
        public DbSet<Shipping> Shippings { get; set; }
        public DbSet<ShippingFile> ShippingFiles { get; set; }
        public DbSet<ShippingType> ShippingTypes { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<StockBrand> StockBrands { get; set; }
        public DbSet<StockGroup> StockGroups { get; set; }
        public DbSet<StockGroupBrandMap> StockGroupBrandMaps { get; set; }
        public DbSet<StockGroupFaultTypeMap> StockGroupFaultTypeMaps { get; set; }
        public DbSet<StockMovement> StockMovements { get; set; }
        public DbSet<StockMovementStockSerialMap> StockMovementStockSerialMaps { get; set; }
        public DbSet<StockMovementType> StockMovementTypes { get; set; }
        public DbSet<StockSerial> StockSerials { get; set; }
        public DbSet<StockSerialWarranty> StockSerialWarranties { get; set; }
        public DbSet<StockSerialMovement> StockSerialMovements { get; set; }
        public DbSet<StockSerialMovementType> StockSerialMovementTypes { get; set; }
        public DbSet<StockType> StockTypes { get; set; }
        public DbSet<StockTypeGroupMap> StockTypeGroupMaps { get; set; }
        public DbSet<_Task> _Tasks { get; set; }
        public DbSet<_TaskFile> _TaskFiles { get; set; }
        public DbSet<_TaskMovement> _TaskMovements { get; set; }
        public DbSet<_TaskMovementType> _TaskMovementTypes { get; set; }
        public DbSet<_TaskPriority> _TaskPriorities { get; set; }
        public DbSet<_TaskStaff> _TaskStaffs { get; set; }
        public DbSet<_TaskStatus> _TaskStatuses { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketFile> TicketFiles { get; set; }
        public DbSet<TicketMessage> TicketMessages { get; set; }
        public DbSet<TicketMessageFile> TicketMessageFiles { get; set; }
        public DbSet<TicketMovement> TicketMovements { get; set; }
        public DbSet<TicketMovementFile> TicketMovementFiles { get; set; }
        public DbSet<TicketMovementType> TicketMovementTypes { get; set; }
        public DbSet<TicketPriority> TicketPriorities { get; set; }
        public DbSet<TicketServicePrice> TicketServicePrices { get; set; }
        public DbSet<TicketStaff> TicketStaffs { get; set; }
        public DbSet<TicketStatus> TicketStatuses { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Unit> Units { get; set; }
        public override DbSet<User> Users { get; set; }
        public DbSet<UserContact> UserContacts { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarrantyType> WarrantyTypes { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Archive> Archives { get; set; }
    }
}