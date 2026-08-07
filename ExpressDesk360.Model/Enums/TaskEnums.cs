using System.ComponentModel;

namespace ExpressDesk360.Model.Enums;

public static class TaskEnums
{
    public enum TaskPriorityType : int
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

    public enum TaskStatusType : int
    {
        [Description("Yeni Görev")]
        NewTask = 1,

        [Description("İşlemde")]
        InTheProcess = 2,

        [Description("Beklemede")]
        Waiting = 3,

        [Description("İptal Edildi")]
        Cancelled = 4,

        [Description("Tamamlandı")]
        Completed = 5
    }

    public enum TaskMovementType : int
    {
        [Description("Görev Oluşturuldu")]
        TaskCreated = 1,

        [Description("Personel Atandı")]
        StaffAssigned = 2,

        [Description("İşleme Alındı")]
        Processing = 3,

        [Description("Beklemeye Alındı")]
        PutOnHold = 4,

        [Description("İptal Edildi")]
        Cancelled = 5,

        [Description("Tamamlandı")]
        Completed = 6,

        [Description("Dosya Eklendi")]
        FileAdded = 7
    }
}
