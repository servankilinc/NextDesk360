using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class Company : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? Fax { get; set; }
        public bool ManagerApproval { get; set; }
        public string? Description { get; set; }
        public string? LogoUrl { get; set; }
        
        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion

        #region ISoftDeletableEntity
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; } 
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
}