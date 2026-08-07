using ExpressDesk360.Core.Model;

namespace ExpressDesk360.Model.Dtos.Common.ContactType.Queries;

public class ContactTypeDto : IDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public bool IsActive { get; set; } = true;
}