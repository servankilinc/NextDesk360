using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class ProjectStaff : IEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public Guid ProjectId { get; set; }
        public Guid UserId { get; set; }
        public DateTime JoinedDate { get; set; }

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion
        public virtual Project? Project { get; set; }
        public virtual User? User { get; set; }
    }
}