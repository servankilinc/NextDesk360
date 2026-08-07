using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.InvoiceModule;
using ExpressDesk360.Model.Entities.ProductionModule;
using ExpressDesk360.Model.Entities.StockModule;
using ExpressDesk360.Model.Entities.TicketModule;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Model.Entities.CompanyModule;

public class Company : IEntity, IActivatableEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public bool ManagerApproval { get; set; }
    public string? Description { get; set; }
    public string? LogoUrl { get; set; }
    public bool IsActive { get; set; } = true;

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual ICollection<CompanyContact>? CompanyContacts { get; set; }
    public virtual ICollection<CompanyFile>? CompanyFiles { get; set; }
    public virtual ICollection<CompanyProduct>? CompanyProducts { get; set; }
    public virtual ICollection<Invoice>? SellerCompanyInvoices { get; set; }
    public virtual ICollection<Invoice>? BuyerCompanyInvoices { get; set; }
    public virtual ICollection<StockSerial>? StockSerials { get; set; }
    public virtual ICollection<Ticket>? Tickets { get; set; }
    public virtual ICollection<User>? Users { get; set; }
    public virtual ICollection<Warehouse>? Warehouses { get; set; }
}