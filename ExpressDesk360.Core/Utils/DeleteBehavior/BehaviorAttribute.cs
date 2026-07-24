namespace ExpressDesk360.Core.Utils.DeleteBehavior;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class CascadeDeleteAttribute : Attribute
{
}

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
public sealed class RestrictDeleteAttribute : Attribute
{
}