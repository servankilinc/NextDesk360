using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class FSFile : IEntity, ISoftDeletableEntity
    {
        public Guid Id { get; set; }
        public Guid FolderId { get; set; }
        public string Name { get; set; } = null!;
        public string Path { get; set; } = null!;
        public string? Extension { get; set; }
        public string? MimeType { get; set; }
        public long? Size { get; set; }
        public string? Hash { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string? DeletedBy { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DeletedDateUtc { get; set; }
        public virtual FSFolder? Folder { get; set; }
        public virtual ICollection<CompanyFile>? FileCompanyFiles { get; set; }
        public virtual ICollection<ProjectFile>? FileProjectFiles { get; set; }
        public virtual ICollection<ShippingFile>? FileShippingFiles { get; set; }
        public virtual ICollection<_TaskFile>? FileTaskFiles { get; set; }
        public virtual ICollection<TicketFile>? FileTicketFiles { get; set; }
        public virtual ICollection<TicketMessageFile>? FileTicketMessageFiles { get; set; }
        public virtual ICollection<TicketMovementFile>? FileTicketMovementFiles { get; set; }
        public virtual ICollection<UserFile>? FileUserFiles { get; set; }
    }
}