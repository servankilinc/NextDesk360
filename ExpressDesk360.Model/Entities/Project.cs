using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class Project : IEntity, ISoftDeletableEntity, IArchivableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime StartDate { get; set; }
        public DateTime? Deadline { get; set; }
        public string? Description { get; set; }
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual ICollection<ProjectFile>? ProjectFiles { get; set; }
        public virtual ICollection<ProjectMovement>? ProjectMovements { get; set; }
        public virtual ICollection<ProjectStaff>? ProjectStaffs { get; set; }
    }
}