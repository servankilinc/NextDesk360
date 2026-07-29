using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Entities
{
    public class Ticket : IEntity, ISoftDeletableEntity, IArchivableEntity, IAuditableEntity
    {
        public Guid Id { get; set; }
        public int TicketTypeId { get; set; }
        public int TicketPriorityId { get; set; }
        public Guid RequesterId { get; set; }
        public Guid CompanyId { get; set; }
        public Guid? CompanyProductId { get; set; }
        public int Number { get; set; }
        public int LastTicketMovementTypeId { get; set; }
        public string Title { get; set; } = null!;
        public string? TicketDescription { get; set; }
        public bool RemoteSupport { get; set; }
        public bool UnderWarranty { get; set; }
        public DateTime Date { get; set; }
        public DateTime? DueDate { get; set; }

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

        public virtual TicketType? TicketType { get; set; }
        public virtual TicketPriority? TicketPriority { get; set; }
        public virtual User? Requester { get; set; }
        public virtual Company? Company { get; set; }
        public virtual CompanyProduct? CompanyProduct { get; set; }
        public virtual TicketMovementType? LastTicketMovementType { get; set; }
        public virtual ICollection<TicketFile>? TicketFiles { get; set; }
        public virtual ICollection<TicketMessage>? TicketMessages { get; set; }
        public virtual ICollection<TicketMovement>? TicketMovements { get; set; }
        public virtual ICollection<TicketServicePrice>? TicketServicePrices { get; set; }
        public virtual ICollection<TicketStaff>? TicketStaffs { get; set; }
        public virtual ICollection<StockSerialMovement>? StockSerialMovements { get; set; }
    }
}