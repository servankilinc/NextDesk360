using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class _TaskFile : IEntity, ISoftDeletableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid TaskId { get; set; }
        public Guid FileId { get; set; }

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

        public virtual _Task? Task { get; set; }
        public virtual FSFile? File { get; set; }
    }
}