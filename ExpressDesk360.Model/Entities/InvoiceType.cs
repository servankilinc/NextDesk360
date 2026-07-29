using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class InvoiceType : IEntity, IActivatableEntity, IAuditableEntity
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public char InOutCode { get; set; }
        public string? NumberStart { get; set; }
        public byte Status { get; set; }

        public bool IsActive { get; set; } = true;

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; } 
        #endregion
        public virtual ICollection<Invoice>? Invoices { get; set; }
    }
}