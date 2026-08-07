using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.Common;

namespace ExpressDesk360.Model.Entities.TicketModule;

public class TicketFile : IEntity, IAuditableEntity
{
    public Guid Id { get; set; }
    public Guid TicketId { get; set; }
    public Guid FileId { get; set; }

    #region IAuditableEntity
    public string? CreatedBy { get; set; }
    public string? UpdatedBy { get; set; }
    public DateTime? CreateDateUtc { get; set; }
    public DateTime? UpdateDateUtc { get; set; }
    #endregion

    public virtual Ticket? Ticket { get; set; }
    public virtual FSFile? File { get; set; }
}