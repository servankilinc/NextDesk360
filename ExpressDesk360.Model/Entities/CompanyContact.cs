using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class CompanyContact : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid CompanyId { get; set; }
        public int ContactTypeId { get; set; }
        public string Info { get; set; } = null!;

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
        
        public virtual Company? Company { get; set; }
        public virtual ContactType? ContactType { get; set; }
    }
}