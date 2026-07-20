using System.ComponentModel;

namespace ExpressDesk360.Core.Enums;

public enum AuthenticationType : byte
{
    [Description("None")]
    None = 0,
    [Description("Email")]
    Email = 1,
    [Description("Google")]
    Google = 2,
    [Description("Facebook")]
    Facebook = 3,
}
