using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class Shipping : IEntity, ISoftDeletableEntity, IArchivableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public int CargoCompanyId { get; set; }
        public int ShippingTypeId { get; set; }
        public Guid? UserId { get; set; }
        public string? SendingCompanyName { get; set; }
        public string? ReceivingCompanyName { get; set; }
        public bool IsIncoming { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime ShippingDate { get; set; }
        public decimal? Price { get; set; }
        public int? PriceCurrencyId { get; set; }
        
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
        
        public virtual CargoCompany? CargoCompany { get; set; }
        public virtual ShippingType? ShippingType { get; set; }
        public virtual User? User { get; set; }
        public virtual Currency? PriceCurrency { get; set; }
        public virtual ICollection<ShippingFile>? ShippingFiles { get; set; }
        public virtual ICollection<TicketMovement>? TicketMovements { get; set; }
    }
}