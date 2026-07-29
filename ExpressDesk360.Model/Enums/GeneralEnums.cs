using System.ComponentModel;

namespace ExpressDesk360.Model.Enums
{
    public static class GeneralEnums
    {
        public enum ContactType : int
        {
            [Description("Telefon")]
            Phone = 1,
            
            [Description("E-Posta")]
            Email = 2,
            
            [Description("Adres")]
            Address = 3,
            
            [Description("Faks")]
            Fax = 4,
            
            [Description("Web Sitesi")]
            Website = 5
        }

        public enum InvoiceType : int
        {
            [Description("Alış Faturası")]
            PurchaseInvoice = 1,
            
            [Description("Satış Faturası")]
            SalesInvoice = 2,
            
            [Description("İade Faturası")]
            ReturnInvoice = 3
        }

        public enum ShippingType : int
        {
            [Description("Alıcı Ödemeli")]
            ReceiverPays = 1,
            
            [Description("Gönderen Ödemeli")]
            SenderPays = 2
        }

        public enum UnitType : int
        {
            [Description("Adet")]
            Piece = 1,
            
            [Description("Kilogram")]
            Kilogram = 2,
            
            [Description("Litre")]
            Liter = 3,
            
            [Description("Metre")]
            Meter = 4,
            
            [Description("Koli")]
            Box = 5,
            
            [Description("Paket")]
            Package = 6
        }

        public enum WarrantyType : int
        {
            [Description("Üretici Garantisi")]
            ManufacturerWarranty = 1,
            
            [Description("Satıcı Garantisi")]
            SellerWarranty = 2,
            
            [Description("Uzatılmış Garanti")]
            ExtendedWarranty = 3
        }

        public enum CurrencyType : int
        {
            [Description("Türk Lirası")]
            TRY = 1,
            
            [Description("Amerikan Doları")]
            USD = 2,
            
            [Description("Euro")]
            EUR = 3,
            
            [Description("İngiliz Sterlini")]
            GBP = 4
        }
    }
}
