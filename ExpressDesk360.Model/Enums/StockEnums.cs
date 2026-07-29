using System.ComponentModel;

namespace ExpressDesk360.Model.Enums
{
    public static class StockEnums
    {
        public enum StockMovementType : int
        {
            [Description("Satış Faturası Çıkış")]
            SalesInvoiceOut = 1,
            
            [Description("Alış Faturası Giriş")]
            PurchaseInvoiceIn = 2,
            
            [Description("Depolar Arası Transfer Giriş")]
            WarehouseTransferIn = 3,
            
            [Description("Depolar Arası Transfer Çıkış")]
            WarehouseTransferOut = 4,
            
            [Description("Üretimden Giriş")]
            ProductionIn = 5,
            
            [Description("Üretime Çıkış")]
            ProductionOut = 6,
            
            [Description("Rezerve Çıkış")]
            ReservedOut = 7,
            
            [Description("Devir Giriş")]
            TransferIn = 8,
            
            [Description("Yedek Parça Değişti")]
            SparePartChanged = 9,
            
            [Description("Ürüne Takıldı")]
            AttachedToProduct = 10,
            
            [Description("Ürününden Çıkartıldı")]
            RemovedFromProduct = 11,
            
            [Description("Destek Talebinin Açıldı")]
            SupportTicketOpened = 12
        } 

        public enum StockType : int
        {
            [Description("Hammadde")]
            RawMaterial = 1,
            
            [Description("Yarı Mamul")]
            SemiFinishedProduct = 2,
            
            [Description("Mamul")]
            FinishedProduct = 3
        }
    }
}
