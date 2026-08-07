using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.UserModule.UserContact.Queries
{
    public class UserContactDto : IDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int ContactTypeId { get; set; }
        public string Info { get; set; } = null!;
    }
}