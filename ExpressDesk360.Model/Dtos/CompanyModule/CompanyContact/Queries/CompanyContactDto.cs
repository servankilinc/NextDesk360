using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.CompanyModule.CompanyContact.Queries;

public class CompanyContactDto : IDto
{
    public Guid Id { get; set; }
    public Guid CompanyId { get; set; }
    public int ContactTypeId { get; set; }
    public string Info { get; set; } = null!;
}