using ExpressDesk360.Core.Model;
using Microsoft.AspNetCore.Identity;

namespace ExpressDesk360.Model.Entities
{
    public class User : IdentityUser<Guid>, IEntity, IActivatableEntity, IAuditableEntity
    {
        // public Guid Id { get; set; }
        // public string UserName { get; set; } = null!;
        public Guid? CompanyId { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public DateTime? HireDate { get; set; }
        public string? LogoUrl { get; set; }

        public bool IsActive { get; set; } = true;

        #region IAuditableEntity
        public string? CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? CreateDateUtc { get; set; }
        public DateTime? UpdateDateUtc { get; set; }
        #endregion
        public virtual Company? Company { get; set; }
        public virtual ICollection<FSFolder>? OwnerFSFolders { get; set; }
        public virtual ICollection<ProjectMovement>? ProjectMovements { get; set; }
        public virtual ICollection<ProjectStaff>? ProjectStaffs { get; set; }
        public virtual ICollection<Shipping>? Shippings { get; set; }
        public virtual ICollection<StockMovement>? StockMovements { get; set; }
        public virtual ICollection<_Task>? OwnerTasks { get; set; }
        public virtual ICollection<_TaskMovement>? TaskMovements { get; set; }
        public virtual ICollection<_TaskStaff>? TaskStaffs { get; set; }
        public virtual ICollection<Ticket>? RequesterTickets { get; set; }
        public virtual ICollection<TicketMessage>? SenderTicketMessages { get; set; }
        public virtual ICollection<TicketMovement>? TicketMovements { get; set; }
        public virtual ICollection<TicketStaff>? TicketStaffs { get; set; }
        public virtual ICollection<UserContact>? UserContacts { get; set; }
        public virtual ICollection<UserFile>? UserFiles { get; set; }
        public virtual ICollection<RefreshToken>? RefreshTokens { get; set; }
        public virtual ICollection<StockSerialMovement>? StockSerialMovements { get; set; }
    }
}