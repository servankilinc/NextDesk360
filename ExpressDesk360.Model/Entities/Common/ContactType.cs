using ExpressDesk360.Core.Model;
using ExpressDesk360.Model.Entities.CompanyModule;
using ExpressDesk360.Model.Entities.UserModule;

namespace ExpressDesk360.Model.Entities.Common;

public class ContactType : IEntity, IActivatableEntity
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public bool IsActive { get; set; } = true;

    public virtual ICollection<CompanyContact>? CompanyContacts { get; set; }
    public virtual ICollection<UserContact>? UserContacts { get; set; }
}