namespace ExpressDesk360.WebUI.Models.UI;

public class MenuItem
{
    public string Title { get; set; } = "Menu Item";
    public string? Path { get; set; }
    public string Icon { get; set; } = string.Empty;
    public string GroupName { get; set; } = string.Empty;
    public string Target { get; set; } = "_self"; // _self, _blank, _parent, _top
    public string CollorTheme { get; set; } = "secondary"; // "primary", "dark", "success", "danger", "secondary", "warning", "info", "light"
    public bool IsActive { get; set; }
    public bool HasActiveChild { get; set; }
    public bool Available { get; set; } = true;
    public List<MenuItem>? SubMenuItems { get; set; }
}
