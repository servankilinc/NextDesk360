namespace ExpressDesk360.WebUI.Models.UI;

public class HeaderViewModel
{
    public List<LocalizationItem> Localizations { get; set; } = new();

    // Set by the page through ViewData["Breadcrumb"] and handed over by _Layout.
    // Null on pages that do not declare one - the header then renders no page title.
    public Breadcrum? Breadcrumb { get; set; }
}
