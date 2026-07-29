using System.ComponentModel;

namespace ExpressDesk360.Model.Enums;

public static class TicketEnums
{
    public enum TicketPriorityType : int
    {
        [Description("Düşük")]
        Low = 1,
        
        [Description("Normal")]
        Normal = 2,
        
        [Description("Yüksek")]
        High = 3,
        
        [Description("Kritik")]
        Critical = 4
    }

    public enum TicketType : int
    {
        [Description("Teknik Destek")]
        TechnicalSupport = 1,
        
        [Description("Genel Bakım")]
        GeneralMaintenance = 2,
        
        [Description("Yazılım Destek")]
        SoftwareSupport = 3
    }

    public enum TicketStatusType : int
    {
        [Description("Yeni Kayıt")]
        NewTicket = 1,

        [Description("İşlemde")]
        InTheProcess = 2,

        [Description("Beklemede")]
        WaitingForProccess = 3,

        [Description("Onay Bekleniyor")]
        ApprovalIsPending = 4,
        
        [Description("İptal Edildi")]
        Denied = 5,

        [Description("Tamamlandı")]
        Completted = 6,
    }

    public enum TicketMovementType : int
    {
        [Description("Yeni Kayıt")]
        NewTicket = 1,
        
        [Description("Temsilci Atandı")]
        AppointedTechnicSupportStaff = 2,
        
        [Description("Teknik Hizmetlere Yönlendirildi")]
        DirectedToTechnicalServices = 3,
        
        [Description("Arıza Tespiti Yapıldı")]
        FaultDetected = 4,

        [Description("Kargo Bekleniyor")]
        CargoWaiting = 5,

        [Description("Parça Bekleniyor")]
        PartWaiting = 6,

        [Description("Kargo Gönderildi")]
        CargoSent = 7,

        [Description("Müdür Onayı Bekleniyor")]
        ProcessApprovalWaiting = 8,

        [Description("Ücret Onayı Bekleniyor")]
        FeeApprovalaWaiting = 9,

        [Description("Onay Alındı")]
        Approved = 10,
        
        [Description("İptal Edildi")]
        Denied = 11,
        
        [Description("Tamamlandı")]
        Completted = 12
    }
}
