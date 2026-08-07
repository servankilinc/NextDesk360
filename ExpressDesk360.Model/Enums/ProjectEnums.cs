using System.ComponentModel;

namespace ExpressDesk360.Model.Enums;

public static class ProjectEnums
{
    public enum ProjectStatusType : int
    {
        [Description("Planlanıyor")]
        Planning = 1,

        [Description("Devam Ediyor")]
        InProgress = 2,

        [Description("Beklemede")]
        OnHold = 3,

        [Description("İptal Edildi")]
        Cancelled = 4,

        [Description("Tamamlandı")]
        Completed = 5
    }

    public enum ProjectMovementType : int
    {
        [Description("Proje Oluşturuldu")]
        ProjectCreated = 1,

        [Description("Planlama Aşamasına Geçildi")]
        PlanningPhase = 2,

        [Description("Geliştirme Aşamasına Geçildi")]
        DevelopmentPhase = 3,

        [Description("Test Aşamasına Geçildi")]
        TestingPhase = 4,

        [Description("Yayına Alındı")]
        Deployed = 5,

        [Description("İptal Edildi")]
        Cancelled = 6,

        [Description("Tamamlandı")]
        Completed = 7,

        [Description("Dosya Eklendi")]
        FileAdded = 8
    }
}
