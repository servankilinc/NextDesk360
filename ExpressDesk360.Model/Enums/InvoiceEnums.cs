using System.ComponentModel;

namespace ExpressDesk360.Model.Enums;

public static class InvoiceEnums
{
    public enum InvoiceType : int
    {
        [Description("Alış Faturası")]
        PurchaseInvoice = 1,

        [Description("Satış Faturası")]
        SalesInvoice = 2,

        [Description("İade Faturası")]
        ReturnInvoice = 3
    }
}
